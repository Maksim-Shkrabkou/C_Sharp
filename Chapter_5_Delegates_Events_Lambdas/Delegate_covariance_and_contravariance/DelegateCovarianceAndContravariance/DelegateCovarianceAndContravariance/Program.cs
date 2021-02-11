using System;

namespace DelegateCovarianceAndContravariance
{
    class Program
    {
        // 1!
        delegate Person PersonFactory(string name);
        
        // 2!
        delegate void ClientInfo(Client client);
        
        //3!
        delegate T Builder<out T>(string name);
        
        // 4!
        delegate void GetInfo<in T>(T item);
        
        static void Main(string[] args) 
        {
            // 1!
            PersonFactory personDel;
            personDel = BuildClient; // covariance
            Person p = personDel("Tom");
            Console.WriteLine(p.Name);
            Console.WriteLine('\n');
            
            // 2!
            ClientInfo clientInfo = GetPersonInfo; // contravariance
            Client client = new Client {Name = "Alice"};
            clientInfo(client);
            Console.WriteLine('\n');
            
            // 3!
            Builder<Client2> clientBuilder = GetClient;
            Builder<Person2> personBuilder1 = clientBuilder; // covariance
            Builder<Person2> personBuilder2 = GetClient; // covariance
 
            Person2 p2 = personBuilder1("Tom"); // call the delegate
            p2.Display (); // Client: Tom
            Console.WriteLine('\n');
            
            // 4!
            GetInfo<Person2> personInfo2 = PersonInfo;
            GetInfo<Client2> clientInfo2 = personInfo2;      // contravariance
         
            Client2 client2 = new Client2 { Name = "Tom" };
            clientInfo2(client2); // Client: Tom
        }
        
        // Delegates can be covariant and contravariant.
        // Delegate covariance suggests that the return type may be a more derived type.
        // Delegate contravariance suggests that the type of the parameter can be a more generic type.

        //
        
        // !!!Covariance!!!
        
        // Covariance allows a method to return an object whose type is derived from the type returned by the delegate.

        // Let's say you have the following class structure:
        
        class Person
        {
            public string Name { get; set; }
        }
        
        class Client : Person { }
        
        // In this case, the covariance of the delegate might look like this:
        
        // 1!
        
        private static Client BuildClient(string name)
        {
            return new Client {Name = name};
        }
        
        // That is, it returns a Person object here. However, due to covariance,
        // this delegate can point to a method that returns an object of a derived type, such as Client.

        
        //
        
        
        // !!!Contravariance!!!
        
        // Contravariance implies the possibility of using a method of an object whose type is universal
        // with respect to the type of the representative.
        // For example, take the Person and Client classes above and use them in the following example:
        
        // 2!
        
        private static void GetPersonInfo(Person p)
        {
            Console.WriteLine(p.Name);
        }
        
        // Although the delegate takes a Client object as a parameter,
        // it can be assigned a method that takes an object of the base Person type as a parameter.
        // It may seem at first glance that there is some contradiction here, that is,
        // the use of a more universal type instead of a more derived one.
        // However, in reality, when calling a delegate, we can still pass only objects of type Client,
        // and any object of type Client is an object of type Person, which is used in the method.

        
        //
        
        
        // !!!Covariance and Contravariance in Generic Delegates!!!
        
        
        // Generic delegates can also be covariant and contravariant, which gives us more flexibility in using them.

        // For example, take the following class hierarchy:
        
        class Person2
        {
            public string Name { get; set; }
            public virtual void Display() => Console.WriteLine($"Person {Name}");
        }
        
        class Client2 : Person2
        {
            public override void Display() => Console.WriteLine($"Client {Name}");
        }

        // Now let's declare and use a covariant generic delegate:
        
        // 3!
        
        private static Person2 GetPerson(string name)
        {
            return new Person2 {Name = name};
        }
        
        private static Client2 GetClient(string name)
        {
            return new Client2 {Name = name};
        }
        
        
        // By using out, we can assign a Builder <Person> delegate to a Builder <Client> delegate or a reference to a method that returns the Client value.

        // Consider a 'contravariant generic delegate':
        
        // 4!
        
        private static void PersonInfo(Person2 p) => p.Display();
        private static void ClientInfo2(Client2 cl) => cl.Display();
        
        // Using the in keyword allows you to assign
        // a delegate with a more generic type (GetInfo <Person>) to a delegate with a derived type (GetInfo <Client>).

        // As with generic interfaces, the covariant type parameter only applies to the type of the value returned by the delegate.
        // And the contravariant type parameter only applies to the input arguments of the delegate.
    }
}