using System;

namespace Hiding
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1!
            Person bob = new Person ("Bob", "Robertson");
            bob.Display (); // Bob Robertson
 
            Employee tom = new Employee ("Tom", "Smith", "Microsoft");
            tom.Display (); // Tom Smith works at Microsoft
        }
        
        // In the last topic, we covered defining and overriding virtual methods.
        // Another way to change the functionality of a method inherited from a base class is shadowing / hiding.

        // In fact, hiding represents a definition in a derived class of a method or property
        // that matches the method or property of the base class in name and parameter set.
        // The new keyword is used to hide class members. For example:
        
        class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            
            public Person(string firstName, string lastName)
            {
                FirstName = firstName;
                LastName = lastName;
            }
 
            public void Display()
            {
                Console.WriteLine($"{FirstName} {LastName}");
            }
        }
 
        class Employee : Person
        {
            public string Company { get; set; }
            
            public Employee(string firstName, string lastName, string company)
                : base(firstName, lastName)
            {
                Company = company;
            }
            
            public new void Display()
            {
                Console.WriteLine($"{FirstName} {LastName} working in {Company}");
            }
        }
        
        // It defines the class Person, which represents a person, and the class Employee,
        // which represents an employee of the enterprise.
        // An employee inherits all properties and methods from a person. But in the Employee class,
        // in addition to inherited properties, there is also its own Company property, which stores the name of the company.
        // And we would like to display information about the company along with the first and last name to the console in the Show method.
        // To do this, the new keyword mapping method is defined, which hides the use of this method from the base class.
        
        // In what situations can concealment be used? For example, in the example above,
        // the Display method in the base class is not virtual, we cannot override it,
        // but let's say we are not satisfied with its implementation for the derived class,
        // so we can use hiding to define the functionality we need.

        // We use these classes in the program in the Main method:
        
        // 1!
        
        
        // !!!In a similar way, we can organize the hiding of properties:!!!
        
        class Person2
        {
            protected string name;
            
            public string Name
            {
                get { return name; }
                set { name = value; }
            }
        }
        
        class Employee2 : Person2
        {
            public new string Name
            {
                get { return "Employee " + base.Name; }
                set { name = value; }
            }
        }
        
        // Moreover, if we want to refer specifically to the implementation of a property or method in the base class,
        // then again we can use the base keyword and through it refer to the functionality of the base class.

        // Moreover, we can even apply hiding to variables and constants using the new keyword as well:
        
        class ExampleBase
        {
            public readonly int x = 10;
            public const int G = 5;
        }
        
        class ExampleDerived : ExampleBase
        {
            public new readonly int x = 20;
            public new const int G = 15;
        }
    }
}