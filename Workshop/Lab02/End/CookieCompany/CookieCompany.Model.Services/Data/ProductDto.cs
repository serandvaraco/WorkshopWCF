namespace CookieCompany.Model.Services.Data
{
    using System.Runtime.Serialization;

    [DataContract(Name = "Product", Namespace = "http://unespaciopara.net/contracts/data/product")]
    public class ProductDto
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Imagen { get; set; }
    }
}
