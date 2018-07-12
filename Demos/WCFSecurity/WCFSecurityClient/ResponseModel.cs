namespace WCFSecurityClient
{

    internal class ResultModel
    {
        public ResponseModel GetUserResult { get; set; }
        public ResponseModel CreateUserResult { get; set; }
        public ResponseModel AddRoleResult { get; set; }
        public ResponseModel ChangePasswordResult { get; set; }
    }

    internal class ResponseModel
    {
        public bool IsError { get; set; }
        public System.Exception Exception { get; set; }
        public string Message { get; set; }
    }
}