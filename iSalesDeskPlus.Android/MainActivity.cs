using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using iSalesDeskPlus.Droid.Services;
using iSalesDeskPlus.Services;
using Prism;
using Prism.Ioc;
using Xamarin.Forms;
using Xfx;

namespace iSalesDeskPlus.Droid
{
    [Activity(Label = "iSalesDesk+", Icon = "@mipmap/ic_launcher", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
            Xamarin.Essentials.Platform.Init(this, bundle);
            XfxControls.Init();

            global::Xamarin.Forms.Forms.Init(this, bundle);

            AiForms.Renderers.Droid.SettingsViewInit.Init();
            FormsMaterial.Init(this, bundle);
            LoadApplication(new App(new AndroidInitializer()));


        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }

    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IToastService, Toaster>();
        }
    }

  
}

