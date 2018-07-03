namespace CookieCompany.Domain.Host.DataContracts
{
    using System.Runtime.Serialization;

    [DataContract(Namespace = "https://unespacioparanet.com/services/datacontrac/products")]
    public class Product
    {
        [DataMember(IsRequired = true)]
        public int Id { get; set; }
        [DataMember(IsRequired = true)]
        public string Name { get; set; }
        [DataMember(IsRequired = true)]
        public string UrlImage { get; set; }

    }
}
