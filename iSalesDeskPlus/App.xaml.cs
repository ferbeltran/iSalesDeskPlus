using Prism;
using Prism.Ioc;
using iSalesDeskPlus.ViewModels;
using iSalesDeskPlus.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using iSalesDeskPlus.Styles;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace iSalesDeskPlus
{
    public partial class App
    {
        const int smallWidthResolution = 768;
        const int smallHeightResolution = 1280;

        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            LoadDeviceStyles();

            await NavigationService.NavigateAsync("Login");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<Login, LoginViewModel>();
            containerRegistry.RegisterForNavigation<Tabs, TabsViewModel>();
            containerRegistry.RegisterForNavigation<NewLogin, LoginViewModel>();
            containerRegistry.RegisterForNavigation<Inventory, InventoryViewModel>();
            containerRegistry.RegisterForNavigation<Settings, SettingsViewModel>();
        }

        //Se calcula el tamano del dispositivo y se le asignan el ResourceDictionary acorde al mismo
        //Es un small device los iPhone 4,5 y SE. Asi como la mayoria de dispositivos Android con API 5.1 o inferiore
        private void LoadDeviceStyles()
        {
            if (IsASmallDevice())
                mainDictionary.MergedDictionaries.Add(SmallDevice.Instance);
            else
                mainDictionary.MergedDictionaries.Add(GeneralDevice.Instance);
        }

        public static bool IsASmallDevice()
        {
            // Get Metrics
            var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;

            // Width and height (in pixels)
            var width = mainDisplayInfo.Width;
            var height = mainDisplayInfo.Height;

            return (width <= smallWidthResolution && height <= smallHeightResolution);
        }
    }
}
