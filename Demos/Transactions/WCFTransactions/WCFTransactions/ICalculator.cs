using System.ServiceModel;

namespace WCFTransactions
{
    [ServiceContract]
    public interface ICalculator
    {
        [OperationContract]
        // Use this to require an incoming transaction  
        [TransactionFlow(TransactionFlowOption.Mandatory)]
        double Add(double n1, double n2);
        [OperationContract]
        // Use this to permit an incoming transaction  
        [TransactionFlow(TransactionFlowOption.Allowed)]
        double Subtract(double n1, double n2);
    }
}
