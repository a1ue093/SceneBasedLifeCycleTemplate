using Foundation;
using System;
using UIKit;

namespace SceneBasedLifeCycleTemplate
{
    internal class Program : UIResponder, IUIApplicationDelegate, IUIWindowSceneDelegate
    {
        static void Main(string[] args)
        {
            UIApplication.Main(args, null, typeof(Program));
        }

        public UISceneConfiguration GetConfiguration(UIApplication application, UISceneSession connectingSceneSession, UISceneConnectionOptions options)
        {
            UISceneConfiguration configuration = new UISceneConfiguration("Default Configuration", connectingSceneSession.Role);
            configuration.DelegateType = typeof(Program);
            return configuration;
        }

        public void WillConnect(UIScene scene, UISceneSession session, UISceneConnectionOptions connectionOptions)
        {
            if (scene is not UIWindowScene windowScene)
            {
                return;
            }

            Game1 game = new Game1();
            UIWindow window = game.Services.GetService<UIWindow>();
            window.WindowScene = windowScene;
            game.Run();
        }
    }
}
