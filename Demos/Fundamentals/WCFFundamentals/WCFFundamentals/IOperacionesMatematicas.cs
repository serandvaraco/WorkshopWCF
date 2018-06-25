
namespace WCFFundamentals
{
    using System;
    using System.Collections;
    using System.Runtime.Serialization;
    using System.ServiceModel;

    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IOperacionesMatematicas" en el código y en el archivo de configuración a la vez.
    [ServiceContract(Namespace = "http://unespacioparanet.com")]
    public interface IOperacionesMatematicas
    {
        [OperationContract]
        NumeroComplejo Sumar(double n1, double n2);

        [OperationContract]
        NumeroComplejo Resta(double n1, double n2);

        [OperationContract]
        NumeroComplejo Multiplica(double n1, double n2);

        [OperationContract]
        NumeroComplejo Divide(double n1, double n2);

        [OperationContract]
        CircleType GetFigure();

        [OperationContract]
        LibraryCatalog Catalog();

        [OperationContract]
        MathOperationData Numbers();

        [OperationContract]
        Car GetCar();
    }

    [DataContract(
        Name = "ComplexNumber", 
        Namespace = "http://unespacioparanet.com/DataContracts")]
    public class NumeroComplejo
    {
        [DataMember(Order = 1)]
        public double Resultado { get; set; }
        [DataMember(Order = 0)]
        public string ErrorMessage { get; set; }

        public NumeroComplejo(double resultado)
        {
            this.Resultado = resultado;
        }
    }

    [DataContract]
    public class Shape
    {
        [DataMember]
        public int x { get; set; }
        [DataMember]
        public int y { get; set; }
    }
    [DataContract(Name = "Circle")]
    public class CircleType : Shape
    {
        [DataMember]
        public int Radial { get; set; }

    }
    [DataContract(Name = "Triangule")]
    public class trianguleType : Shape
    {
        public int Base { get; set; }
    }



    [DataContract()]
    public class Book
    {
        [DataMember]
        public string Name { get; set; }
    }

    [DataContract()]
    public class Magazine
    {
        [DataMember]
        public string Name { get; set; }
    }

    [DataContract()]
    [KnownType(typeof(Book))]
    [KnownType(typeof(Magazine))]
    public class LibraryCatalog
    {

        [DataMember]
        public Hashtable theCatalog { get; set; }
        public LibraryCatalog(Hashtable catalog)
        {
            theCatalog = catalog;
        }

    }

    [DataContract]
    [KnownType(typeof(int[]))]

    public class MathOperationData
    {
        [DataMember(EmitDefaultValue = true)]
        public object Numbers { get; set; } = new int[] { 0 };
    }


    [DataContract]
    public class Car
    {
        [DataMember]
        public string Model { get; set; }
        [DataMember]
        public CarConditionEnum Condition { get; set; }
    }

    [DataContract]
    public enum CarConditionEnum
    {
        [EnumMember]
        New,
        [EnumMember(Value = "Usado")]
        Used,
        Rental,
        Broken
    }
}
