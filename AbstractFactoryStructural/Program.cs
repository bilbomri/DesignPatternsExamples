using System;

namespace AbstractFactoryStructural
{
    // MainApp startup class for Structural
    // Abstract Factory Design Pattern
    class Program
    {
        static void Main(string[] args)
        {
            // Abstract factory #1
            AbstractFactory factory1 = new ConcreteFactory1();
            Client client1 = new Client(factory1);
            client1.Run();

            // Abstract factory #2
            AbstractFactory factory2 = new ConcreteFactory2();
            Client client2 = new Client(factory2);
            client2.Run();

            // Wait for user input
            Console.ReadLine();
        }
    }

    // The abstract factory class
    abstract class AbstractFactory
    {
        public abstract AbstractProductA CreateProductA();
        public abstract AbstractProductB CreateProductB();
    }

    // The concrete factory 1 class
    class ConcreteFactory1 : AbstractFactory
    {
        public override AbstractProductA CreateProductA()
        {
            return new ProductA1();
        }
        public override AbstractProductB CreateProductB()
        {
            return new ProductB1();
        }
    }

    // The concrete factory 2 class
    class ConcreteFactory2 : AbstractFactory
    {
        public override AbstractProductA CreateProductA()
        {
            return new ProductA2();
        }

        public override AbstractProductB CreateProductB()
        {
            return new ProductB2();
        }
    }

    // The abstract product A abstract class
    abstract class AbstractProductA
    {

    }

    // The abstract product B abstract class
    abstract class AbstractProductB
    {
        public abstract void Interact(AbstractProductA a);
    }

    // The ProductA1 class
    class ProductA1 : AbstractProductA
    {        
    }

    // The ProductB1 class
    class ProductB1 : AbstractProductB
    {
        public override void Interact(AbstractProductA a)
        {
            System.Console.WriteLine(this.GetType().Name + " interacts with " + a.GetType().Name);
        }
    }

    // The ProductA2 class
    class ProductA2 : AbstractProductA
    {        
    }

    // The ProductB2 class
    class ProductB2 : AbstractProductB
    {
        public override void Interact(AbstractProductA a)
        {
            System.Console.WriteLine(this.GetType().Name + " interacts with " + a.GetType().Name);
        }
    }

    // The client class. Interaction environment for the products.
    class Client
    {
        private AbstractProductA _abstractProductA;
        private AbstractProductB _abstractProductB;

        // Constructor
        public Client(AbstractFactory factory)
        {
            _abstractProductA = factory.CreateProductA();
            _abstractProductB = factory.CreateProductB();
        }

        public void Run()
        {
            _abstractProductB.Interact(_abstractProductA);
        }
    }
}
