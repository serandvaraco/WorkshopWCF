
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
            => model.Product.AsParallel().AsEnumerable();

        #endregion

        #region Invent
        Task ICatalog.AddInventAsync(Invent invent)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Invent>> ICatalog.GetInventsByProduct(int productId)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Invent>> ICatalog.GetInventsByDateRange(DateTime begin, DateTime end)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Invent>> ICatalog.GetInventsByQuantity(int quantity, OperatorsMode operators)
        {
            throw new NotImplementedException();
        }

        Task ICatalog.UpdateInventAsync(int id, Invent invent)
        {
            throw new NotImplementedException();
        }

        Task ICatalog.RemoveInventAsync(int id)
        {
            throw new NotImplementedException();
        }

        #endregion 
    }
}
