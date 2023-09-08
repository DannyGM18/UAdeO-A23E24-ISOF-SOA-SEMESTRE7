using System;

namespace RefactoringGuru.DesignPatterns.AbstractFactory.Conceptual
{
    public interface IAbstractFactory
    {
        IAbstractFactoryProductA CreateProductA();
        IAbstractFactoryProductB CreateProductB();
    }

    class ConcreteFactory1 : IAbstractFactory
    {
        public IAbstractFactoryProductA CreateProductA(){
            return new ConcreteProductA1();
        }

        public IAbstractFactoryProductB CreateProductB()
        {
            return new ConcreteProductB1();
        }
    }

    class ConcreteFactory2 : IAbstractFactory
    {
         public IAbstractFactoryProductA CreateProductA(){
            return new ConcreteProductA2();
        }

        public IAbstractFactoryProductB CreateProductB()
        {
            return new ConcreteProductB2();
        }
    }

    public interface IAbstractFactoryProductA
    {
        string UsefulFunctionA();
    }

    class ConcreteProductA1 : IAbstractFactoryProductA
    {
        public string UsefulFunctionA()
        {
            return "El resultado del Producto A1."
        }
    }

    class ConcreteProductA2 : IAbstractFactoryProductA
    {
        public string UsefulFunctionA()
        {
            return "El resultado del Producto A2."
        }
    }

    public interface IAbstractFactoryProductB
    {
        string UsefulFunctionB();

        string AnotherUsefulFunctionB(IAbstractFactoryProductA colaborador)
    }

    class ConcreteProductB1 : IAbstractFactoryProductB
    {
        public string UsefulFunctionB()
        {
            return "El resultado del Producto B1."
        }
        
        public string AnotherUsefulFunctionB(IAbstractFactoryProductA colaborador)
        {
            var result = colaborador.UsefulFunctionA();

            return $"El resultado de la B1 colaboración con el ({result})";
        }
    }

    class ConcreteProductB2 : IAbstractFactoryProductB
    {
        public string UsefulFunctionB()
        {
            return "El resultado del Producto B2."
        }
        
        public string AnotherUsefulFunctionB(IAbstractFactoryProductA colaborador)
        {
            var result = colaborador.UsefulFunctionA();

            return $"El resultado de la B2 colaboración con el ({result})";
        }
    }

    class Cliente
    {
        public void Main()
        {
            Console.WriteLine("Cliente: Testing client code with the first factory type....");
            ClientMethod(new ConcreteFactory1());
            Console.WriteLine("Cliente: Testing the same client code with the second factory type...");
            ClientMethod(new ConcreteFactory2());
        }
        
        public void ClientMethod(IAbstractFactory factory)
        {
            var productA = factory.CreateProductA();
            var productB = factory.CreateProductB();
            Console.WriteLine(productB.UsefulFunctionB());
            Console.WriteLine(productB.AnotherUsefulFunctionB(productA));
        }

        class Progam
        {
            static void Main(string[] args)
            {
                new Cliente().Main();
            }
        }
    }
}