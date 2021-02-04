﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticateProviders
{
    public enum Provider
    {
        Unknown = 0,
        Facebook,
        Google
    }

    public static class ProviderManager
    {
        private static OAuthSettings FacebookOAuthSettings
        {
            get
            {
                return new OAuthSettings
                {
                    ClientId = "TWÓJ_ID_KLIENCKI",
                    ClientSecret = "TWOJE_HASŁO_KLIENCKIE",
                    AuthorizeUrl = "https://m.facebook.com/dialog/oauth/",
                    RedirectUrl = "http://www.facebook.com/connect/login_success.html",
                    AccessTokenUrl = "https://graph.facebook.com/v2.3/oauth/access_token",
                    Scopes = new List<string> {
            ""
          }
                };
            }
        }
        private static OAuthSettings GoogleOAuthSettings
        {
            get
            {
                return new OAuthSettings
                {
                    ClientId = "TWÓJ_ID_KLIENCKI",
                    ClientSecret = "TWOJE_HASŁO_KLIENCKIE",
                    AuthorizeUrl = "https://accounts.google.com/o/oauth2/auth",
                    RedirectUrl = "https://www.googleapis.com/plus/v1/people/me",
                    AccessTokenUrl = "https://accounts.google.com/o/oauth2/token",
                    Scopes = new List<string> {
            "openid"
          }
                };
            }
        }
        public static OAuthSettings GetProviderOAuthSettings(Provider provider)
        {
            switch (provider)
            {
                case Provider.Facebook:
                    {
                        return FacebookOAuthSettings;
                    }
                case Provider.Google:
                    {
                        return GoogleOAuthSettings;
                    }
            }
            return new OAuthSettings();
        }
    }
}
