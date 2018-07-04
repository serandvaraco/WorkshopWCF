namespace CookieCompany.DomainCore.Exceptions
{
    using System;
    /// <summary>
    /// Genera un error al actualizar el inventario
    /// </summary>
    /// <seealso cref="CookieCompany.DomainCore.Exceptions.CatalogException" />
    public class UpdateInventException : CatalogException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateInventException"/> class.
        /// </summary>
        /// <param name="ex">The ex.</param>
        public UpdateInventException(Exception ex = null)
            : base("Error al actualizar el inventario", ex)
        { }
    }
}
