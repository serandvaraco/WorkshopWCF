
namespace CookieCompany.DomainCore.Exceptions
{
    using System;

    public class CatalogException : Exception
    {
        public CatalogException(Exception ex) : base("Error de catálogo.", ex) { }
        public CatalogException(string message, Exception ex) : base(message, ex) { }
    }
}
