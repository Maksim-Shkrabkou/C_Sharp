using System;

namespace AbstractClassesAndClassMembers
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1!
            Client client = new Client ("Tom", 500);
            Employee employee = new Employee ("Bob", "Apple");
            client.Display ();
            employee.Display ();
            Console.WriteLine('\n');
            
            // 2!
            Person client2 = new Client ("Tom", 500);
            Person employee2 = new Employee ("Bob", "Operator");
            Console.WriteLine('\n');
            
            // 3!
            // Person person = new Person ("Bill"); // Error
        }
        
        // Besides the usual classes, C # has abstract classes. An abstract class is like a regular class.
        // It can also have variables, methods, constructors, properties.
        // The only thing is that the abstract keyword is used when defining abstract classes:
        
        abstract class Human
        {
            public int Length { get; set; }
            public double Weight { get; set; }
        }
        
        // But the main difference is that we cannot use the constructor of an abstract class to create its object.
        // For example, as follows:
        
        // Human h = new Human();
        
        // Why are abstract classes needed? For example, in our banking sector program, we can define two main entities:
        // a bank customer and a bank employee. Each of these entities will be different, for example,
        // for an employee, you need to define his position, and for a client - the amount on the account.
        // Accordingly, Client and Employee will make up separate Client and Employee classes.
        // At the same time, both of these entities can have something in common, for example,
        // first and last name, some other common functionality. And it is better
        // to move this general functionality into some separate class, for example, Person, which describes a person.
        // That is, the Employee (employee) and Client (bank client) classes will derive from the Person class.
        // And since all objects in our system will represent either a bank employee or a client,
        // we will not create objects directly from the Person class. So it makes sense to make it abstract:
        
        abstract class Person
        {
            public string Name { get; set; }
 
            public Person(string name)
            {
                Name = name;
            }
 
            public void Display()
            {
                Console.WriteLine(Name);
            }
        }
 
        class Client : Person
        {
            public int Sum { get; set; }    // account amount
 
            public Client(string name, int sum)
                : base(name)
            {
                Sum = sum;
            }
        }
 
        class Employee : Person
        {
            public string Position { get; set; } // position
 
            public Employee(string name, string position) 
                : base(name)
            {
                Position = position;
            }
        }
        
        // Then we can use these classes:
        
        // 1!

        //Or even like this:

        // 2!
        
        //But we can NOT create a Person object using the constructor of the Person class:
        
        // 3!
        
        // However, despite the fact that we cannot directly call
        // the constructor of the Person class to create an object, nevertheless the constructor
        // in abstract classes can play an important role, in particular,
        // to initialize some variables and properties common to derived classes,
        // as is the case with the property Name. Although the above example does not call the Person constructor,
        // the Client and Employee derived classes can refer to it.
        
        
        //
        
        
        // !!!Abstract class members!!!
        
        // In addition to the usual properties and methods, an abstract class can have abstract class members,
        // which are defined using the abstract keyword and have no functionality. In particular, abstract can be:

        // Methods
        // Properties
        // Indexers
        // Events
        
        // Abstract class members must not have the private modifier.
        // In this case, the derived class must override and implement all abstract methods and properties
        // that are in the base abstract class. When overridden in a derived class,
        // such a method or property is also declared with the override modifier
        // (as with normal overriding virtual methods and properties).
        // It should also be noted that
        // if a class has at least one abstract method (or abstract property, indexer, event),
        // then this class must be defined as abstract.
        
        // Abstract members, like virtual ones, are part of the polymorphic interface.
        // But if in the case of virtual methods we say that the inheriting class inherits the implementation,
        // in the case of abstract methods, the interface represented by these abstract methods is inherited.

        
        //
        
        
        // !!!Abstract methods!!!
        
        // For example, let's make the Display method abstract in the example above:
        
        abstract class Person2
        {
            public string Name { get; set; }
 
            public Person2(string name)
            {
                Name = name;
            }
 
            public abstract void Display();
        }
 
        class Client2 : Person2
        {
            public int Sum { get; set; }    // account amount
 
            public Client2(string name, int sum)
                : base(name)
            {
                Sum = sum;
            }
            
            public override void Display()
            {
                Console.WriteLine($"{Name} have account amount {Sum}");
            }
        }
 
        class Employee2 : Person2
        {
            public string Position { get; set; } // position
 
            public Employee2(string name, string position) 
                : base(name)
            {
                Position = position;
            }
 
            public override void Display()
            {
                Console.WriteLine($"{Position} {Name}");
            }
        }
        
        
        //
        
        
        // !!!Abstract properties!!!
        
        // The use of abstract properties should be noted. Defining them is similar to defining auto properties.
        // For example:
        
        abstract class Person3
        {
            public abstract string Name { get; set; }
        }
 
        class Client3 : Person3
        {
            private string name;
 
            public override string Name
            {
                get => "Mr/Ms. " + name;
                set => name = value;
            }
        }
 
        class Employee3 : Person3
        {
            public override string Name { get; set; }
        }

        // The Person class defines the abstract Name property.
        // It looks like an auto property, but it is not an auto property.
        // Since this property does not have to be implemented, it only has empty get and set blocks.
        // In derived classes, we can override this property to make it a full property (as in the Client class),
        // or make it automatic (as in the Employee class).
        
        
        //

        
        // !!!Refusal to implement abstract members!!!
        
        // The derived class must implement all the abstract members of the base class.
        // However, we can drop the implementation, but in this case the derived class must also be defined as abstract:
        
        abstract class Person4
        {
            public abstract string Name { get; set; }
        }
 
        abstract class Manager4 : Person4
        {
        }
        
        
        //
        
        // !!!Abstract class example!!!
        
        // The system of geometric figures is a textbook example. In reality, there is no geometric figure as such.
        // There is a circle, a rectangle, a square, but there is simply no figure.
        // However, both the circle and the rectangle have something in common and are shapes:
        
        // abstract shape class
        abstract class Figure
        {
            // abstract method to get the perimeter
            public abstract float Perimeter ();
            // abstract method for getting area
            public abstract float Area ();
        }
        
        // derived class of the rectangle
        class Rectangle: Figure
        {
            public float Width {get; set; }
            public float Height {get; set; }
 
            public Rectangle (float width, float height)
            {
                this.Width = width;
                this.Height = height;
            }
            // override getting the perimeter
            public override float Perimeter ()
            {
                return Width * 2 + Height * 2;
            }
            // reassignment of getting area
            public override float Area ()
            {
                return Width * Height;
            }
        }
    }
}