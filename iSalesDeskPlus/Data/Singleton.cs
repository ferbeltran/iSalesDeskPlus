using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace iSalesDeskPlus.Data
{
    public class Singleton
    {
        private static Singleton instance;
        public static Singleton Instance => instance ?? (instance = new Singleton());

        private Singleton()
        {

        }

        public HttpClient HttpClient;

        public void InitHttpClient(string baseAddress = "https://csp1.isolvetech.net:4433/isolvesd.svc")
        {
            HttpClient = new HttpClient()
            {
                BaseAddress = new Uri(baseAddress),
                Timeout = TimeSpan.FromSeconds(5),
            };
        }
    }
}
