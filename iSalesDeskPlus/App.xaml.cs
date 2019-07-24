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
using iSalesDeskPlus.Utils;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace iSalesDeskPlus
{
    public partial class App
    {
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            LoadDeviceStyles();

            INavigationResult result;

            result = Preferences.Get("isLogged", false) ? await NavigationService.NavigateAsync("Tabs") : await NavigationService.NavigateAsync("LoginGradient");

            if (!result.Success)
                SetMainPageFromException(result.Exception);
        }
      

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<Login, LoginViewModel>();
            containerRegistry.RegisterForNavigation<NewLogin, LoginViewModel>();
            containerRegistry.RegisterForNavigation<Settings, SettingsViewModel>();
            containerRegistry.RegisterForNavigation<Tabs, TabsViewModel>();
            containerRegistry.RegisterForNavigation<Inventory, InventoryViewModel>();


            containerRegistry.RegisterForNavigation<Orders, OrdersViewModel>();
            containerRegistry.RegisterForNavigation<LoginGradient, LoginViewModel>();
            containerRegistry.RegisterForNavigation<MyOrder, MyOrderViewModel>();
            containerRegistry.RegisterForNavigation<Welcome, WelcomeViewModel>();
            containerRegistry.RegisterForNavigation<Welcome, WelcomeViewModel>();
        }

        //Se calcula el tamano del dispositivo y se le asignan el ResourceDictionary acorde al mismo
        //Es un small device los iPhone 4,5 y SE. Asi como la mayoria de dispositivos Android con API 5.1 o inferiore
        private void LoadDeviceStyles()
        {
            //Cargamos el Tema de Colores de la App: Light/Dark
            SetAppColors(Preferences.Get("isDarkModeEnabled", false));
      

            //Le hacemos Merge con los Resources que afectan las fonts y paddings dependiendo del tamaño del dispositivo
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

            return (width <= Constants.smallWidthResolution && height <= Constants.smallHeightResolution);
        }

        public static void SetAppColors(bool isDarkTheme)
        {
            //Main Colors
            App.Current.Resources["BackgroundColor"] = isDarkTheme ? Constants.darkGrayColor : Constants.whiteColor;
            App.Current.Resources["PrimaryColor"] = isDarkTheme ? Color.FromHex("b0b4c4") : Color.FromHex("b0b4c4");
            App.Current.Resources["AccentColor"] = isDarkTheme ? Constants.accentPinkColor : Constants.accentPinkColor;
            App.Current.Resources["DarkPrimaryColor"] = isDarkTheme ? Constants.darkerGrayColor : Constants.lightGrayColor;

            //NavigationBar
            App.Current.Resources["NavigationBarColor"] = isDarkTheme ? Constants.darkGrayColor : Constants.whiteColor;
            App.Current.Resources["TitleColor"] = isDarkTheme ? Constants.lightOverDarkTextColor : Constants.darkOverLightTextColor;


            //TabBar Icons
            App.Current.Resources["TabBarColor"] = isDarkTheme ? Constants.darkGrayColor : Constants.whiteColor;
            App.Current.Resources["TabIconSelectedColor"] = isDarkTheme ? Constants.accentGreenColor : Constants.accentGreenColor;
            App.Current.Resources["TabIconUnselectedColor"] = isDarkTheme ? Constants.strongGrayColor : Constants.blueGrayColor;

            //Texts
            App.Current.Resources["TextColor"] = isDarkTheme ? Constants.lightOverDarkTextColor : Constants.darkOverLightTextColor;
            App.Current.Resources["DetailTextColor"] = isDarkTheme ? Color.PaleVioletRed : Constants.strongGrayColor;

            //SettingsView
            App.Current.Resources["SettingsViewBackgroundColor"] = isDarkTheme ? Constants.darkGrayColor : Constants.lightGrayColor;
            //App.Current.Resources["SettingsViewHeaderColor"] = isDarkTheme ? Constants.hardGrayColor : Constants.lightGrayColor;
            App.Current.Resources["SettingsViewCellBackgroundColor"] = isDarkTheme ? Constants.darkerGrayColor : Constants.whiteColor;
            App.Current.Resources["SettingsViewTextColor"] = isDarkTheme ? Constants.lightOverDarkTextColor : Constants.darkOverLightTextColor;
            App.Current.Resources["SettingsViewTextDetailColor"] = isDarkTheme ? Constants.accentPinkColor : Constants.mediumGrayColor;
            App.Current.Resources["SettingsViewFooterColor"] = isDarkTheme ? Constants.lightOverDarkTextColor : Constants.lightGrayColor;
            App.Current.Resources["SettingsViewHeaderTextColor"] = isDarkTheme ? Constants.lightOverDarkTextColor : Constants.strongGrayColor;

            //SearchBar
            //App.Current.Resources["SearchBarBackgroundColor"] = isDarkTheme ? Constants.darkGrayColor : Constants.lightGrayColor;
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
    }
}
 