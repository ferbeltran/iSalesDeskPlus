using Prism;
using Prism.Ioc;
using iSalesDeskPlus.ViewModels;
using iSalesDeskPlus.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using iSalesDeskPlus.Styles;
using iSalesDeskPlus.Services;
using System;
using Prism.Navigation;

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

            INavigationResult result;

            if (Preferences.Get("isLogged", false))
            {
                result = await NavigationService.NavigateAsync("Tabs");
            }
            else
            {
                result = await NavigationService.NavigateAsync("NewLogin");
            }
       

            if (!result.Success)
            {
                SetMainPageFromException(result.Exception);
            }
        }

        private void SetMainPageFromException(Exception ex)
        {
            var layout = new StackLayout
            {
                Padding = new Thickness(40)
            };
            layout.Children.Add(new Label
            {
                Text = ex?.GetType()?.Name ?? "Unknown Error encountered",
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center
            });

            layout.Children.Add(new ScrollView
            {
                Content = new Label
                {
                    Text = $"{ex}",
                    LineBreakMode = LineBreakMode.WordWrap
                }
            });

            MainPage = new ContentPage
            {
                Content = layout
            };
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<Login, LoginViewModel>();
            containerRegistry.RegisterForNavigation<NewLogin, LoginViewModel>();
            containerRegistry.RegisterForNavigation<Settings, SettingsViewModel>();
            containerRegistry.RegisterForNavigation<Tabs, TabsViewModel>();
            containerRegistry.RegisterForNavigation<Inventory, InventoryViewModel>();

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
