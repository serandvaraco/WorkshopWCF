

namespace WCFDemoToken
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Security.Cryptography;
    using System.ServiceModel;
    using System.ServiceModel.Web;
    using System.Web;

    [ServiceContract(Namespace = "")]
    public class CatalogService
    {


        private void ValidateToken()
        {
            var key = HttpContext.Current.Request.Headers["__ACTIVATION__"];
            var keyDecode = Cipher.Base64Decode(key); 

            var json = Cipher.Decrypt(keyDecode, new RijndaelManaged(), System.Configuration.ConfigurationManager.AppSettings["KeyHash"]);
            var tokenProperties = JsonConvert.DeserializeObject<TokenProperties>(json);

            if (DateTime.UtcNow > tokenProperties.ExpiredDate)
                throw new TimeoutException("Token Expirado");
        }


        #region List products 
        readonly IList<Products> products = new List<Products>()
        {
            new Products { Name ="Product 1", Quantity = 2 },
            new Products { Name ="Product 2", Quantity = 1 },
            new Products { Name ="Product 3", Quantity = 6 },
            new Products { Name ="Product 4", Quantity = 8 },
            new Products { Name ="Product 5", Quantity = 9 },
            new Products { Name ="Product 6", Quantity = 0 },
            new Products { Name ="Product 7", Quantity = 12 },
            new Products { Name ="Product 8", Quantity = 23},
            new Products { Name ="Product 9", Quantity = 29 },
            new Products { Name ="Product 10", Quantity = 12 },
            new Products { Name ="Product 11", Quantity = 23 },
            new Products { Name ="Product 12", Quantity = 20 },

        };
        #endregion

        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, Method = "POST", UriTemplate = "GetProductsName/{name}")]
        public void GetProductsByname(string name)
        {
            ValidateToken();
            products.Where(x => x.Name == name);
        }

        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, Method = "POST", UriTemplate = "GetProductsbyTake")]
        public void GetProductsByTake(int quantity)
        {
            ValidateToken();
            products.Take(quantity);
        }

        [WebInvoke(ResponseFormat = WebMessageFormat.Json, Method = "POST", UriTemplate = "GetToken")]
        [OperationContract]
        public string GetToken()
        {
            var token = new TokenProperties { ExpiredDate = DateTime.UtcNow.AddMinutes(2) };
            string cipherText = Cipher.Encrypt(JsonConvert.SerializeObject(token), new RijndaelManaged(), System.Configuration.ConfigurationManager.AppSettings["KeyHash"]);
            return Cipher.Base64Encode(cipherText);
        }
    }


    [DataContract]
    public class Products
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
    }


    public class TokenProperties
    {
        public Guid TokenId => Guid.NewGuid();
        public DateTime ExpiredDate { get; set; }
    }
}
