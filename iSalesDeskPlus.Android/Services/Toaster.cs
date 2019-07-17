using Android.App;
using Android.Widget;
using iSalesDeskPlus.Services;
using iSalesDeskPlus.Droid.Services;

[assembly: Xamarin.Forms.Dependency(typeof(Toaster))]
namespace iSalesDeskPlus.Droid.Services
{
    public class Toaster : IToastService
    {
        public void ShortToast(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Short).Show();
        }
        
        public void LongToast(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Long).Show();
        }
       
    }
}