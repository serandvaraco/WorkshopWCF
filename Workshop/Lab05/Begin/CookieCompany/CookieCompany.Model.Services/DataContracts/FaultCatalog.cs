namespace CookieCompany.Model.Services.DataContracts
{
    using System;
    using System.Runtime.Serialization;

    [DataContract(Namespace = "https://unespacioparanet.com/services/datacontrac/Fault")]
    public class FaultCatalog
    {
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public Exception Exception { get; set; }
        [DataMember]
        public bool IsError => Exception != null;

    }
}
