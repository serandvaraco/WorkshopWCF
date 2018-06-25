using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestService
{
    class Program
    {
        static void Main(string[] args)
        {


            using (var cliente = new proxy.OperacionesMatematicasClient())
            {
                var resultado = cliente.GetCar();
                Console.WriteLine($"Resultado: {resultado.Condition}");

            }
            Console.ReadKey();
        }
    }
}
