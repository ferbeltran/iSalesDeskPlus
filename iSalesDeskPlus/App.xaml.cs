﻿using Prism;
using Prism.Ioc;
using iSalesDeskPlus.ViewModels;
using iSalesDeskPlus.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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

            await NavigationService.NavigateAsync("TabbedLogins");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<Login, LoginViewModel>();
            containerRegistry.RegisterForNavigation<NewLogin, LoginViewModel>();
            containerRegistry.RegisterForNavigation<MergedLogin, LoginViewModel>();
            containerRegistry.RegisterForNavigation<TabbedLogins>();
      
        }
    }
}
