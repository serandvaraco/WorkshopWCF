using System;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace WCFSecurity
{
    [ServiceContract]
    public interface ISecurity
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetToken",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped)]

        string GetToken(string username, string password);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Create",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped)]

        ResponseModel CreateUser(string username, string password);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "changePassword", // Actualiza
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped)]

        ResponseModel changePassword(string username,
            string actualPassword,
            string newPassword);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "CreateRole",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped)]
        ResponseModel AddRole(string username, string role);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetUser",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped)]
        ResponseModel GetUser(); 

    }

    [DataContract]
    public class ResponseModel
    {
        public ResponseModel()
        {
            IsError = false;
        }
        [DataMember]
        public bool IsError { get; set; }

        [DataMember]
        public System.Exception Exception { get; set; }

        [DataMember]

        public string Message { get; set; }
    }

    public class TokenSecurityModel
    {
        public Guid id { get; set; }

        public DateTime Expiration { get; set; }

        public string[] Roles { get; set; }

        public string Username { get; set; }

        public string DisplayName { get; set; }
    }
}
