using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SteamAuth;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Threading;

namespace _2FAuthAndroidLibrary
{
    public class CSteamAuth
    {
        private UserLogin userLogin;
        private AuthenticatorLinker linker;
        internal static SteamGuardAccount steamGuardAccount;
        
        public string captchaGID;
        public const string SGAccountFile = "steamguard.json";
        private const byte MinSessionTTL = 15;
        internal static DateTime LastRefresh;
        private const string salt = "There is something";
        public CSteamAuth()
        {
            userLogin = new UserLogin();
        }
        public async Task<UserLogin.LoginResult> Login(string username, string password, string captcha = null, string email = null, string twofactorcode = null)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return UserLogin.LoginResult.GeneralFailure;

            userLogin.Username = username;
            userLogin.Password = password;
            userLogin.CaptchaText = userLogin.RequiresCaptcha ? captcha : "";
            userLogin.EmailCode = userLogin.RequiresEmail ? email : "";
            userLogin.TwoFactorCode = userLogin.Requires2FA ? twofactorcode : "";

            var res = await userLogin.DoLogin().ConfigureAwait(true);
            if (res == UserLogin.LoginResult.NeedCaptcha)
                captchaGID = userLogin.CaptchaGID;
            else captchaGID = "";
            if (res == UserLogin.LoginResult.LoginOkay && linker == null)
                linker = new AuthenticatorLinker(userLogin.Session);

            return res;
        }
        public async Task<LinkResult> Link(string phone=null)
        {
            if (linker._session == null)
                return LinkResult.GeneralFailure;

            linker.PhoneNumber = phone;
            var res = await linker.AddAuthenticator().ConfigureAwait(false);

            return res;
        }
        public async Task<FinalizeResult> FinalizeLink(string smscode,string secret)
        {
            if (string.IsNullOrEmpty(smscode) || smscode.Length != 5)
                return FinalizeResult.BadSMSCode;
            if (!string.IsNullOrEmpty(secret) && secret.Length < 4)
                return FinalizeResult.GeneralFailure;

            var res = await linker.FinalizeAddAuthenticator(smscode).ConfigureAwait(true);
            if (res == FinalizeResult.Success)
            {
                steamGuardAccount = linker.LinkedAccount;
                await steamGuardAccount.AlignTimeAsync().ConfigureAwait(true);
                var saveRes = SaveSGAccount(secret);
                if (saveRes == SaveResult.FileError)
                {
                    File.WriteAllText("YOUR REVOCATION CODE.txt", "Cant save sga account data, here your revocation code to delete authenticator(" + steamGuardAccount.RevocationCode + ")");
                }
                if (saveRes == SaveResult.IncorrectSecretCode)
                    return FinalizeResult.IncorrectSecretCode;
            }

            return res;
        }
        public bool LoadAuthenticator(string secret, string Path = SGAccountFile)
        {
            if (string.IsNullOrEmpty(Path))
                Path = SGAccountFile;

            if (secret.Length < 4 || !File.Exists(Path))
                return false;

            SteamGuardAccount acc;
            try {
                acc = JsonConvert.DeserializeObject<SteamGuardAccount>(File.ReadAllText(Path));
            } catch (Exception) { return false; }
            if (acc == null)
                return false;
            #region crypto
            using (var crypto = new RijndaelManaged()) // Decrypt data
            {
                crypto.Padding = PaddingMode.None;
                crypto.KeySize = 128;          // in bits
                var keysDeriver = new Rfc2898DeriveBytes(secret, Encoding.ASCII.GetBytes("There is something"));

                crypto.Key = keysDeriver.GetBytes(crypto.KeySize / 8);
                crypto.IV = keysDeriver.GetBytes(crypto.BlockSize / 8);

                string[] sIn = {
                    acc.IdentitySecret,
                    acc.SharedSecret
                    };

                string[] sOut = new string[2];
                for (int i = 0; i < 2; i++)
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, crypto.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            var byteArr = Convert.FromBase64String(sIn[i]);
                            try { 
                            cs.Write(byteArr, 0, byteArr.Length);
                            } catch(Exception) { return false; }
                        }
                        sOut[i] = Convert.ToBase64String(ms.ToArray());
                    }
                
                acc.IdentitySecret = sOut[0];
                acc.SharedSecret = sOut[1];
                int iSecret = 0;
                int.TryParse(secret, out iSecret);
                int newRcode = int.Parse(acc.RevocationCode.Substring(1)) - 375 - iSecret;
                if (newRcode.ToString().Length < 5)
                    newRcode = int.Parse(acc.RevocationCode.Substring(1)) + 375 + iSecret;
                acc.RevocationCode = "R" + newRcode;
            }
            #endregion
            steamGuardAccount = acc;
            steamGuardAccount.AlignTime();
            RefreshSessionIfNeed().ConfigureAwait(true);

            return true;
        } // Load steam guard account
        public string GetAccountName()
        {
            if (steamGuardAccount == null)
                return "";
            return steamGuardAccount.AccountName;
        }
        public async Task<string> Get2FACode()
        {
            if (steamGuardAccount == null)
                return "";
            return await steamGuardAccount.GenerateSteamGuardCodeAsync().ConfigureAwait(false);
        }
        public async Task<int> Get2FACodeLeft()
        {
            return await steamGuardAccount.GetLeftTime().ConfigureAwait(true);
        }
        public async Task<bool> DeleteAuthenticator()
        {
            if (steamGuardAccount == null)
                return true;

            var res = await steamGuardAccount.DeactivateAuthenticator().ConfigureAwait(true);
            if (res)
                File.Delete(SGAccountFile);
            return res;
        } 
        public string GetRevocationCode()
        {
            if (steamGuardAccount == null)
                return "";
            return steamGuardAccount.RevocationCode;
        }
        public SaveResult SaveSGAccount(string secret, string Path = SGAccountFile)
        {
            if (string.IsNullOrEmpty(Path))
                Path = SGAccountFile;
            if (secret.Length < 4)
                return SaveResult.IncorrectSecretCode;
            if (!File.Exists(Path))
            {
                var stream = File.Create(Path);
                stream.Close();
            }
            SteamGuardAccount acc = new SteamGuardAccount(steamGuardAccount);
            #region cryptography
            using (var crypto = new RijndaelManaged())
            {
                crypto.Padding = PaddingMode.Zeros;
                crypto.KeySize = 128;          // in bits
                var keysDeriver = new Rfc2898DeriveBytes(secret, Encoding.ASCII.GetBytes("There is something"));

                crypto.Key = keysDeriver.GetBytes(crypto.KeySize / 8);
                crypto.IV = keysDeriver.GetBytes(crypto.BlockSize / 8);
                string[] sIn = {
                    acc.IdentitySecret,
                    acc.SharedSecret
                };
                string[] sOut = new string[2];

                for (int i = 0; i < 2; i++)
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, crypto.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            var byteArr = Convert.FromBase64String(sIn[i]);
                            try
                            {
                                cs.Write(byteArr, 0, byteArr.Length);
                            }
                            catch (Exception e) {
                                Logging.LogError("Cant write to crypto stream: " + e.Message);
                                return SaveResult.CryptoError;
                            }
                        }

                        sOut[i] = Convert.ToBase64String(ms.ToArray());
                    }
                acc.IdentitySecret = sOut[0];
                acc.SharedSecret = sOut[1];
                int iSecret = 0;
                int.TryParse(secret, out iSecret);
                int newRcode = int.Parse(acc.RevocationCode.Substring(1)) + 375 + iSecret;
                if (newRcode.ToString().Length > 5)
                    newRcode = int.Parse(acc.RevocationCode.Substring(1)) - 375 - iSecret;
                acc.RevocationCode = "R" + newRcode;
            }
            #endregion
            bool saved = false;
            for (byte i = 0; i < 5 && saved == false; i++)
            {
                try {
                    File.WriteAllText(Path, JsonConvert.SerializeObject(acc));
                } catch (Exception e) {
                    Logging.LogError("Cant save steam guard file: " + e.Message);
                    Thread.Sleep(1000);
                    continue;
                }
                saved = true;
            }
            if(!saved)
                return SaveResult.FileError;

            return SaveResult.Ok;
        } // Save steam guard account to file (SGAccountFile)
        internal static async Task RefreshSessionIfNeed()
        {
            if (DateTime.Now.Subtract(LastRefresh) > TimeSpan.FromSeconds(MinSessionTTL))
            {
                await steamGuardAccount.RefreshSessionAsync().ConfigureAwait(true);
                LastRefresh = DateTime.Now;
            }
        }
        public string GetCaptchaFile(string gid)
        {
            if (string.IsNullOrEmpty(gid))
                return "";
            string url = "https://steamcommunity.com/login/rendercaptcha/?gid=" + gid;
            string filePath = "captcha.png";
            if (File.Exists(filePath))
                try { 
                File.Delete(filePath);
                }
                catch (Exception e) { }
            WebClient wc = new WebClient();
            wc.DownloadFile(url, filePath);
            return filePath;
        } // Download captcha, and return path of downloaded captcha
        public string GetSteamGuardFile(string url)
        {
            if (string.IsNullOrEmpty(url))
                return null;
            WebClient wc = new WebClient();
            wc.DownloadFile(url, SGAccountFile);
            return SGAccountFile;
        } //Download SG file
        public async Task<List<Confirmation_light>> GetConfirmations()
        {
            await RefreshSessionIfNeed();
            var list = await steamGuardAccount.FetchConfirmationsAsync().ConfigureAwait(true);
            List<Confirmation_light> res = new List<Confirmation_light>(list.Count());
            foreach (var confirmation in list)
            {
                res.Add(new Confirmation_light() {
                    ConfType = (Confirmation_light.ConfirmationType)((int)confirmation.ConfType),
                    Description = confirmation.Description,
                    ID = confirmation.ID,
                    Key = confirmation.Key,
                    Name = confirmation.Name
                });
            }

            return res;
        }
        private string EnCrypt(string data, string key, CryptType type)
        {
            var res = "";

            using (var crypto = new RijndaelManaged())
            {
                crypto.Padding = PaddingMode.Zeros;
                crypto.KeySize = 128;
                var keyDeriver = new Rfc2898DeriveBytes(key, Encoding.ASCII.GetBytes(salt));
                crypto.Key = keyDeriver.GetBytes(crypto.KeySize / 8);
                crypto.IV = keyDeriver.GetBytes(crypto.BlockSize / 8);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms,crypto.CreateEncryptor(),CryptoStreamMode.Write))
                    {
                        byte[] byteArr;
                        switch (type)
                        {
                            case CryptType.base64:
                                byteArr = Convert.FromBase64String(data);
                                break;
                            case CryptType.ASCII:
                            default:
                                byteArr = Encoding.ASCII.GetBytes(data);
                                break;
                        }
                        try {
                            cs.Write(byteArr, 0, byteArr.Length);
                        } catch(Exception e) {
                            Logging.LogError("Cant write to crypto stream: " + e.Message);
                            return res;
                        }
                        var resArr = ms.ToArray();
                        int index = 0;
                        for (; index < resArr.Length; index++) // Looking for null bytes
                            if (resArr[index] == 0)
                                break;
                        res = Convert.ToBase64String(resArr, 0, index);
                    }
                }
            }

                return res;
        }
        private string DeCrypt(string data, string key, CryptType type)
        {
            var res = "";

            return res;
        }
    }

    public class Confirmation_light
    {
        public string ID;
        public string Key;
        public string Description;
        public string Name;
        public ConfirmationType ConfType;

        public async Task<bool> Confirm()
        {
            await CSteamAuth.RefreshSessionIfNeed();
            Confirmation confirmation = new Confirmation() { Description = this.Description, ID = this.ID, Key = this.Key };
            return await CSteamAuth.steamGuardAccount.AcceptConfirmation(confirmation);
        }
        public async Task<bool> Deny()
        {
            await CSteamAuth.RefreshSessionIfNeed();
            Confirmation confirmation = new Confirmation() { Description = this.Description, ID = this.ID, Key = this.Key };
            return await CSteamAuth.steamGuardAccount.DenyConfirmation(confirmation);
        }
        public override string ToString()
        {
            return $"({Description}) {Name}";
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (!(obj is Confirmation_light || obj is Confirmation))
                return false;

            string id, key;

            if (obj is Confirmation_light)
            {
                id = (obj as Confirmation_light).ID;
                key = (obj as Confirmation_light).Key;
            }
            else
            {
                id = (obj as Confirmation).ID;
                key = (obj as Confirmation).Key;
            }

            if (id == this.ID && key == this.Key)
                return true;

            return false;
        }

        public enum ConfirmationType
        {
            GenericConfirmation = 0,
            Trade = 1,
            MarketSellTransaction = 2,
            Unknown = 3
        }
    }
    public enum CryptType
    {
        base64,
        ASCII
    }
    public enum SaveResult
    {
        Ok,
        IncorrectSecretCode,
        CryptoError,
        FileError
    }
    public enum FinalizeResult
    {
        BadSMSCode,
        UnableToGenerateCorrectCodes,
        Success,
        GeneralFailure,
        CantSaveAccountData,
        IncorrectSecretCode,
        FileError
    }
    public enum LinkResult
    {
        MustProvidePhoneNumber, //No phone number on the account
        MustRemovePhoneNumber, //A phone number is already on the account
        AwaitingFinalization, //Must provide an SMS code
        GeneralFailure, //General failure (really now!)
        AuthenticatorPresent
    }
    public static class Extensions
    {
        public static void Forget(this Task task) { }
    }
}
