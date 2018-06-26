using System;
namespace CookieCompany.DomainCore.Triggers
{
    public class CatalogEventArgs : EventArgs
    {
        public string Message { get; set; }
        public Exception Exception { get; set; }
        public bool IsError => Exception != null;
    }
}
