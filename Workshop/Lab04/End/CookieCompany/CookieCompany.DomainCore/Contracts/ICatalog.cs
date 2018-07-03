namespace CookieCompany.DomainCore.Contracts
{
    using CookieCompany.Common;
    using CookieCompany.DomainCore.Triggers;
    using CookieCompany.Model.Context;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICatalog
    {
        /// <summary>
        /// Notifica los sucesos ocurridos en las transacciones
        /// </summary>
        event EventHandler<CatalogEventArgs> CatalogEvent;
        /// <summary>
        /// Permite Agregar un nuevo producto 
        /// </summary>
        /// <param name="product">Recibe el producto a agregar </param>
        Task AddProductAsync(Product product);
        /// <summary>
        /// Obtiene un producto por identificador
        /// </summary>
        /// <param name="id">identificador del producto</param>
        /// <returns></returns>
        Task<Product> GetProductByIdAsync(int id);
        /// <summary>
        /// Permite remover el producto por identificador
        /// </summary>
        /// <param name="id">Identificador de producto</param>
        Task RemoveProductAsync(int id);

        /// <summary>
        /// Permite marcar una actuallización al producto 
        /// </summary>
        /// <param name="id">Identificador de producto </param>
        /// <param name="product">Entidad del producto a actualizar</param>
        Task UpdateProductAsync(int id, Product product);

        /// <summary>
        /// Permite obtener el listado de todos los productos
        /// </summary>
        /// <returns>Listado de productos a obtener</returns>
        IEnumerable<Product> GetProducts();

        /// <summary>
        /// Permite crear un nuevo inventario
        /// </summary>
        /// <param name="invent"></param>
        Task AddInventAsync(Invent invent);
        /// <summary>
        /// Permite obtener el inventario por producto
        /// </summary>
        /// <param name="productId">identificador de producto</param>
        /// <returns></returns>
        Task<IEnumerable<Invent>> GetInventsByProduct(int productId);
        /// <summary>
        /// Permite obtener el inventario por un rango de fechas
        /// </summary>
        /// <param name="begin">Fecha inicial </param>
        /// <param name="end">Fecha Final </param>
        /// <returns></returns>
        Task<IEnumerable<Invent>> GetInventsByDateRange(DateTime begin, DateTime end);
        /// <summary>
        /// Permite obtener el inventario por cantidad 
        /// </summary>
        /// <param name="quantity">Cantidad a obtener</param>
        /// <param name="operators">Operador aritmetico para obtener la cantidad de inventario</param>
        /// <returns></returns>
        Task<IEnumerable<Invent>> GetInventsByQuantity(int quantity, OperatorsMode operators);

        /// <summary>
        /// Actualizar Inventario
        /// </summary>
        /// <param name="id">Identificador del inventario</param>
        /// <param name="invent">Inventario</param>
        Task UpdateInventAsync(int id, Invent invent);
        /// <summary>
        /// Permite remover el inventario
        /// </summary>
        /// <param name="id">identificador del inventario</param>
        Task RemoveInventAsync(int id);

    }
}
