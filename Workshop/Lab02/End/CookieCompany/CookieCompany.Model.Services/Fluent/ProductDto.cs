
namespace CookieCompany.Model.Services.Fluent
{
    using System.Runtime.Serialization;

    [DataContract]
    public class ProductDto
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Image { get; set; }
    }
}
