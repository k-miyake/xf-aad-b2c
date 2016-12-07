using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace xfb2capp
{
    // 認証インタフェース
    public interface IAuthenticate
    {
        Task<bool> Authenticate();
    }

    public class App : Application
	{
        public static IAuthenticate Authenticator { get; private set; }

        // 認証インターフェイスをプラットフォーム固有の実装で初期化
        public static void Init(IAuthenticate authenticator)
        {
            Authenticator = authenticator;
        }

        public App ()
		{
			// The root page of your application
			MainPage = new TodoList();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

