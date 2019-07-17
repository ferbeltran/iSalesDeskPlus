using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using iSalesDeskPlus.Models;
using Refit;

namespace iSalesDeskPlus.Services
{
   public static class LoginService
    {
        public static ILoginService loginService;
        static readonly string baseUrl = "https://csp1.isolvetech.net:4433/isolvesd.svc";

        public static ILoginService GetLoginService()
        {
            loginService = RestService.For<ILoginService>(baseUrl);
            return loginService;
        }
        
    }
}
