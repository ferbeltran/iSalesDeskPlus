using Newtonsoft.Json;
using System;

namespace iSalesDeskPlus.Models
{
    public class User
    {
        [JsonProperty("UserPK")]
        public int PK { get; set; }

        public string Email { get; set; }

        [JsonIgnore]
        public string Password { get; set; }

        [JsonProperty("ExpirationDate")]
        public DateTime TokenExpirationDate { get; set; }

        [JsonProperty("Login")]
        public string Username { get; set; }

        public string Name { get; set; }

        public string CustomerName { get; set; }

        [JsonProperty("Password")]
        public string EncryptedPassword { get; set; }

        public string Token { get; set; }

        [JsonProperty("WebApiUrl")]
        public string WebApiUri { get; set; }
    }
}
