using System;
using iSalesDeskPlus.Services;
using iSalesDeskPlus.Styles;
using Prism.Commands;
using Prism.Navigation;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace iSalesDeskPlus.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        public SettingsViewModel(INavigationService navigationService, IToastService toastService) : base(navigationService, toastService)
        {
            Title = "Settings";
        }

        private bool isDarkModeEnabled = Preferences.Get("isDarkModeEnabled", false);
        public bool IsDarkModeEnabled
        {
            get => isDarkModeEnabled;
            set
            {
                SetProperty(ref isDarkModeEnabled, value);
                Preferences.Set("isDarkModeEnabled", value);
                App.SetAppColors(value);
            }
        }


        private DelegateCommand logoutCommand;
        public DelegateCommand LogoutCommand =>
            logoutCommand ?? (logoutCommand = new DelegateCommand(LogoutFromApp));

        async void LogoutFromApp()
        {
            Preferences.Set("isLogged", false);
            await NavigationService.NavigateAsync("app:///LoginGradient");

            //Todo: Clear Preferences
        }
    }
}
