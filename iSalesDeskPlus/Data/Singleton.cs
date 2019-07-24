using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;

namespace iSalesDeskPlus.Data
{
    public class Singleton
    {
        private static Singleton instance;
        public static Singleton Instance => instance ?? (instance = new Singleton());

        private Singleton()
        {

        }
    }
}
