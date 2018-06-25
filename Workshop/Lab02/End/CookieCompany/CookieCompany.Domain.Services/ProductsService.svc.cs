

namespace CookieCompany.Domain.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CookieCompany.Model.Services.Fluent;

    public class ProductsService : IProductsService
    {
        readonly Model.Context.CookieCompanyModel model;
        public ProductsService()
        {
            model = new Model.Context.CookieCompanyModel();
        }

        public void AddProduct(ProductDto product)
        {
            if (product == null)
                throw new ArgumentNullException("product");

            if (string.IsNullOrWhiteSpace(product.Name)
                || string.IsNullOrWhiteSpace(product.Image))
                throw new ArgumentNullException("product");
            if (!Uri.TryCreate(product.Image, UriKind.Absolute, out Uri urlImage))
                throw new ArgumentNullException("URL invalid Image ");

            model.Product.Add(new Model.Context.Product
            {
                Name = product.Name,
                Image = urlImage.AbsoluteUri
            });

            model.SaveChanges();
        }

        public IEnumerable<ProductDto> GetProducts()
        {
            return model.Product.Select(x => new ProductDto
            {
                Name = x.Name,
                Image = x.Image
            });
        }

        public ProductDto GetProductsById(int id)
        {
            var product = model.Product.FirstOrDefault(x => x.Id == id);
            if (product == null)
                throw new Exception("Producto no encontrado");

            return new ProductDto
            {
                Name = product.Name,
                Image = product.Image
            };


        }
    }
}
