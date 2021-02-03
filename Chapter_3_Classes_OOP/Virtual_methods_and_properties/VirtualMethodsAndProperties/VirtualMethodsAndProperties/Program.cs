using System;

namespace VirtualMethodsAndProperties
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1!
            Person p1 = new Person("Bill");
            p1.Display(); // calling the Display method from the Person class
 
            Employee p2 = new Employee("Tom", "Microsoft");
            p2.Display(); // calling the Display method from the Person class
            Console.WriteLine('\n');
            
            // 2!
            Person p3 = new Person ("Bill");
            p3.Display (); // call the Display method from the Person class
 
            Employee2 p4 = new Employee2 ("Tom", "Microsoft");
            p4.Display (); // call the Display method from the Employee class
            Console.WriteLine('\n');
            
            // 3!
            LongCredit credit = new LongCredit { Sum = 6000 };
            credit.Sum = 490;
            Console.WriteLine(credit.Sum);
            Console.WriteLine('\n');
            
            // 4!
            Employee3 p5 = new("Nick", "Netflix");
            p5.Display();
            Console.WriteLine('\n');
        }
        
        // When inheriting, it is often necessary to change the functionality of
        // a method in a derived class that was inherited from the base class.
        // In this case, the derived class can override the methods and properties of the base class.

        // The methods and properties that we want to make available for overriding are marked
        // with the virtual modifier in the base class. Such methods and properties are called 'virtual'.

        // And to override a method in a derived class, this method is defined with the 'override' modifier.
        // The overridden method in the derived class must have the same set of parameters as the virtual method
        // in the base class.

        // For example, consider the following classes:
        
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
            
            public Employee(string name, string company) : base(name)
            {
                Company = company;
            }
        }
        
        // Here, the Person class represents a person.
        // The Employee class inherits from Person and represents an employee in an enterprise.
        // This class, in addition to the inherited Name property, has one more property - Company.

        // To make the Display method available for override, this method is defined with the virtual modifier.
        // Therefore, we can override this method, but we do not need to override it.
        // Let's say we are happy with the implementation of the method from the base class.
        // In this case, the Employee objects will use the implementation of the Display method from the Person class:
        
        // 1!
        
        // But we can also override the virtual method.
        // To do this, the inherited class defines a method with the override modifier,
        // which has the same name and set of parameters:
        
        class Employee2 : Person
        {
            public string Company { get; set; }
            
            public Employee2(string name, string company)
                : base(name)
            {
                Company = company;
            }
 
            public override void Display()
            {
                Console.WriteLine($"{Name} working in {Company}");
            }
        }

        // Let's take the objects:
        
        // 2!
        
        // Virtual methods of the base class define the interface of the entire hierarchy,
        // which is in any derived class from the base class, you can override virtual methods.
        //
        // For example, we can define a Manager class that will derive from an employee and also override the Display method.

        // When overriding virtual methods, there are a number of limitations to consider:

        // Virtual and overridden methods must have the same access modifier.
        // That is, if a virtual method is defined using the public modifier,
        // then the overridden method must also have the public modifier.

        // Cannot be overridden or declared as a virtual static method.
     
        
        //
        
        
        // !!!Overriding properties!!!
        
        // Just like methods, you can override properties:
        
        class Credit
        {
            public virtual decimal Sum { get; set; }
        }
        
        class LongCredit : Credit
        {
            private decimal sum;
            
            public override decimal Sum
            {
                get
                {
                    return sum;
                }
                set
                {
                    if(value > 1000)
                    {
                        sum = value;
                    }
                }
            }
        }
        
        // 3!
     
        
        //
        
        
        // !!!Base keyword!!!
        
        // In addition to constructors, we can refer to other members of the base class using the base keyword.
        // In our case, calling base.Display (); would be a call to the Display () method in the Person class:
        
        class Employee3 : Person
        {
            public string Company { get; set; }
  
            public Employee3(string name, string company)
                :base(name)
            {
                Company = company;
            }
  
            public override void Display()
            {
                base.Display();
                Console.WriteLine($"working in {Company}");
            }
        }
        
        // 4!
        
        
        //
        
        
        // !!!Prevent method overriding!!!
        
        // You can also prohibit overriding methods and properties.
        // In this case, they must be declared with the sealed modifier:
        
        class Employee4 : Person
        {
            private string Company { get; set; }
  
            public Employee4(string name, string company)
                : base(name)
            {
                Company = company;
            }
 
            public sealed override void Display()
            {
                Console.WriteLine($"{Name} working in {Company}");
            }
        }
        
        
        // When creating methods with the sealed modifier,
        // keep in mind that sealed is used in conjunction with override, that is, only in overridden methods.

        // And in this case, we will not be able to override the Display method in the class inherited from Employee.
    }
}