using iSalesDeskPlus.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(SearchBar), typeof(CleanSearchBarRenderer))]
namespace iSalesDeskPlus.iOS.Renderers
{
    public class CleanSearchBarRenderer : SearchBarRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.SearchBar> e)
        {
            base.OnElementChanged(e);
            var searchbar = (UISearchBar)Control;

            if (e.NewElement != null)
            {
                Foundation.NSString _searchField = new Foundation.NSString("searchField");
                var textFieldInsideSearchBar = (UITextField)searchbar.ValueForKey(_searchField);
                textFieldInsideSearchBar.BackgroundColor = new UIColor(224/255f, 224/255f, 224/255f, 1.0f);
                //textFieldInsideSearchBar.TextColor = UIColor.White;
                //searchbar.Layer.BackgroundColor = UIColor.Cyan.CGColor;
               
                //searchbar.TintColor = UIColor.Clear;
                //searchbar.BarTintColor = UIColor.Clear;
                //searchbar.Layer.CornerRadius = 20;
                //searchbar.Layer.BorderWidth = 0;
                //searchbar.Layer.BorderColor = UIColor.FromRGB(0, 73, 135).CGColor;
                //searchbar.ShowsCancelButton = false;
            }


        }
    }
}