

using System.Collections;

namespace WCFFundamentals
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "OperacionesMatematicas" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione OperacionesMatematicas.svc o OperacionesMatematicas.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class OperacionesMatematicas : IOperacionesMatematicas
    {

        public MathOperationData Numbers()
        {
            return new MathOperationData { Numbers = new int[] { } };
        }

        public LibraryCatalog Catalog()
        {
            var _book = new Book() { Name = "Libro 1" };
            var _magazine = new Magazine { Name = "2" };

            var hash = new Hashtable();
            hash.Add(typeof(Book), _book);
            hash.Add(typeof(Magazine), _magazine);

            return new LibraryCatalog(hash);
        }
        #region IOperacionesMatematicas
        public NumeroComplejo Divide(double n1, double n2)
        {
            if (n2 == 0)
                return new NumeroComplejo(-1)
                {
                    ErrorMessage = "Error de intento de división por 0"
                };
            else
                return new NumeroComplejo(n1 / n2);


        }

        public CircleType GetFigure() => new CircleType() { Radial = 9 };


        public NumeroComplejo Multiplica(double n1, double n2)
                        => new NumeroComplejo(n1 / n2);



        public NumeroComplejo Resta(double n1, double n2)
            => new NumeroComplejo(n1 / n2);


        public NumeroComplejo Sumar(double n1, double n2)
            => new NumeroComplejo(n1 / n2);

        public Car GetCar()
            => new Car { Model = "Ford", Condition = CarConditionEnum.Used };


        #endregion
    }
}
