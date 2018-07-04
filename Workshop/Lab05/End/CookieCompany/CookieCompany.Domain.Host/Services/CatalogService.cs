namespace CookieCompany.Domain.Host.Services
{
    using CookieCompany.Domain.Host.Contracts;
    using CookieCompany.Domain.Host.DataContracts;
    using CookieCompany.DomainCore.Contracts;
    using CookieCompany.DomainCore.Manage;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.ServiceModel;
    using System.Threading.Tasks;


    [ServiceBehavior(
     TransactionIsolationLevel = System.Transactions.IsolationLevel.Serializable,
     TransactionTimeout = "00:00:45")]
    public class CatalogService : IProductContractService
    {
        /// <summary>
        /// The catalog
        /// </summary>
        private readonly ICatalog catalog;
        public CatalogService()
        {
            catalog = new CatalogProvider(new Model.Context.CookieCompanyDBEntities());
            catalog.CatalogEvent += Catalog_CatalogEvent;
        }

        /// <summary>
        /// Notifica los sucesos ocurridos en el llamado de la API
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Catalog_CatalogEvent(object sender, DomainCore.Triggers.CatalogEventArgs e)
        {
            if (e.IsError)
            {
                Debug.WriteLine($"Error => {e.Exception.Message}");
                throw new FaultException<FaultCatalog>(new FaultCatalog { Exception = e.Exception, Message = e.Message }, "Error generado en el catálogo de productos");
            }

            Debug.WriteLine(e.Message);
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public async void AddProductAsync(Product product)
        {
            catalog.CatalogEvent += Catalog_CatalogEvent;
            await catalog.AddProductAsync(new Model.Context.Product { Name = product.Name, Image = product.UrlImage });

        }
        public IEnumerable<Product> GetProducts()
        {
            try
            {
                var products = catalog.GetProducts().Select(x => new Product { Id = x.Id, Name = x.Name, UrlImage = x.Image });
                return products;
            }
            catch (Exception e)
            {
                throw new FaultException<FaultCatalog>(new FaultCatalog { Exception = e, Message = e.Message }, "Error generado en el catálogo de productos");
            }
        }

        public async Task<Product> GetProductsById(int id)
        {
            var product = await catalog.GetProductByIdAsync(id);
            return new Product { Id = product.Id, Name = product.Name, UrlImage = product.Image };
        }
        [OperationBehavior(TransactionScopeRequired = true)]
        public Task RemoveProductAsync(int id)
               => catalog.RemoveProductAsync(id);
        [OperationBehavior(TransactionScopeRequired = true)]

        public Task updateProductAsync(Product product)
        => catalog.UpdateProductAsync(product.Id, new Model.Context.Product { Name = product.Name, Image = product.UrlImage });

        /// <summary>
        /// Adds the invent.
        /// </summary>
        /// <param name="invent">The invent.</param>
        /// <exception cref="FaultException{FaultCatalog}">Error generado por el servicio al intentar guradar el invantario</exception>
        /// <exception cref="FaultCatalog">Error desconocido del catálogo</exception>
        [OperationBehavior(TransactionScopeRequired = true)]
        public async void AddInvent(Invent invent)
        {
            try
            {
                await catalog.AddInventAsync(new Model.Context.Invent
                {
                    Id = invent.Id,
                    Date = invent.Date,
                    Quantity = invent.Quantity,
                    ProductId = invent.ProductId
                });
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultCatalog>(new FaultCatalog
                {
                    Exception = ex,
                    Message = "Error al agregar al inventario"
                });
            }

        }

        public void UpdateInvent(int id, Invent invent)
        {
            throw new NotImplementedException();
        }

        public void RemoveInvent(int id)
        {
            throw new NotImplementedException();
        }
    }
}
