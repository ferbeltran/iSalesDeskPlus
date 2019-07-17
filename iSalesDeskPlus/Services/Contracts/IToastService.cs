using System;
using System.Collections.Generic;
using System.Text;

namespace iSalesDeskPlus.Services
{
    public interface IToastService
    {
        void LongToast(string message);
        void ShortToast(string message);
    }
}
