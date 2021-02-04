using AuthenticateProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AuthenticateProviders
{
    public class LoginPage : ContentPage
    {
        public OAuthSettings ProviderOAuthSettings { get; set; }
        public LoginPage(Provider provider)
        {
            ProviderOAuthSettings = ProviderManager.GetProviderOAuthSettings(provider);
        }
    }
}
