using System.Threading.Tasks;
using Acr.UserDialogs;
using iSalesDeskPlus.Utils;
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
        
        private DelegateCommand loginCommand;
        public DelegateCommand LoginCommand =>
            loginCommand ?? (loginCommand = new DelegateCommand(async () => await HandleLogin()));

        async Task HandleLogin()
        {
            var toastConfig = new ToastConfig("Toasting...");
            toastConfig.SetDuration(3000);
           
            await Task.Delay(1);
       

            ToastConfig.DefaultBackgroundColor = System.Drawing.Color.AliceBlue;
            ToastConfig.DefaultMessageTextColor = System.Drawing.Color.Red;
            ToastConfig.DefaultActionTextColor = System.Drawing.Color.DarkRed;
            ToastConfig.DefaultPosition = ToastPosition.Top;

            UserDialogs.Instance.Toast(toastConfig);
        }


    }
}
