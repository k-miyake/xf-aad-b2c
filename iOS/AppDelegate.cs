using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;
using Foundation;
using UIKit;

namespace xfb2capp.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate, IAuthenticate
    {
        // 認証ユーザ
        private MobileServiceUser user;

        public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();
			global::Xamarin.Forms.Forms.Init ();

			LoadApplication (new App ());

            // Authenticatorの初期化
            App.Init(this);

            return base.FinishedLaunching (app, options);
		}

        // Azure AD B2C認証
        public async Task<bool> Authenticate()
        {
            var success = false;
            var message = string.Empty;
            try
            {
                if (user == null)
                {
                    user = await TodoItemManager.DefaultManager.CurrentClient
                        .LoginAsync(UIApplication.SharedApplication.KeyWindow.RootViewController,
                        MobileServiceAuthenticationProvider.WindowsAzureActiveDirectory);
                    if (user != null)
                    {
                        message = string.Format("{0}として認証されています", user.UserId);
                        success = true;
                    }
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }

            // 認証後のメッセージ
            UIAlertView avAlert = new UIAlertView("サインイン状況", message, null, "OK", null);
            avAlert.Show();

            return success;
        }
    }
}

