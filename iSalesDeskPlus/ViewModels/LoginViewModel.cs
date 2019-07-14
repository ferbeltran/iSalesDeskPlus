using System.Threading.Tasks;
using Acr.UserDialogs;
using iSalesDeskPlus.Utils;
using iSalesDeskPlus.Utils.Behaviors;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

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
                    ShowNoInternetToast();
                });
            }

            IsLoading = true;
            //Simulamos el inicio del Login

            await Task.Delay(1500);

            await NavigationService.NavigateAsync("app:///Tabs/NavigationPage/Inventory");

            IsLoading = false;
        }


    }
}
