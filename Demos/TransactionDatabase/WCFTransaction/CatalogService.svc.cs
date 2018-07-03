using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Transactions;

namespace WCFTransaction
{
    [ServiceBehavior(TransactionIsolationLevel = System.Transactions.IsolationLevel.Serializable,
        TransactionTimeout = "00:00:45")]
    public class CatalogService : ICatalogService
    {
        readonly CookieCompanyDBEntities db = new CookieCompanyDBEntities();
        [OperationBehavior(TransactionScopeRequired = true)]
        public void AddProduct(string name, Uri imageUrl)
        {
            db.Product.Add(new Product { Name = name, Image = imageUrl.AbsolutePath });
            db.SaveChanges();
        }

    }
}
