namespace WCFSecurityClient
{

    internal class GetUserResultClass
    {
        public ResponseModel GetUserResult { get; set; }
    }

    internal class ResponseModel
    {
        public bool IsError { get; set; }
        public System.Exception Exception { get; set; }
        public string Message { get; set; }
    }
}