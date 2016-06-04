using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SteamAuth;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace _2FAuthAndroidLibrary
{
    public class CSteamAuth
    {
        private UserLogin userLogin;
        private AuthenticatorLinker linker;
        private SteamGuardAccount steamGuardAccount;
        public string captchaGID;
        public const string SGAccountFile = "steamguard.json";
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
        public async Task<AuthenticatorLinker.LinkResult> Link(string phone=null)
        {
            if (linker._session == null)
                return AuthenticatorLinker.LinkResult.GeneralFailure;

            linker.PhoneNumber = phone;
            var res = await linker.AddAuthenticator().ConfigureAwait(false);

            return res;
        }
        public async Task<AuthenticatorLinker.FinalizeResult> FinalizeLink(string smscode)
        {
            if (string.IsNullOrEmpty(smscode) || smscode.Length != 5)
                return AuthenticatorLinker.FinalizeResult.BadSMSCode;

            var res = await linker.FinalizeAddAuthenticator(smscode).ConfigureAwait(true);
            if (res == AuthenticatorLinker.FinalizeResult.Success)
            {
                this.steamGuardAccount = linker.LinkedAccount;
                await steamGuardAccount.AlignTimeAsync().ConfigureAwait(true);
                SaveSGAccount();
            }

            return res;
        }
        public bool LoadAuthenticator()
        {
            if (!File.Exists(SGAccountFile))
                return false;

            var res = LoadSGAccount();
            steamGuardAccount = res;
            steamGuardAccount.AlignTime();

            return steamGuardAccount != null;
        } // Load steam guard account
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
        public async Task DeleteAuthenticator()
        {
            if (steamGuardAccount == null)
                return;
            await steamGuardAccount.DeactivateAuthenticator().ConfigureAwait(true);
        } 
        public string getRevocationCode()
        {
            if (steamGuardAccount == null)
                return "";
            return steamGuardAccount.RevocationCode;
        }
        public bool SaveSGAccount()
        {
            if (steamGuardAccount == null)
                return false;

            try
            {
                File.WriteAllText(SGAccountFile, JsonConvert.SerializeObject(steamGuardAccount));
            }
            catch (Exception e) { return false; }
            return true;
        } // Save steam guard account to file (SGAccountFile)
        private SteamGuardAccount LoadSGAccount()
        {
            SteamGuardAccount acc;
            try
            {
                acc = JsonConvert.DeserializeObject<SteamGuardAccount>(File.ReadAllText(SGAccountFile));
            }
            catch (Exception e) { return null; }
            return acc;
        } // Load steam guard account from file (SGAccountFile)
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
    }
}
