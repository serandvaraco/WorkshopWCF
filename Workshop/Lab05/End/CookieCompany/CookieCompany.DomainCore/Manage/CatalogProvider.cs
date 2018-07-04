
namespace CookieCompany.DomainCore.Manage
{
    using CookieCompany.Common;
    using CookieCompany.DomainCore.Contracts;
    using CookieCompany.DomainCore.Exceptions;
    using CookieCompany.DomainCore.Triggers;
    using CookieCompany.Model.Context;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Catálogo de productos
    /// </summary>
    /// <seealso cref="CookieCompany.DomainCore.Contracts.ICatalog" />
    public class CatalogProvider : ICatalog
    {
        private readonly ICookieCompanyModel model;

        public CatalogProvider(ICookieCompanyModel cookieCompanyModel)
        {
            this.model = cookieCompanyModel;
        }

        #region Event Catalog 
        event EventHandler<CatalogEventArgs> ICatalog.CatalogEvent
        {
            add
            {
                CatalogEvent += value;
            }

            remove
            {
                CatalogEvent -= value;
            }
        }
        private event EventHandler<CatalogEventArgs> CatalogEvent;
        private void OnCatalogEvent(string message)
            => OnCatalogEvent(message, null);
        private void OnCatalogEvent(string message, Exception ex)
            => CatalogEvent?.Invoke(this, new CatalogEventArgs { Message = message, Exception = ex });
        #endregion

        #region Products
        /// <summary>
        /// Permite Agregar un nuevo producto 
        /// </summary>
        /// <param name="product">Recibe el producto a agregar </param>
        async Task ICatalog.AddProductAsync(Product product)
        {
            try
            {
                if (product == null)
                    throw new ArgumentNullException((typeof(Product)).GetType().Name);

                if (string.IsNullOrWhiteSpace(product.Name) || string.IsNullOrWhiteSpace(product.Image))
                    throw new ArgumentNullException("Revisar las propiedades Name, ImageUrl");

                if (!Uri.TryCreate(product.Image, UriKind.Absolute, out Uri uri))
                    throw new UriFormatException(product.Image.GetType().Name);



                model.Product.Add(product);
                await model.SaveChangesAsync();
                OnCatalogEvent("Producto agregado con éxito");
            }
            catch (Exception ex)
            {
                OnCatalogEvent(ex.Message, ex);
            }
        }

        /// <summary>
        /// Obtiene el producto por un identificador valido 
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns>Producto</returns>
        Task<Product> ICatalog.GetProductByIdAsync(int id)
            => model.Product.FindAsync(id);

        /// <summary>
        /// Permite remover el producto por identificador
        /// </summary>
        /// <param name="id">Identificador de producto</param>
        async Task ICatalog.RemoveProductAsync(int id)
        {
            var product = model.Product.FirstOrDefault(x => x.Id == id);
            if (product == null)
                throw new ProductNotFoundException();
            try
            {
                model.Product.Remove(product);
                await model.SaveChangesAsync();
                OnCatalogEvent("Producto removido con éxito");
            }
            catch (Exception ex)
            {
                OnCatalogEvent(ex.Message, ex);
            }
        }
        /// <summary>
        /// Permite marcar una actuallización al producto 
        /// </summary>
        /// <param name="id">Identificador de producto </param>
        /// <param name="product">Entidad del producto a actualizar</param>
        async Task ICatalog.UpdateProductAsync(int id, Product product)
        {
            try
            {
                if (product == null)
                    throw new ArgumentNullException((typeof(Product)).GetType().Name);

                if (string.IsNullOrWhiteSpace(product.Name) || string.IsNullOrWhiteSpace(product.Image))
                    throw new ArgumentNullException("Revisar las propiedades Name, ImageUrl");

                if (!Uri.TryCreate(product.Image, UriKind.Absolute, out Uri uri))
                    throw new UriFormatException(product.Image.GetType().Name);


                var _product = model.Product.FirstOrDefault(x => x.Id == id);
                if (_product == null)
                    throw new ProductNotFoundException();


                _product.Name = product.Name;
                _product.Image = product.Image;

                await model.SaveChangesAsync();
                OnCatalogEvent("Producto actualizado con éxito");
            }
            catch (Exception ex)
            {
                OnCatalogEvent(ex.Message, ex);
            }
        }

        /// <summary>
        /// Permite obtener el listado de todos los productos
        /// </summary>
        /// <returns>Listado de productos a obtener</returns>
        IEnumerable<Product> ICatalog.GetProducts()
        {
            try
            {
                return model.Product.ToArray();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }
        #endregion

        #region Invent
        /// <summary>
        /// Permite agrear un nuevo producto al inventario
        /// </summary>
        /// <param name="invent">Entidad de inventario</param>
        /// <exception cref="ArgumentOutOfRangeException"> El producto o la cantidad es 0 o inferior </exception>
        /// <exception cref="ArgumentNullException">Si la entidad inventario es nula</exception>
        /// <exception cref="ProductNotFoundException">Si el producto que llega en el inventario no existe</exception>
        /// <exception cref="UpdateInventException">Se produce cuanto intenta almacenar el inventario</exception>
        /// <returns>Tarea en segundo plano</returns>
        Task ICatalog.AddInventAsync(Invent invent)
        {


            try
            {
                InventIsValid(invent);
                model.Invent.Add(invent);
                return model.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new UpdateInventException(ex);
            }
        }
        /// <summary>
        /// Invents the is valid.
        /// </summary>
        /// <param name="invent">The invent.</param>
        /// <exception cref="ArgumentNullException">invent</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// ProductId
        /// or
        /// Quantity
        /// </exception>
        /// <exception cref="ProductNotFoundException"></exception>
        private void InventIsValid(Invent invent)
        {
            if (invent == null)
                throw new ArgumentNullException("invent");

            if (invent.ProductId <= 0)
                throw new ArgumentOutOfRangeException("ProductId");

            if (invent.Quantity <= 0)
                throw new ArgumentOutOfRangeException("Quantity");

            if (!this.model.Product.Any(x => x.Id == invent.ProductId))
                throw new ProductNotFoundException();
        }

        /// <summary>
        /// Permite obtener el inventario por identificador de producto 
        /// </summary>
        /// <param name="productId">Identificador de producto</param>
        /// <returns></returns>
        IEnumerable<Invent> ICatalog.GetInventsByProduct(int productId)
            => model.Invent.Where(x => x.ProductId == productId);

        IEnumerable<Invent> ICatalog.GetInventsByDateRange(DateTime begin, DateTime end)
        => model.Invent.Where(x => x.Date >= begin && x.Date <= end);

        /// <summary>
        /// Obtiene las unidades de invatario por cantidad 
        /// </summary>
        /// <param name="quantity">Cantidad a obtener</param>
        /// <param name="operators">Modo</param>
        /// <returns>Listado de elementos de inventario</returns>
        IEnumerable<Invent> ICatalog.GetInventsByQuantity(int quantity,
            OperatorsMode operators)
        {
            switch (operators)
            {
                case OperatorsMode.Greater:
                    return model.Invent.Where(x => x.Quantity > quantity);
                case OperatorsMode.Less:
                    return model.Invent.Where(x => x.Quantity < quantity);
                case OperatorsMode.Equal:
                    return model.Invent.Where(x => x.Quantity == quantity);
                case OperatorsMode.GreaterOrEqual:
                    return model.Invent.Where(x => x.Quantity >= quantity);
                case OperatorsMode.LessOrEqual:
                    return model.Invent.Where(x => x.Quantity <= quantity);
                case OperatorsMode.Different:
                    return model.Invent.Where(x => x.Quantity != quantity);
                default:
                    return model.Invent.Where(x => x.Quantity == quantity);
            }
        }

        /// <summary>
        /// Actualizar Inventario
        /// </summary>
        /// <param name="id">Identificador del inventario</param>
        /// <param name="invent">Inventario</param>
        /// <returns></returns>
        /// <exception cref="UpdateInventException"> Se genera al intentar actualizar el inventario
        /// </exception>
        Task ICatalog.UpdateInventAsync(int id, Invent invent)
        {
            try
            {
                InventIsValid(invent);

                if (!model.Invent.Any(x => x.Id == id))
                    throw new UpdateInventException();

                var _invent = model.Invent.FindAsync(id).Result;

                //Se puede usar el objeto AutoMapper para esta tarea. iMapper.Map<Contex.Invent, Model.Invent>(invent);
                _invent.Date = invent.Date;
                _invent.Quantity = invent.Quantity;
                return model.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new UpdateInventException(ex);
            }

        }

        /// <summary>
        /// Permite remover el inventario
        /// </summary>
        /// <param name="id">identificador del inventario</param>
        /// <returns></returns>
        /// <exception cref="CookieCompany.DomainCore.Exceptions.UpdateInventException">
        /// Error al generar la actualización del inventario
        /// </exception>
        Task ICatalog.RemoveInventAsync(int id)
        {
            try
            {
                if (!model.Invent.Any(x => x.Id == id))
                    throw new UpdateInventException();

                model.Invent.Remove(model.Invent.Find(id));
                return model.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new UpdateInventException(ex);
            }
        }


        #endregion
    }
}
