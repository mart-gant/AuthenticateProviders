using Xamarin.Forms;

namespace AuthenticateProviders
{
	public partial class App : Application
	{
		public App()
		{
			MainPage = new ProvidersAuthPage();
		}
	}
}
