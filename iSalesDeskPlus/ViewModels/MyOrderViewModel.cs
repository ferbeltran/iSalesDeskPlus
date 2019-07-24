using iSalesDeskPlus.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace iSalesDeskPlus.ViewModels
{
    public class MyOrderViewModel : ViewModelBase
    {
        public MyOrderViewModel(INavigationService navigationService, IToastService toastService) : base(navigationService, toastService)
        {
            Title = "My Order";
        }
    }
}
