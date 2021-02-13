using System;

namespace UsingInterfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1!
            var person = new Person();
            var car = new Car();
            Action(person);
            Action(car);
            Console.WriteLine('\n');
            
            // 2!
            IMovable2 tom = new Person2();
            var tesla = new Car2();
            tom.Move();     // Walking
            tesla.Move();   // Driving
            Console.WriteLine('\n');
            
            // 3!
            var client = new Client("Tom", 200);
            client.Put(30);
            Console.WriteLine(client.CurrentSum); //230
            client.Withdraw(100);
            Console.WriteLine(client.CurrentSum); //130
            Console.WriteLine('\n');
            
            // 4!
            // All Client objects are IAccount objects
            IAccount account = new Client ("Volume", 200);
            account.Put (200);
            Console.WriteLine (account.CurrentSum); // 400
            // Not all IAccount objects are Client objects, explicit casting is required
            Client client2 = (Client) account;
            // The IAccount interface does not have a Name property, an explicit cast is required
            string clientName = ((Client) account).Name;
            Console.WriteLine(clientName);
            string clientName2 = ((account as Client)).Name;
            Console.WriteLine(clientName2);
            var isClient = account is Client;
            Console.WriteLine(isClient);
        }
        
        // An interface represents a kind of description of a type, a set of components that must have a data type.
        // And, in fact, we cannot create interface objects directly using the constructor, as, for example, in classes:
            
        /*
         * IMovable m = new IMovable (); //! Mistake, this cannot be done
         */
        
        // Ultimately, an interface is meant to be implemented in classes and structures.
        // For example, take the following IMovable interface:
        
        interface IMovable
        {
            void Move();
        }
        
        // Then some class or structure can apply this interface:
        
        // use the interface in the class
        class Person: IMovable
        {
            public void Move ()
            {
                Console.WriteLine ("A man is walking");
            }
        }
        
        // use the interface in the structure
        struct Car: IMovable
        {
            public void Move ()
            {
                Console.WriteLine ("The car is going");
            }
        }
        
        // When using an interface, as in inheritance, a colon is indicated after the name of a class or structure,
        // followed by the names of the interfaces used. In this case,
        // the class must implement all the methods and properties of the applied interfaces,
        // if these methods and properties do not have a default implementation.

        // If methods and properties of an interface do not have an access modifier, then by default they are public;
        // when implementing these methods and properties in a class and structure, only the public modifier can be applied to them.

        // Application of the interface in the program:
        
        // 1!
        
        static void Action(IMovable movable)
        {
            movable.Move();
        }
        
        // This program defines the Action () method, which takes an IMovable interface object as a parameter.
        // At the time of writing the code, we may not know what kind of object it will be - some kind of class or structure.
        // The only thing we can be sure
        // of is that this object necessarily implements the Move method and we can call this method.

        // !!!In other words, an interface is a !!!contract!!! that a certain type necessarily implements some functionality.

        // The console output of this program:

        /*
         Man walks
         Car rides
         */
        
        
        //
        
        
        // !!!Default Interface Implementation!!!
        
        // Starting with C # 8.0, interfaces support default method and property implementations.
        // Why is this needed? Let's say we have a bunch of classes that implement some interface.
        // If we add a new method to this interface, then we will be required to implement this method in all classes that use this interface.
        // Otherwise, such classes will simply not compile.
        // Now, instead of implementing the method in all classes,
        // we just need to define its default implementation in the interface.
        // If the class does not implement the method, the default implementation will be used.
        
        // 2!
        
        interface IMovable2
        {
            void Move()
            {
                Console.WriteLine("Walking");
            }
        }
        
        class Person2 : IMovable2 { }
        
        class Car2 : IMovable2
        {
            public void Move()
            {
                Console.WriteLine("Driving");
            }
        }
        
        // In this case, the IMovable interface defines the default implementation for the Move method.
        // The Person class does not implement this method, so it uses a default implementation, unlike the Car class,
        // which defines its own implementation for the Move method.

        // It is worth noting that although we can call the Move method for an object of the Person class - after all,
        // the Person class uses the IMovable interface, nevertheless, we cannot write like this:
        
        /*
         Person tom = new Person ();
         tom.Move (); // Error - Move method is not defined in Person class!!!
         */
        
        
        //
        
        
        
        // !!!Multiple Interface Implementation!!!
        
        // Interfaces have another important function: C # does not support multiple inheritance, that is,
        // we can inherit a class from only one class, unlike, say, the C ++ language, where multiple inheritance can be used.
        // Interfaces allow you to partially work around this limitation,
        // since in C # a class can implement several interfaces at once.
        // All implemented interfaces are specified separated by commas:
        
        /*
         myClass: myInterface1, myInterface2, myInterface3, ...
        {
     
        }
        */
        
        // Let's take an example:
        
        // 3!
        
        interface IAccount
        {
            int CurrentSum {get; } // Current amount on the account
            void Put (int sum); // To put money into the account
            void Withdraw (int sum); // Take from the account
        }
        
        interface IClient
        {
            string Name {get; set; }
        }
        
        class Client: IAccount, IClient
        {
            int _sum; // Variable for storing the sum
            
            public string Name { get; set; }
            
            public Client (string name, int sum)
            {
                Name = name;
                _sum = sum;
            }
 
            public int CurrentSum {get {return _sum; }}
 
            public void Put (int sum) { _sum += sum; }
 
            public void Withdraw (int sum)
            {
                if (_sum >= sum)
                {
                    _sum -= sum;
                }
            }
        }
        
        
        //
        
        
        // !!!Interfaces in type conversions!!!
        
        // Everything that has been said about type conversion applies to interfaces as well.
        // Since the Client class implements the IAccount interface,
        // a variable of type IAccount can store a reference to an object of type Client:
        
        // 4!
        
        // Conversion from a class to its interface, like conversion from a derived type to a base type, is done automatically.
        // Since any Client object implements the IAccount interface.

        // The reverse conversion - from an interface to the class that implements it,
        // will be similar to conversion from a base class to a derived class.
        // Since not every IAccount object is a Client object (after all, other classes can implement the IAccount interface),
        // such a conversion requires a casting operation.
        // And if we want to refer to methods of the Client class that are not defined in the IAccount interface,
        // but are part of the Client class,
        // then we need to explicitly perform the type conversion: string clientName = ((Client) account).Name;
    }
}