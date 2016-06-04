using System.Net;

namespace SteamAuth
{
    public class SessionData
    {
        public string SessionID { get; set; }

        public string SteamLogin { get; set; }

        public string SteamLoginSecure { get; set; }

        public string WebCookie { get; set; }

        public string OAuthToken { get; set; }

        public ulong SteamID { get; set; }

        public void AddCookies(CookieContainer cookies)
        {
            System.Uri url = new System.Uri("http://steamcommunity.com");
            cookies.Add(url,new Cookie("mobileClientVersion", "0 (2.1.3)", "/", ".steamcommunity.com")) ;
            cookies.Add(url,new Cookie("mobileClient", "android", "/", ".steamcommunity.com"));

            cookies.Add(url, new Cookie("steamid", SteamID.ToString(), "/", ".steamcommunity.com"));
            cookies.Add(url, new Cookie("steamLogin", SteamLogin, "/", ".steamcommunity.com")
            {
                HttpOnly = true
            });

            cookies.Add(url, new Cookie("steamLoginSecure", SteamLoginSecure, "/", ".steamcommunity.com")
            {
                HttpOnly = true,
                Secure = true
            });
            cookies.Add(url, new Cookie("Steam_Language", "english", "/", ".steamcommunity.com"));
            cookies.Add(url, new Cookie("dob", "", "/", ".steamcommunity.com"));
            cookies.Add(url, new Cookie("sessionid", this.SessionID, "/", ".steamcommunity.com"));
        }
    }
}
