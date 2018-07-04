namespace CookieCompany.Model.Services
{
    using CookieCompany.Model.Services.DataContracts;
    using System.Collections.Generic;
    using System.ServiceModel;
    using System.Threading.Tasks;

    [ServiceContract(Namespace = "https://unespacioparanet.com/services/contracts/products")]
    public interface IProductContractService
    {

        [OperationContract]
        [FaultContract(typeof(FaultCatalog), Action = "https://unespacioparanet.com/services/contracts/products/fault/add")]
        void AddProductAsync(Product product);

        [OperationContract]
        [FaultContract(typeof(FaultCatalog), Action = "https://unespacioparanet.com/services/contracts/products/fault/remove")]
        Task RemoveProductAsync(int id);

        [OperationContract]
        [FaultContract(typeof(FaultCatalog), Action = "https://unespacioparanet.com/services/contracts/products/fault/update")]
        Task updateProductAsync(Product product);

        [OperationContract]
        IEnumerable<Product> GetProducts();

        [OperationContract]
        Task<Product> GetProductsById(int id);
    }
}
