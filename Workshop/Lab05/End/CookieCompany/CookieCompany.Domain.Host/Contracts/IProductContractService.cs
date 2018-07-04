namespace CookieCompany.Domain.Host.Contracts
{
    using CookieCompany.Domain.Host.DataContracts;
    using System.Collections.Generic;
    using System.ServiceModel;
    using System.ServiceModel.Web;
    using System.Threading.Tasks;

    [ServiceContract(Namespace = "https://unespacioparanet.com/services/contracts/products")]
    public interface IProductContractService
    {

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Mandatory)]
        [FaultContract(typeof(FaultCatalog), Action = "https://unespacioparanet.com/services/contracts/products/fault/add")]
        void AddProductAsync(Product product);

        [OperationContract]
        [FaultContract(typeof(FaultCatalog), Action = "https://unespacioparanet.com/services/contracts/products/fault/remove")]
        [TransactionFlow(TransactionFlowOption.Mandatory)]
        Task RemoveProductAsync(int id);

        [OperationContract]
        [FaultContract(typeof(FaultCatalog), Action = "https://unespacioparanet.com/services/contracts/products/fault/update")]
        [TransactionFlow(TransactionFlowOption.Mandatory)]
        Task updateProductAsync(Product product);


        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "Products")]
        IEnumerable<Product> GetProducts();

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "Products/{id:int}")]
        Task<Product> GetProductsById(int id);


        #region Invent's

        /// <summary>
        /// Adds the invent.
        /// </summary>
        /// <param name="invent">The invent.</param>
        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Mandatory)]
        void AddInvent(Invent invent);

        /// <summary>
        /// Updates the invent.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="invent">The invent.</param>
        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Mandatory)]
        void UpdateInvent(int id, Invent invent);

        /// <summary>
        /// Removes the invent.
        /// </summary>
        /// <param name="id">The identifier.</param>
        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Mandatory)]
        void RemoveInvent(int id);
        #endregion


    }
}
