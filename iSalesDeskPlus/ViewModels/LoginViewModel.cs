using System.Threading.Tasks;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace iSalesDeskPlus.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        public LoginViewModel(INavigationService navigationService) : base(navigationService)
        {
            LoginCommand = new DelegateCommand(HandleLogin);
        }
        private string email = "fernando@isolveproduce.com";
        public string Email
        {
            get { return email; }
            set { SetProperty(ref email, value); }
        }

        private string password = "";
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

        public DelegateCommand LoginCommand { get; set; }

        private async void HandleLogin()
        {
            IsLoading = true;

            await Task.Delay(2000);

            IsLoading = false;
        }


    }
}
