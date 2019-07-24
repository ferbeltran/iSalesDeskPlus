using iSalesDeskPlus.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace iSalesDeskPlus.ViewModels
{
    public class InventoryViewModel : ViewModelBase
    {
        public InventoryViewModel(INavigationService navigationService, IToastService toastService) : base(navigationService, toastService)
        {
            Title = "Inventory";
        }

        private DateTime date = DateTime.Now;
        public DateTime Date
        {
            get { return date; }
            set { SetProperty(ref date, value); }
        }
    }
}
