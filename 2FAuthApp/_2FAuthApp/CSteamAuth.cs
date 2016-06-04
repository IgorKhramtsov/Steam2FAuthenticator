using System;
using SteamAuth;
using System.Threading.Tasks;

namespace _2FAuthApp
{
    public class CSteamAuth
    {
        
        public enum resultLogin
        {
            OK = 0,
            BadCredentials = 3,
            needCaptcha = 4,
            need2FA = 5,
            needEmail = 6,
            tooManyFailedLogins = 7,
            unknown = 8
        }
        public CSteamAuth(string username, string pass)
        {
            
        }
        public resultLogin Login()
        {

        }
    }
}

