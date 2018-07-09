using System;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace WCFSecurity
{
    [ServiceContract]
    public interface Security
    {
        [OperationContract]
        [WebInvoke(Method ="POST",UriTemplate = "GetToken", // Post envia 
            ResponseFormat = WebMessageFormat.Json)]

        string GetToken(string username, string password);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Create",
            ResponseFormat = WebMessageFormat.Json)]

        ResponseModel CreateUser(string username, string password);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "changePassword", // Actualiza
            ResponseFormat = WebMessageFormat.Json)]

        ResponseModel changePassword(string username,
            string actualPassword,
            string newPassword);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "CreateRole",
            ResponseFormat = WebMessageFormat.Json)]

        ResponseModel AddRole(string username, string role);
 
    }

    [DataContract]

    public class ResponseModel
    {
        [DataMember]
        public bool IsError => Exception != null;

        [DataMember]
        public System.Exception Exception { get; set; }

        [DataMember]

        public string Message { get; set; }
    }

    public class TokenSecurityModel
    {
        public Guid id { get; set; }

        public DateTime Expiration { get; set; }

        public string [] Roles { get; set; }

        public string Username { get; set; }

        public string DisplayName { get; set; }
    }
}
