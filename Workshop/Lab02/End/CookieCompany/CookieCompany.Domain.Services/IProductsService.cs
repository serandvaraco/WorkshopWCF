namespace CookieCompany.Domain.Services
{
    using CookieCompany.Model.Services.Fluent;
    using System.Collections.Generic;
    using System.ServiceModel;

    [ServiceContract]
    public interface IProductsService
    {
        [OperationContract]
        IEnumerable<ProductDto> GetProducts();

        [OperationContract]
        ProductDto GetProductsById(int id);

        [OperationContract]
        void AddProduct(ProductDto product);
    }
}
