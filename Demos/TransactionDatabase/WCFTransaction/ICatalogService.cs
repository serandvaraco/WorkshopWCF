using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFTransaction
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "ICatalogService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface ICatalogService
    {
        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Mandatory)]
        void AddProduct(string name, Uri imageUrl);
    }
}
