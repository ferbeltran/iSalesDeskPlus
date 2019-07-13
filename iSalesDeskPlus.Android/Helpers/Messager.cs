using Android.App;
using Android.Widget;
using iSalesDeskPlus.Contracts;
using iSalesDeskPlus.Droid.Helpers;

[assembly: Xamarin.Forms.Dependency(typeof(Messager))]
namespace iSalesDeskPlus.Droid.Helpers
{
    public class Messager : IMessage
    {
        public void LongAlert(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Long).Show();
        }

        public void ShortAlert(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Short).Show();
        }
    }
}