using AiForms.Effects.iOS;
using AiForms.Renderers.iOS;
using CarouselView.FormsPlugin.iOS;
using Foundation;
using iSalesDeskPlus.iOS.Services;
using iSalesDeskPlus.Services;
using Prism;
using Prism.Ioc;
using UIKit;
using Xamarin.Forms;
using Xfx;

namespace iSalesDeskPlus.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            XfxControls.Init();
            Forms.SetFlags("CollectionView_Experimental");
            global::Xamarin.Forms.Forms.Init();

            CarouselViewRenderer.Init();
            FormsMaterial.Init();
            SettingsViewInit.Init();
            Effects.Init();
           

            //Le damos estilo al TabBar
            UITabBar.Appearance.BackgroundImage = new UIImage();
            UITabBar.Appearance.ShadowImage = new UIImage();
            UITabBar.Appearance.BarTintColor = UIColor.Clear;

            //UIApplication.SharedApplication.SetStatusBarStyle(UIStatusBarStyle.LightContent, false);
            //UIApplication.SharedApplication.SetStatusBarHidden(false, false);

            LoadApplication(new App(new iOSInitializer()));
            return base.FinishedLaunching(app, options);
        }
    }

    public class iOSInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IToastService, Toaster>();
        }
    }
}
