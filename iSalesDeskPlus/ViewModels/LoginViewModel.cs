﻿using System.Threading.Tasks;
using iSalesDeskPlus.Contracts;
using iSalesDeskPlus.Data;
using iSalesDeskPlus.Utils;
using iSalesDeskPlus.Utils.Behaviors;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Refit;

namespace iSalesDeskPlus.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        public LoginViewModel(INavigationService navigationService) : base(navigationService)
        {

        }

        private string email = "fernando@isolveproduce.com";
        public string Email
        {
            get { return email; }
            set { SetProperty(ref email, value); }
        }

        private string password = "123";
        public string Password
        {
            get { return password; }
            set { SetProperty(ref password, value); }
        }

        private bool isLoading = false;
        public bool IsLoading
        {
            get { return isLoading; }
            set { SetProperty(ref isLoading, value); }
        }

        private AnimationType animation = AnimationType.Scale;
        public AnimationType Animation
        {
            get { return animation; }
            set { SetProperty(ref animation, value); }
        }

        private DelegateCommand loginCommand;
        public DelegateCommand LoginCommand =>
            loginCommand ?? (loginCommand = new DelegateCommand(async () => await HandleLogin(), () => (!string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password))))
                               .ObservesProperty(() => Email)
                               .ObservesProperty(() => Password);

        async Task HandleLogin()
        {
            Animation = IsNotConnected ? AnimationType.Shake : AnimationType.Scale;

            if (IsNotConnected)
            {
                Xamarin.Essentials.MainThread.BeginInvokeOnMainThread(() =>
                {
                    ShowToast();
                });
            }

            IsLoading = true;

            Singleton.Instance.InitHttpClient();
            var loginService = RestService.For<ILoginService>(Singleton.Instance.HttpClient);

            try
            {
                var loggedUser = await loginService.Login(Email, Password, "3.0.0");
                if (loggedUser != null && loggedUser.PK != 0)
                {
                    ShowToast("A webo ya te loggeaste!");
                }
            }
            catch
            {

            }

           
            //await NavigationService.NavigateAsync("app:///Tabs");

            IsLoading = false;
        }


    }
}
