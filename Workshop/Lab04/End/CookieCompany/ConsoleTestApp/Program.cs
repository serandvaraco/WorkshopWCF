using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var client = new proxy.ProductContractServiceClient())
            {
                var products = client.GetProducts();
                foreach (var item in products)
                {
                    Console.WriteLine(item.Name);
                }
            }
            Console.ReadKey(); 
        }
    }
}
