using System;
using System.Runtime.Serialization;

namespace CookieCompany.Domain.Host.DataContracts
{
    /// <summary>
    /// DTO para inventario
    /// </summary>
    [DataContract(Namespace = "https://unespacioparanet.com/services/datacontract/invent")]
    public class Invent
    {
        [DataMember(IsRequired = true)]
        public int Id { get; set; }
        [DataMember(IsRequired = true)]

        public int Quantity { get; set; }
        [DataMember(IsRequired = true)]

        public DateTime Date { get; set; }

        [DataMember(IsRequired = true)]
        public int ProductId { get; set; }
    }
}
