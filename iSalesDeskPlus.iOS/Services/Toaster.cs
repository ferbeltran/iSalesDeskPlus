using System.Runtime.CompilerServices;
using Foundation;
using iSalesDeskPlus.iOS.Services;
using iSalesDeskPlus.Services;
using UIKit;

namespace iSalesDeskPlus.iOS.Services
{
    public class Toaster : IToastService
    {
        const double LONG_DELAY = 4.0;
        const double SHORT_DELAY = 2.0;

        NSTimer alertDelay;
        UIAlertController alert;

        public void LongToast(string message)
        {
            ShowToast(message, LONG_DELAY);
        }
        public void ShortToast(string message)
        {
            ShowToast(message, SHORT_DELAY);
        }

        void ShowToast(string message, double seconds)
        {
            alertDelay = NSTimer.CreateScheduledTimer(seconds, (obj) =>
            {
                dismissMessage();
            });
            alert = UIAlertController.Create(null, message, UIAlertControllerStyle.Alert);
            UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(alert, true, null);
        }

        void dismissMessage()
        {
            if (alert != null)
            {
                alert.DismissViewController(true, null);
            }
            if (alertDelay != null)
            {
                alertDelay.Dispose();
            }
        }
    }
}
