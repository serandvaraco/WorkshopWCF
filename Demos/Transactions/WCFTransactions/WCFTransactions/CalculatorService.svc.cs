namespace WCFTransactions
{
    using System;
    using System.ServiceModel;

    [ServiceBehavior(
       TransactionIsolationLevel = System.Transactions.IsolationLevel.Serializable,
       TransactionTimeout = "00:00:45")]
    public class CalculatorService : ICalculator
    {
        [OperationBehavior(TransactionScopeRequired = true)]
        public double Add(double n1, double n2)
        {
            // Perform transactional operation  
            RecordToLog(String.Format("Adding {0} to {1}", n1, n2));
            return n1 + n2;
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public double Subtract(double n1, double n2)
        {
            // Perform transactional operation  
            RecordToLog(String.Format("Subtracting {0} from {1}", n2, n1));
            return n1 - n2;
        }

        private static void RecordToLog(string recordText)
        {
            // Database operations omitted for brevity  
            // This is where the transaction provides specific benefit  
            // - changes to the database will be committed only when  
            // the transaction completes.  
            System.Diagnostics.Debug.Write("TRANSACCIÓN COMPLETADA");
        }
    }
}
