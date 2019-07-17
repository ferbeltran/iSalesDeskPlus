using System;
using iSalesDeskPlus.Services;
using Prism.Navigation;

namespace iSalesDeskPlus.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        public SettingsViewModel(INavigationService navigationService, IToastService toastService) : base(navigationService, toastService)
        {
        }
    }
}
