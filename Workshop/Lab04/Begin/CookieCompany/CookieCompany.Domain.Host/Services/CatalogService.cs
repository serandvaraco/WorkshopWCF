﻿namespace CookieCompany.Domain.Host.Services
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

    public class CatalogService : IProductContractService
    {
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

        public Task RemoveProductAsync(int id)
               => catalog.RemoveProductAsync(id);

        public Task updateProductAsync(Product product)
        => catalog.UpdateProductAsync(product.Id, new Model.Context.Product { Name = product.Name, Image = product.UrlImage });
    }
}
