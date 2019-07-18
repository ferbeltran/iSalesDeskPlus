using iSalesDeskPlus.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(NavigationPage), typeof(CleanNavigationBarRenderer))]
namespace iSalesDeskPlus.iOS.Renderers
{
    public class CleanNavigationBarRenderer : NavigationRenderer
    {
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            NavigationBar.ShadowImage = new UIImage();
        }
    }
}
