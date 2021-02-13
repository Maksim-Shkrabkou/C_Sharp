using System;

namespace DefiningInterfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1!
            Console.WriteLine(IMovable.maxSpeed);
            Console.WriteLine(IMovable.minSpeed);
            Console.WriteLine('\n');
            
            // Console.WriteLine(IMovable2.maxSpeed); Error (private static)
            Console.WriteLine(IMovable2.minSpeed);
            Console.WriteLine('\n');
            
            // 2!
            Console.WriteLine(IMovable5.MaxSpeed);
            IMovable5.MaxSpeed = 65;
            Console.WriteLine(IMovable5.MaxSpeed);
            var time = IMovable5.GetTime(100, 10);
            Console.WriteLine(time);
            Console.WriteLine('\n');
        }
        
        // An interface represents a reference type that can define some functionality - a set of methods and properties without implementation.
        // This functionality is then implemented by classes and structures that use these interfaces.

        // !!!Interface definition!!!
        
        // The interface keyword is used to define an interface.
        // Typically, interface names in C # begin
        // with a capital I, for example, IComparable, IEnumerable (the so-called Hungarian notation),
        // but this is not a requirement, but more of a programming style.
        
        // What can an interface define? In general, interfaces can define the following entities:

        // Methods

        // Properties

        // Indexers

        // Events

        // Static fields and constants (since C # 8.0)

        // However, interfaces cannot define non-static variables.
        // For example, the simplest interface that defines all these components:
        
        interface IMovable
        {
            // constant
            const int minSpeed = 0; // minimum speed
            
            // static variable
            static int maxSpeed = 60; // maximum speed
            
            // method
            void Move(); // traffic

            // property
            string Name { get; set; } // name
     
            delegate void MoveHandler(string message); // define a delegate for the event
            
            // event
            event MoveHandler MoveEvent; // motion event
        }
        
        
        // In this case, the IMovable interface is defined, which represents some moving object.
        // This interface contains various components that describe the capabilities of a moving object.
        // That is, the interface describes some functionality that a moving object should have.

        // Methods and properties of an interface may not have an implementation,
        // in this they converge with abstract methods and properties of abstract classes.
        // In this case, the interface defines a Move method that will represent some movement.
        // It has no implementation, takes no parameters, and returns nothing.
        
        // The same goes for the Name property in this case. At first glance, it looks like an automatic property.
        // But in reality, this is a definition of a property in an interface that has no implementation, not an auto-property.

        // Another point in the declaration of an interface: if its members - methods and properties do not have access modifiers,
        // but in fact, by default, access is 'public',
        // since the purpose of the interface is to define the functionality for its implementation by the class.
        // This also applies to constants and static variables, which are private by default in classes and structures.
        // In interfaces, they have the public modifier by default.
        // And for example, we could refer to the minSpeed constant and the maxSpeed variable of the IMovable interface:
        
        // 1!
        
        // But also, starting from version C # 8.0, we can explicitly specify access modifiers for interface components:
        
        interface IMovable2
        {
            public const int minSpeed = 0; // minimum speed
            private static int maxSpeed = 60; // maximum speed
            public void Move ();
            protected internal string Name {get; set; } // name
            public delegate void MoveHandler (string message); // define a delegate for the event
            public event MoveHandler MoveEvent; // motion event
        }
        
        // Starting in C # 8.0, interfaces support default method and property implementations.
        // This means that we can define full-fledged methods and properties in interfaces that have their implementation
        // as in ordinary classes and structures. For example, let's define a default implementation of the Move method:
        
        interface IMovable3
        {
            // default method implementation
            void Move()
            {
                Console.WriteLine("Walking");
            }
        }
        
        // With the implementation of default properties in interfaces, the situation is somewhat more complicated,
        // since we cannot define non-static variables in interfaces, therefore,
        // we cannot manipulate the state of an object in interface properties.
        
        // However, we can also define a default implementation for properties:
        
        interface IMovable4
        {
            void Move ()
            {
                Console.WriteLine ("Walking");
            }
            // default property implementation
            // read-only property
            int MaxSpeed { get {return 0; }}
        }
        
        // It is worth noting that if an interface has private methods and properties (that is, with the private modifier),
        // then they must have a default implementation.
        // The same applies to any static methods and properties (not necessarily private):
        
        interface IMovable5
        {
            public const int minSpeed = 0; // minimum speed
            private static int maxSpeed = 60; // maximum speed
            
            // find the time it takes to travel distance distance with speed speed
            static double GetTime (double distance, double speed) => distance / speed;
            
            static int MaxSpeed
            {
                get { return maxSpeed; }
                set
                {
                    if (value> 0) maxSpeed = value;
                }
            }
        }
        
        
        //
        
        
        // !!!Interface access modifiers!!!
        
        // Like classes, interfaces by default have internal access level, that is,
        // such an interface is available only within the current project.
        // But with the public modifier, we can make the interface public:
        
        public interface IMovable6
        {
            void Move();
        }
        
        // It's worth noting that Visual Studio has a special component for adding a new interface in a separate file.
        // To add an interface to a project, you can right-click on the project and select Add-> New Item ... in the context menu
        // that appears and select Interface in the dialog box for adding a new component:
    }
}