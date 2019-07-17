using Foundation;
using iSalesDeskPlus.iOS.Services;
using iSalesDeskPlus.Services;
using Prism;
using Prism.Ioc;
using Syncfusion.SfCalendar.XForms.iOS;
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
            global::Xamarin.Forms.Forms.Init();
            SfCalendarRenderer.Init();
            FormsMaterial.Init();
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
