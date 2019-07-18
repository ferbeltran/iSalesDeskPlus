using System;
using iSalesDeskPlus.Services;
using Prism.Commands;
using Prism.Navigation;
using Xamarin.Essentials;

namespace iSalesDeskPlus.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        public SettingsViewModel(INavigationService navigationService, IToastService toastService) : base(navigationService, toastService)
        {
            Title = "Settings";
        }

        private bool isDarkModeEnabled = false;
        public bool IsDarkModeEnabled
        {
            get => isDarkModeEnabled;
            set => SetProperty(ref isDarkModeEnabled, value); 
        }

        private DelegateCommand logoutCommand;
        public DelegateCommand LogoutCommand =>
            logoutCommand ?? (logoutCommand = new DelegateCommand(LogoutFromApp));

        async void LogoutFromApp()
        {
            Preferences.Set("isLogged", false);
            await NavigationService.NavigateAsync("app:///NewLogin");

            //Todo: Clear Preferences
        }
    }
}
