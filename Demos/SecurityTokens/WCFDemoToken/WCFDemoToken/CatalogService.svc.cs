

namespace WCFDemoToken
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Security.Cryptography;
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using System.ServiceModel.Web;
    using System.Web;

    [ServiceContract(Namespace = "")]
    public class CatalogService
    {
        /// <summary>
        /// Genera llave privada 
        /// </summary>
        private void GenerateKey()
        {
            var hash = Cipher.GenerateKey(
                new System.Security.Cryptography.RijndaelManaged(), 128);
        }

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
        [FaultContract(typeof(ProductsFault), Action = "GetProductsByName")]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, Method = "POST", UriTemplate = "GetProductsName/{name}")]
        public string GetProductsByname(string name)
        {
            try
            {
                ValidateToken();
                return JsonConvert.SerializeObject(products.Where(x => x.Name.Contains(name)));
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(new ProductsFault { Message = ex.Message });
            }
        }

        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, Method = "POST", UriTemplate = "GetProductsbyTake")]
        public IEnumerable<Products> GetProductsByTake(int quantity)
        {
            ValidateToken();
            return products.Take(quantity);
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
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Quantity { get; set; }
    }

    [DataContract]
    public class ProductsFault
    {
        [DataMember]
        public string Message { get; set; }
    }


    public class TokenProperties
    {
        public Guid TokenId => Guid.NewGuid();
        public DateTime ExpiredDate { get; set; }


    }
}
