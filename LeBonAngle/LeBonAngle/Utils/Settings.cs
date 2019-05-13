using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace ListingOgGang.Utils
{
    public static class Settings
    {
        public static string UserID
        {
            get
            {
                return Preferences.Get("UserID", "");
            }
            set
            {
                Preferences.Set("UserID", value);
            }
        }
        public static string Login
        {
            get
            {
                return Preferences.Get("Login", "");
            }
            set
            {
                Preferences.Set("Login", value);
            }
        }

        public static string Pwd
        {
            get
            {
                return Preferences.Get("Pwd", "");
            }
            set
            {
                Preferences.Set("Pwd", value);
            }
        }

        public static string TokenAPI
        {
            get
            {
                return Preferences.Get("TokenAPI", "");
            }
            set
            {
                Preferences.Set("TokenAPI", value);
            }
        }

        public static bool IsUserConnected
        {
            get
            {
                if (!String.IsNullOrWhiteSpace(Login) 
                    && !String.IsNullOrWhiteSpace(Pwd) 
                    && !String.IsNullOrWhiteSpace(TokenAPI))
                {
                    return true;
                }
                return false;
            }
        }

    }
}
