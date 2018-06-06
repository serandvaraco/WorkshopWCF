using System;
using System.Collections.Generic;
using System.Linq;
namespace CookieCompany.Domain.Services
{
    public class ProductsService : IProductsService
    {
        readonly Model.Context.CookieCompanyModel model;
        public ProductsService()
        {
            model = new Model.Context.CookieCompanyModel();
        }

        public IEnumerable<string> GetProducts()
        {
            return model.Product.Select(x => x.Name);
        }

        public string GetProductsById(int id)
        => model.Product.Find(id).Name;
    }
}
