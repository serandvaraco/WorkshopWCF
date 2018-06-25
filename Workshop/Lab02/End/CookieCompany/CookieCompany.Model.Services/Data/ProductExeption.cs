namespace CookieCompany.Model.Services.Data
{
    using System;
    using System.Runtime.Serialization;

    [DataContract(Name ="ProductException", 
        Namespace ="http://unespacioparanet.com/contracts/data/exceptionModel/productException")]
    [Serializable]
    public class ProductExeption
    {
        [DataMember]
        public string Message { get; set; }
    }
}
