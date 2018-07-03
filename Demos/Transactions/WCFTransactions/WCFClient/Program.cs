namespace WCFClient
{
    using System;
    using System.Transactions;
    class Program
    {
        static void Main(string[] args)
        {
            using (var scope = new TransactionScope(TransactionScopeOption.RequiresNew))
            using (var c = new CalculatorClient())
            {
                var result = c.Add(2, 4);
                Console.WriteLine($"Resultado = {result}");
                scope.Complete();
            }
            Console.ReadKey();
        }
    }
}
