using System;
using Refit;
using System.Threading.Tasks;
using iSalesDeskPlus.Models;

namespace iSalesDeskPlus.Contracts
{
    public interface ILoginService
    {
        [Get("/GetApiToken?login={email}&password={password}&appid=iSalesDesk&appver={version}")]
        Task<User> Login(string email, string password, string version);
    }
}
