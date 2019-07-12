using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace iSalesDeskPlus.Styles
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SmallDevice : ResourceDictionary
    {
        public static SmallDevice Instance { get; } = new SmallDevice();
        public SmallDevice()
        {
            InitializeComponent();
        }
    }
}