namespace iSalesDeskPlus.Models
{
    using iSalesDeskPlus.Utils;
    using Microcharts;
    using SkiaSharp;
    using System.Collections.Generic;
    using Xamarin.Forms;

    public class Product
    {
        public int WhsePK { get; set; }

        public string WhseCode { get; set; }

        public int CommodityPK { get; set; }

        public string CommodityCode { get; set; }

        public int VarietyPK { get; set; }

        public string VarietyCode { get; set; }

        public int PackStylePK { get; set; }

        public string PackStyleCode { get; set; }

        public int SizePK { get; set; }

        public string SizeCode { get; set; }

        public int SizeOrder { get; set; }

        public int LabelPK { get; set; }

        public string LabelCode { get; set; }

        public int GradePK { get; set; }

        public string GradeCode { get; set; }

        public int Physical { get; set; }

        public int Received { get; set; }

        public int InTransit { get; set; }

        public int Shipped { get; set; }

        public int Orders { get; set; }

        public int Available { get; set; }

        public string PriceRange { get; set; }

        public double Price { get; set; }

        public int Hold { get; set; }

        /// <summary>
        /// Propiedades Locales
        /// </summary>

        public string Title { get => $"{CommodityCode} {VarietyCode}"; }
        public string Subtitle { get => $"{PackStyleCode} {SizeCode} {LabelCode} {GradeCode}"; }

        public Color Color { get; set; }

        public LineChart Chart { get; set; }



    }

    public static class Mock
    {
        public static List<Product> Products = new List<Product>()
        {
            new Product()
            {
               WhseCode = "01", CommodityCode = "TOM", VarietyCode = "ROMA", PackStyleCode = "TO25", SizeCode = "XLG", LabelCode = "GEN", GradeCode = "NON", Color = Color.MediumVioletRed,
               Physical = 600, Received = 0, InTransit = 120, Shipped = 60, Orders = 300, Available = 240,
                Chart = new LineChart() {  BackgroundColor = new SKColor(0,0,0,0),
                                           Entries = new List<ChartEntry>() {
                                                                              new ChartEntry(100) { Color = SKColor.Parse("#03abc3"), Label="Ava", TextColor = SKColor.Parse("#000000"), ValueLabel="100"  },
                                                                              new ChartEntry(20)  { Color = SKColor.Parse("#03abc3"), Label="Ord", TextColor = SKColor.Parse("#000000"), ValueLabel="20" },
                                                                              new ChartEntry(60)  { Color = SKColor.Parse("#03abc3"), Label="Phy", TextColor = SKColor.Parse("#000000"), ValueLabel="60" },
                                                                              new ChartEntry(200) { Color = SKColor.Parse("#03abc3"), Label="Shp", TextColor = SKColor.Parse("#000000"), ValueLabel="200" },
                                                                            },

                }
            },

               new Product()
            {
               WhseCode = "01", CommodityCode = "TOM", VarietyCode = "ROMA", PackStyleCode = "TO25", SizeCode = "LGE", LabelCode = "GEN", GradeCode = "NON", Color = Color.ForestGreen,
               Physical = 600, Received = 0, InTransit = 120, Shipped = 60, Orders = 300, Available = 240, Chart = new LineChart() {
                   Entries = new List<ChartEntry>() {
                                                       new ChartEntry(30) { Color = SKColor.Parse("#03abc3"), Label="Ava", TextColor = SKColor.Parse("#000000"), ValueLabel = "30"  },
                                                       new ChartEntry(80)  { Color = SKColor.Parse("#03abc3"), Label="Ord", TextColor = SKColor.Parse("#000000"), ValueLabel="80" },
                                                       new ChartEntry(240)  { Color = SKColor.Parse("#03abc3"), Label="Phy", TextColor = SKColor.Parse("#000000"), ValueLabel="240" },
                                                       new ChartEntry(10) { Color = SKColor.Parse("#03abc3"), Label="Shp", TextColor = SKColor.Parse("#000000"), ValueLabel="100" },
               }, BackgroundColor = new SKColor(0,0,0,0) }
               },
             new Product()
            {
               WhseCode = "01", CommodityCode = "TOM", VarietyCode = "ROMA", PackStyleCode = "119B", SizeCode = "XLG", LabelCode = "GEN", GradeCode = "NON", Color = Color.DeepSkyBlue,
               Physical = 600, Received = 0, InTransit = 120, Shipped = 60, Orders = 300, Available = 240, Chart = new LineChart() { Entries = new List<ChartEntry>() {
                                                       new ChartEntry(60)  { Color = SKColor.Parse("#03abc3"), Label="Ava", TextColor = SKColor.Parse("#000000"), ValueLabel = "60"  },
                                                       new ChartEntry(60)  { Color = SKColor.Parse("#03abc3"), Label="Ord", TextColor = SKColor.Parse("#000000"), ValueLabel = "60"  },
                                                       new ChartEntry(30)  { Color = SKColor.Parse("#03abc3"), Label="Phy", TextColor = SKColor.Parse("#000000"), ValueLabel = "30"  },
                                                       new ChartEntry(120) { Color = SKColor.Parse("#03abc3"), Label="Shp", TextColor = SKColor.Parse("#000000"), ValueLabel = "120" },
               }, BackgroundColor = new SKColor(0,0,0,0)  }
            },
             new Product()
            {
               WhseCode = "01", CommodityCode = "TOM", VarietyCode = "ROMA", PackStyleCode = "119B", SizeCode = "MED", LabelCode = "GEN", GradeCode = "NON", Color = Color.OrangeRed,
               Physical = 600, Received = 0, InTransit = 120, Shipped = 60, Orders = 300, Available = 240, Chart = new LineChart() { Entries = new List<ChartEntry>() {
                                                       new ChartEntry(120)  { Color = SKColor.Parse("#03abc3"), Label="Ava", TextColor = SKColor.Parse("#000000"), ValueLabel = "120"  },
                                                       new ChartEntry(50)  { Color = SKColor.Parse("#03abc3"), Label="Ord", TextColor = SKColor.Parse("#000000"), ValueLabel = "50"  },
                                                       new ChartEntry(10)  { Color = SKColor.Parse("#03abc3"), Label="Phy", TextColor = SKColor.Parse("#000000"), ValueLabel = "10"  },
                                                       new ChartEntry(100) { Color = SKColor.Parse("#03abc3"), Label="Shp", TextColor = SKColor.Parse("#000000"), ValueLabel = "100" },
               }, BackgroundColor = new SKColor(0,0,0,0)  }
            },
            //  new Product()
            //{
            //   WhseCode = "01", CommodityCode = "TOM", VarietyCode = "ROMA", PackStyleCode = "199B", SizeCode = "SML", LabelCode = "GEN", GradeCode = "NON", Color = Color.RosyBrown,
            //   Physical = 600, Received = 0, InTransit = 120, Shipped = 60, Orders = 300, Available = 240, Chart = new LineChart() { Entries = new List<ChartEntry>() {
            //       new ChartEntry(40) { Color = SKColor.Parse("#03abc3") },
            //       new ChartEntry(50) { Color = SKColor.Parse("#03abc3") },
            //       new ChartEntry(120) { Color = SKColor.Parse("#03abc3") },
            //   }, BackgroundColor = new SKColor(0,0,0,0)  }
            //},
        };
    }
}
