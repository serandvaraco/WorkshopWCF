
namespace CookieCompany.DomainCore.Exceptions
{
    using System;

    /// <summary>
    /// Error general de catálogo
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class CatalogException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogException"/> class.
        /// </summary>
        /// <param name="ex">The ex.</param>
        public CatalogException(Exception ex) : base("Error de catálogo.", ex) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="ex">The ex.</param>
        public CatalogException(string message, Exception ex) : base(message, ex) { }
    }
}
