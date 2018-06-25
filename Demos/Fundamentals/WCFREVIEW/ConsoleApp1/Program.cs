using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var servicio = new Service1Client())
            {
                Console.WriteLine(servicio.GetData(5)); 
            }

            Console.WriteLine("Terminado");
            Console.ReadKey(); 

        }
    }
}
