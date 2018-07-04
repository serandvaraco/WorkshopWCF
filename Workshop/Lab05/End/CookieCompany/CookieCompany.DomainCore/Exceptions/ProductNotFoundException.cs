
namespace CookieCompany.DomainCore.Exceptions
{
    using System;

    public class ProductNotFoundException : CatalogException
    {
        public ProductNotFoundException(Exception ex = null) : base("Producto no existente en el catalogo", ex) { }
    }
}
