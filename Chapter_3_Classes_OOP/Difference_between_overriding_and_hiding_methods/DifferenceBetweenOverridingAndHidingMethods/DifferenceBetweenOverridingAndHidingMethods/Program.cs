using System;

namespace DifferenceBetweenOverridingAndHidingMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1!
            Person tom = new Employee ("Tom", "Microsoft");
            tom.Display (); // Tom works at Microsoft
            Console.WriteLine('\n');
            
            // 2!
            Person2 tom2 = new Employee2("Tom", "Microsoft");
            tom2.Display();      // Tom
        }
        
        
        // Previously, we discussed two ways to change the functionality of methods inherited
        // from the base class - hiding and overriding. What's the difference between the two?

        // !!!Overriding!!!
        
        // Let's take an example with method overriding:
        
        class Person
        {
            public string Name { get; set; }
            
            public Person(string name)
            {
                Name = name;
            }
            
            public virtual void Display()
            {
                Console.WriteLine(Name);
            }
        }
        
        class Employee : Person
        {
            public string Company { get; set; }
            
            public Employee(string name, string company)
                : base(name)
            {
                Company = company;
            }
 
            public override void Display()
            {
                Console.WriteLine($"{Name} works at {Company}");
            }
        }
        
        // Let's also create an Employee object and pass it to a Person variable:
        
        // 1!
        
        // Now we get a different result than with hiding. And when you call tom.Display (),
        // the implementation of the Display method from the Employee class is executed.

        // To work with virtual methods, the compiler generates a Virtual Method Table (VMT).
        // The addresses of virtual methods are written into it. A separate table is created for each class.

        // When a class object is created,
        // the compiler passes special code to the object's constructor that links the object and the VMT.
        
        // And when a virtual method is called, the address of its VMT is taken from an object.
        // Then the address of the method is retrieved from the VMT and control is passed to it.
        // That is, the process of choosing the implementation of a method is performed during program execution.
        // This is how the virtual method is executed.
        // It should be borne in mind that since the runtime first needs to get the address
        // of the required method from the VMT table, this slightly slows down the program execution.
        
        
        //
        
        
        // !!!Hiding!!!
        
        // Now let's take the same Person and Employee classes, but instead of overriding we use hiding:
        
        class Person2
        {
            public string Name { get; set; }
        
            public Person2(string name)
            {
                Name = name;
            }
 
            public void Display()
            {
                Console.WriteLine(Name);
            }
        }
        
        class Employee2 : Person2
        {
            public string Company { get; set; }
            
            public Employee2(string name, string company)
                : base(name)
            {
                Company = company;
            }
            
            public new void Display()
            {
                Console.WriteLine($"{Name} works at {Company}");
            }
        }
        
        // And let's see what happens in the following case:
        
        // 2!
        
        // The variable tom represents the Person type, but holds a reference to the Employee object.
        // However, when the Display method is called,
        // the version of the method that is defined in the Person class will be executed,
        // and not in the Employee class.
        
        // Why? The Employee class does not override the Display method inherited from the base class in any way,
        // but actually defines a new method. Therefore, when you call tom.Display (),
        // the Display method from the Person class is called.
    }
}