using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Net.NetworkInformation;

namespace SteamAuth
{
    public class SteamGuardAccount
    {
        [JsonProperty("shared_secret")]
        public string SharedSecret { get; set; } // Must be crypted (base64 string)
        [JsonProperty("serial_number")]
        public string SerialNumber { get; set; }
        [JsonProperty("revocation_code")]
        public string RevocationCode { get; set; }
        [JsonProperty("uri")]
        public string URI { get; set; }
        [JsonProperty("server_time")]
        public long ServerTime { get; set; }
        [JsonProperty("account_name")]
        public string AccountName { get; set; }
        [JsonProperty("token_gid")]
        public string TokenGID { get; set; }
        [JsonProperty("identity_secret")]
        public string IdentitySecret { get; set; } // Must be crypted (base64 string)
        [JsonProperty("secret_1")]
        public string Secret1 { get; set; }
        [JsonProperty("status")]
        public int Status { get; set; }
        [JsonProperty("device_id")]
        public string DeviceID { get; set; }
        [JsonProperty("timeDiff")]
        private long timeDiference { get; set; } = 0;
        [JsonProperty]
        public SessionData Session { get; set; }
        /// <summary>
        /// Set to true if the authenticator has actually been applied to the account.
        /// </summary>
        [JsonProperty("fully_enrolled")]
        public bool FullyEnrolled { get; set; }

        [JsonIgnore]
        public bool NetAvailable = false;
        [JsonIgnore]
        public int secret;
        private static byte[] steamGuardCodeTranslations = new byte[] { 50, 51, 52, 53, 54, 55, 56, 57, 66, 67, 68, 70, 71, 72, 74, 75, 77, 78, 80, 81, 82, 84, 86, 87, 88, 89 };

        public SteamGuardAccount() { }
        public SteamGuardAccount(SteamGuardAccount acc)
        {
            this.AccountName = acc.AccountName;
            this.DeviceID = acc.DeviceID;
            this.FullyEnrolled = acc.FullyEnrolled;
            this.IdentitySecret = acc.IdentitySecret;
            this.NetAvailable = acc.NetAvailable;
            this.secret = acc.secret;
            this.Secret1 = acc.Secret1;
            this.SerialNumber = acc.SerialNumber;
            this.RevocationCode = acc.RevocationCode;
            this.ServerTime = acc.ServerTime;
            this.Session = new SessionData(acc.Session);
            this.SharedSecret = acc.SharedSecret;
            this.Status = acc.Status;
            this.timeDiference = acc.timeDiference;
            this.TokenGID = acc.TokenGID;
            this.URI = acc.URI;
        }
        public async Task<bool> DeactivateAuthenticator(int scheme = 2)
        {
            var postData = new NameValueCollection();
            postData.Add("steamid", this.Session.SteamID.ToString());
            postData.Add("steamguard_scheme", scheme.ToString());
            postData.Add("revocation_code", this.RevocationCode.Substring(1));
            postData.Add("access_token", this.Session.OAuthToken);

            try
            {
                string response = await SteamWeb.MobileLoginRequest(APIEndpoints.STEAMAPI_BASE + "/ITwoFactorService/RemoveAuthenticator/v0001", "POST", postData).ConfigureAwait(true);
                var removeResponse = JsonConvert.DeserializeObject<RemoveAuthenticatorResponse>(response);

                if (removeResponse == null || removeResponse.Response == null || !removeResponse.Response.Success) return false;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public string GenerateSteamGuardCode()
        {
            long time;
            AlignTime();
            time = Util.GetSystemUnixTime() + timeDiference;

            return GenerateSteamGuardCodeForTime(time);
        }
        public async Task<string> GenerateSteamGuardCodeAsync()
        {
            long time;
            await AlignTimeAsync().ConfigureAwait(true);
            time = Util.GetSystemUnixTime() + timeDiference;
            
            return GenerateSteamGuardCodeForTime(time);
        }
        public void AlignTime()
        {
            CheckInternet();
            if (NetAvailable)
                this.timeDiference = (long)(Util.GetSystemUnixTime() - TimeAligner.GetSteamTime());
        }
        public async Task AlignTimeAsync()
        {
            CheckInternet();
            if (NetAvailable)
                this.timeDiference = (long)(await TimeAligner.GetSteamTimeAsync().ConfigureAwait(true) - Util.GetSystemUnixTime());
        }
        public void CheckInternet()
        {
            string dns = "8.8.8.8";
            Ping p = new Ping();
            var pr = p.Send(dns,150);
            if (pr.Status == IPStatus.Success)
                NetAvailable = true;
            else
                NetAvailable = false;
        }
        public string GenerateSteamGuardCodeForTime(long time)
        {
            if (this.SharedSecret == null || this.SharedSecret.Length == 0)
                return "";

            string sharedSecretUnescaped = Regex.Unescape(this.SharedSecret);
            byte[] sharedSecretArray = Convert.FromBase64String(sharedSecretUnescaped);
            byte[] timeArray = new byte[8];

            time /= 30L;

            for (int i = 8; i > 0; i--)
            {
                timeArray[i - 1] = (byte)time;
                time >>= 8;
            }
            HMACSHA1 hmacGenerator = new HMACSHA1();
            hmacGenerator.Key = sharedSecretArray;
            byte[] hashedData = hmacGenerator.ComputeHash(timeArray);
            byte[] codeArray = new byte[5];
            try
            {
                byte b = (byte)(hashedData[19] & 0xF);
                int codePoint = (hashedData[b] & 0x7F) << 24 | (hashedData[b + 1] & 0xFF) << 16 | (hashedData[b + 2] & 0xFF) << 8 | (hashedData[b + 3] & 0xFF);

                for (int i = 0; i < 5; ++i)
                {
                    codeArray[i] = steamGuardCodeTranslations[codePoint % steamGuardCodeTranslations.Length];
                    codePoint /= steamGuardCodeTranslations.Length;
                }
            }
            catch (Exception)
            {
                return null; //Change later, catch-alls are bad!
            }
            return Encoding.UTF8.GetString(codeArray,0,codeArray.Length);
        }
        public async Task<int> GetLeftTime()
        {
            if (NetAvailable)
                return (int)(await TimeAligner.GetSteamTimeAsync().ConfigureAwait(true) % 30);
            else
                return (int)((Util.GetSystemUnixTime() + timeDiference) % 30);
        }
        public Confirmation[] FetchConfirmations()
        {
            string url = this.GenerateConfirmationURL();

            CookieContainer cookies = new CookieContainer();
            this.Session.AddCookies(cookies);

            string response = SteamWeb.Request(url, "GET", null, cookies);

            /*So you're going to see this abomination and you're going to be upset.
              It's understandable. But the thing is, regex for HTML -- while awful -- makes this way faster than parsing a DOM, plus we don't need another library.
              And because the data is always in the same place and same format... It's not as if we're trying to naturally understand HTML here. Just extract strings.
              I'm sorry. */

            Regex confIDRegex = new Regex("data-confid=\"(\\d+)\"");
            Regex confKeyRegex = new Regex("data-key=\"(\\d+)\"");
            Regex confDescRegex = new Regex("<div>((Confirm|Trade with|Sell -) .+)</div>");
            Regex confNameRegex = new Regex("<div>(.+\\(.+\\))</div>");

            if (string.IsNullOrEmpty(response) || !(confIDRegex.IsMatch(response) && confKeyRegex.IsMatch(response) && confDescRegex.IsMatch(response)))
            {
                if (!string.IsNullOrEmpty(response) && response.Contains("<div>Oh nooooooes!</div>"))
                {
                    _2FAuthAndroidLibrary.Logging.LogError("Steam server cant get confirmations page.");
                    return new Confirmation[0];
                }
                else if (!string.IsNullOrEmpty(response) && !response.Contains("<div>Nothing to confirm</div>"))
                {
                    _2FAuthAndroidLibrary.Logging.LogError("Sometinhs strange with confirmations response: (" + response + ")");
                    return new Confirmation[0];
                }
                return new Confirmation[0];
            }

            MatchCollection confIDs = confIDRegex.Matches(response);
            MatchCollection confKeys = confKeyRegex.Matches(response);
            MatchCollection confDescs = confDescRegex.Matches(response);
            MatchCollection confNames = confNameRegex.Matches(response);

            List<Confirmation> ret = new List<Confirmation>();
            for (int i = 0; i < confIDs.Count; i++)
            {
                string confID = confIDs[i].Groups[1].Value;
                string confKey = confKeys[i].Groups[1].Value;
                string confDesc = confDescs[i].Groups[1].Value;
                string confName = "Trade";
                if (confNames.Count > 0)
                    confName = confNames[i].Groups[1].Value;


                Confirmation conf = new Confirmation()
                {
                    Description = confDesc,
                    ID = confID,
                    Key = confKey,
                    Name = confName
                };
                ret.Add(conf);
            }

            return ret.ToArray();
        }
        public async Task<Confirmation[]> FetchConfirmationsAsync()
        {
            string url = this.GenerateConfirmationURL();

            CookieContainer cookies = new CookieContainer();
            this.Session.AddCookies(cookies);

            string response = "";
            for (byte i = 0; i < 3 && string.IsNullOrEmpty(response); i++)
                response = await SteamWeb.RequestAsync(url, "GET", null, cookies);

            /*
             <div class="mobileconf_list_entry_description">
			    <div>Sell - Market Listing</div>
			    <div>Wandering Zombie 5 pуб. (4,36 pуб.)</div>
			    <div>20 hours ago</div>
		    </div>
             */

            /*So you're going to see this abomination and you're going to be upset.
              It's understandable. But the thing is, regex for HTML -- while awful -- makes this way faster than parsing a DOM, plus we don't need another library.
              And because the data is always in the same place and same format... It's not as if we're trying to naturally understand HTML here. Just extract strings.
              I'm sorry. */
            Regex confInfoRegex = new Regex("<div class=\"mobileconf_list_entry\" id=\"\\w+\" data-confid=\"(\\d+)\" data-key=\"(\\d+)\"");
            Regex confDescRegex = new Regex("<div>((Confirm|Trade with|Sell -) .+)</div>");
            Regex confNameRegex = new Regex("<div>(.+\\(.+\\))</div>");
            /*
            Regex confIDRegex = new Regex("data-confid=\"(\\d+)\"");
            Regex confKeyRegex = new Regex("data-key=\"(\\d+)\"");
            Regex confDescRegex = new Regex("<div>((Confirm|Trade with|Sell -) .+)</div>");
            Regex confNameRegex = new Regex("<div>(.+\\(.+\\))</div>");
            */
            if (string.IsNullOrEmpty(response) || !(confInfoRegex.IsMatch(response) && confDescRegex.IsMatch(response)))
            {
                if(!string.IsNullOrEmpty(response) && response.Contains("<div>Oh nooooooes!</div>"))
                {
                    _2FAuthAndroidLibrary.Logging.LogError("Steam server cant get confirmations page.");
                    return new Confirmation[0];
                }
                else if (!string.IsNullOrEmpty(response) && !response.Contains("<div>Nothing to confirm</div>"))
                {
                    _2FAuthAndroidLibrary.Logging.LogError("Sometinhs strange with pendings response: (" + response + ")");
                    return new Confirmation[0];
                }
                return new Confirmation[0];
            }

            MatchCollection confInfos = confInfoRegex.Matches(response);
            MatchCollection confDescs = confDescRegex.Matches(response);
            MatchCollection confNames = confNameRegex.Matches(response);

            List<Confirmation> ret = new List<Confirmation>();
            for (int i = 0; i < confInfos.Count; i++)
            {
                string confID = confInfos[i].Groups[1].Value;
                string confKey = confInfos[i].Groups[2].Value;
                string confDesc = confDescs[i].Groups[1].Value;
                string confName = "Trade";
                if (confNames.Count > 0)
                    confName = confNames[i].Groups[1].Value;


                Confirmation conf = new Confirmation()
                {
                    Description = confDesc,
                    ID = confID,
                    Key = confKey,
                    Name = confName
                };
                ret.Add(conf);
            }

            return ret.ToArray();
        }
        public long GetConfirmationTradeOfferID(Confirmation conf)
        {
            var confDetails = _getConfirmationDetails(conf);
            if (confDetails == null || !confDetails.Success) return -1;

            Regex tradeOfferIDRegex = new Regex("<div class=\"tradeoffer\" id=\"tradeofferid_(\\d+)\" >");
            if (!tradeOfferIDRegex.IsMatch(confDetails.HTML)) return -1;
            return long.Parse(tradeOfferIDRegex.Match(confDetails.HTML).Groups[1].Value);
        }
        public async Task<bool> AcceptConfirmation(Confirmation conf)
        {
            return await _sendConfirmationAjaxAsync(conf, "allow");
        }
        public async Task<bool> DenyConfirmation(Confirmation conf)
        {
            return await _sendConfirmationAjaxAsync(conf, "cancel");
        }
        /// <summary>
        /// Refreshes the Steam session. Necessary to perform confirmations if your session has expired or changed.
        /// </summary>
        /// <returns></returns>
        public bool RefreshSession()
        {
            CheckInternet();
            if (NetAvailable == false)
                return false;

            string url = APIEndpoints.MOBILEAUTH_GETWGTOKEN;
            var postData = new NameValueCollection();
            postData.Add("access_token", this.Session.OAuthToken);

            string response = SteamWeb.Request(url, "POST", postData);
            if (response == null) return false;

            try
            {
                var refreshResponse = JsonConvert.DeserializeObject<RefreshSessionDataResponse>(response);
                if (refreshResponse == null || refreshResponse.Response == null || string.IsNullOrEmpty(refreshResponse.Response.Token))
                    return false;

                string token = this.Session.SteamID + "%7C%7C" + refreshResponse.Response.Token;
                string tokenSecure = this.Session.SteamID + "%7C%7C" + refreshResponse.Response.TokenSecure;

                this.Session.SteamLogin = token;
                this.Session.SteamLoginSecure = tokenSecure;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// Refreshes the Steam session. Necessary to perform confirmations if your session has expired or changed.
        /// </summary>
        /// <returns></returns>
        public async Task<bool> RefreshSessionAsync()
        {
            CheckInternet();
            if (NetAvailable == false)
                return false;

            string url = APIEndpoints.MOBILEAUTH_GETWGTOKEN;
            var postData = new NameValueCollection();
            postData.Add("access_token", this.Session.OAuthToken);

            string response = await SteamWeb.RequestAsync(url, "POST", postData).ConfigureAwait(true);
            if (response == null) return false;

            try
            {
                var refreshResponse = JsonConvert.DeserializeObject<RefreshSessionDataResponse>(response);
                if (refreshResponse == null || refreshResponse.Response == null || String.IsNullOrEmpty(refreshResponse.Response.Token))
                    return false;

                string token = this.Session.SteamID + "%7C%7C" + refreshResponse.Response.Token;
                string tokenSecure = this.Session.SteamID + "%7C%7C" + refreshResponse.Response.TokenSecure;

                this.Session.SteamLogin = token;
                this.Session.SteamLoginSecure = tokenSecure;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        private ConfirmationDetailsResponse _getConfirmationDetails(Confirmation conf)
        {
            string url = APIEndpoints.COMMUNITY_BASE + "/mobileconf/details/" + conf.ID + "?";
            string queryString = GenerateConfirmationQueryParams("details");
            url += queryString;

            CookieContainer cookies = new CookieContainer();
            this.Session.AddCookies(cookies);
            string referer = GenerateConfirmationURL();

            string response = SteamWeb.Request(url, "GET", null, cookies, null);
            if (String.IsNullOrEmpty(response)) return null;

            var confResponse = JsonConvert.DeserializeObject<ConfirmationDetailsResponse>(response);
            if (confResponse == null) return null;
            return confResponse;
        }
        private async Task<bool> _sendConfirmationAjaxAsync(Confirmation conf, string op)
        {
            string url = APIEndpoints.COMMUNITY_BASE + "/mobileconf/ajaxop";
            string queryString = "?op=" + op + "&";
            queryString += GenerateConfirmationQueryParams(op);
            queryString += "&cid=" + conf.ID + "&ck=" + conf.Key;
            url += queryString;

            CookieContainer cookies = new CookieContainer();
            this.Session.AddCookies(cookies);
            string referer = GenerateConfirmationURL();

            string response = await SteamWeb.RequestAsync(url, "GET", null, cookies, null).ConfigureAwait(true);
            if (response == null) return false;

            SendConfirmationResponse confResponse = JsonConvert.DeserializeObject<SendConfirmationResponse>(response);
            return confResponse.Success;
        }
        private bool _sendConfirmationAjax(Confirmation conf, string op)
        {
            string url = APIEndpoints.COMMUNITY_BASE + "/mobileconf/ajaxop";
            string queryString = "?op=" + op + "&";
            queryString += GenerateConfirmationQueryParams(op);
            queryString += "&cid=" + conf.ID + "&ck=" + conf.Key;
            url += queryString;

            CookieContainer cookies = new CookieContainer();
            this.Session.AddCookies(cookies);
            string referer = GenerateConfirmationURL();

            string response = SteamWeb.Request(url, "GET", null, cookies, null);
            if (response == null) return false;

            SendConfirmationResponse confResponse = JsonConvert.DeserializeObject<SendConfirmationResponse>(response);
            return confResponse.Success;
        }
        public string GenerateConfirmationURL(string tag = "conf")
        {
            string endpoint = APIEndpoints.COMMUNITY_BASE + "/mobileconf/conf?";
            string queryString = GenerateConfirmationQueryParams(tag);
            return endpoint + queryString;
        }
        public string GenerateConfirmationQueryParams(string tag)
        {
            if (string.IsNullOrEmpty(DeviceID))
            {

                _2FAuthAndroidLibrary.Logging.LogError("Device ID is not present");
#if DEBUG
                throw new ArgumentException("Device ID is not present");
#endif

            }

            long time = TimeAligner.GetSteamTime();
            return "p=" + this.DeviceID + "&a=" + this.Session.SteamID.ToString() + "&k=" + _generateConfirmationHashForTime(time, tag) + "&t=" + time + "&m=android&tag=" + tag;
        }
        private string _generateConfirmationHashForTime(long time, string tag)
        {
            byte[] decode;
            try
            {
                decode = Convert.FromBase64String(this.IdentitySecret);
            } catch (Exception) { return null; }
            int n2 = 8;
            if (tag != null)
            {
                if (tag.Length > 32)
                {
                    n2 = 8 + 32;
                }
                else
                {
                    n2 = 8 + tag.Length;
                }
            }
            byte[] array = new byte[n2];
            int n3 = 8;
            while (true)
            {
                int n4 = n3 - 1;
                if (n3 <= 0)
                {
                    break;
                }
                array[n4] = (byte)time;
                time >>= 8;
                n3 = n4;
            }
            if (tag != null)
            {
                Array.Copy(Encoding.UTF8.GetBytes(tag), 0, array, 8, n2 - 8);
            }

            try
            {
                HMACSHA1 hmacGenerator = new HMACSHA1();
                hmacGenerator.Key = decode;
                byte[] hashedData = hmacGenerator.ComputeHash(array);
                string encodedData = Convert.ToBase64String(hashedData);
                string hash = WebUtility.UrlEncode(encodedData);
                return hash;
            }
            catch (Exception)
            {
                return null; //Fix soon: catch-all is BAD!
            }
        }

        public class WGTokenInvalidException : Exception
        {
        }
        private class RefreshSessionDataResponse
        {
            [JsonProperty("response")]
            public RefreshSessionDataInternalResponse Response { get; set; }
            internal class RefreshSessionDataInternalResponse
            {
                [JsonProperty("token")]
                public string Token { get; set; }

                [JsonProperty("token_secure")]
                public string TokenSecure { get; set; }
            }
        }
        private class RemoveAuthenticatorResponse
        {
            [JsonProperty("response")]
            public RemoveAuthenticatorInternalResponse Response { get; set; }

            internal class RemoveAuthenticatorInternalResponse
            {
                [JsonProperty("success")]
                public bool Success { get; set; }
            }
        }
        private class SendConfirmationResponse
        {
            [JsonProperty("success")]
            public bool Success { get; set; }
        }
        private class ConfirmationDetailsResponse
        {
            [JsonProperty("success")]
            public bool Success { get; set; }

            [JsonProperty("html")]
            public string HTML { get; set; }
        }
    }
}
