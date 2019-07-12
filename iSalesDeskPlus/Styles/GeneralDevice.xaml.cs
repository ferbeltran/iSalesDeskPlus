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
    public partial class GeneralDevice : ResourceDictionary
    {

        public static GeneralDevice Instance { get; } = new GeneralDevice();

        public GeneralDevice()
        {
            InitializeComponent();
        }
    }
}