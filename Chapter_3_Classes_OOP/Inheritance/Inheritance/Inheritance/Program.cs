using System;

namespace Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1!
            var p = new Person { Name = "Tom"};
            p.Display();
            p = new Employee { Name = "Sam" };
            p.Display();
            Console.WriteLine('\n');
            
            // 2!
            var p3 = new Person3("Bill");
            p3.Display();
            var emp = new Employee3 ("Tom", "Microsoft");
            emp.Display();
            Console.WriteLine('\n');
            
            // 3!
            var tom = new Employee4("Tom", 22, "Microsoft");
            
            // Person(string name)
            // Person(string name, int age)
            // Employee(string name, int age, string company)
        }
        
        // Inheritance is one of the key points of OOP.
        // By inheritance, one class can inherit the functionality of another class.

        // Suppose we have the following Person class that describes an individual person:
        
        class Person
        {
            private string _name;
 
            public string Name
            {
                get { return _name; }
                set { _name = value; }
            }
            
            public void Display()
            {
                Console.WriteLine(Name);
            }
        }
        
        // But suddenly we needed a class that describes an employee of the enterprise - the Employee class.
        // Since this class will implement the same functfionality as the Person class,
        // since an employee is also a person,
        // it would be rational to make the Employee class a derivative (or inheritance, or subclass) of the Person class,
        // which in turn is called the base class. class or parent (or superclass):
        
        class Employee : Person
        {
     
        }

        // After the colon, we indicate the base class for this class. For the Employee class, the Person is the base,
        // and therefore the Employee class inherits all the same properties, methods, fields that are in the Person class.
        // The only thing that is not passed on in inheritance is the base class constructors.

        // So inheritance implements the is-a (is) relationship,
        // an object of the Employee class is also an object of the Person class:
        
        // 1!
        
        
        // And since the Employee object is also a Person object,
        // we can define the variable like this: Person p = new Employee ().

        // By default, all classes inherit from the base class Object, even if we don't explicitly set inheritance.
        // Therefore, the above classes Person and Employee, in addition to their own methods,
        // will also have classes Object: ToString (), Equals (), GetHashCode () and GetType ().

        // All classes can be inherited by default. However, there are a number of limitations:

        // There is no multiple inheritance, a class can only inherit from one class.
        
        // When creating a derived class,
        // consider the type of access to the base class — the type of access to the derived class
        // must be the same as that of the base class, or more restrictive.
        // That is, if our base class has an internal access type,
        // then a derived class can have an internal or private access type, but not public.

        // However, you should also take into account that
        // if the base and derived class are in different assemblies (projects),
        // then in this case the derived class can inherit only from the class that has the public modifier.

        // If a class is declared with the sealed modifier,
        // then this class cannot be inherited and derived classes cannot be created.
        // For example, the following class does not allow the creation of inheritors:
        
        /*sealed class Admin
        {
        }*/
        
        // You cannot inherit a class from a static class.
        
        
        //
        
        
        // Accessing members of a base class from a derived class
        
        // Let's go back to our Person and Employee classes. Although Employee inherits all functionality
        // from the Person class, let's see what happens in the following case:
        
        /*class Employee2 : Person
        {
            public void Display()
            {
                Console.WriteLine(_name); // Error
            }
        }*/
        
        
        // This code will not work and will throw an error,
        // because the _name variable is declared with the private modifier and
        // therefore only the Person class has access to it.
        // But on the other hand, a public property Name is defined in the Person class, which we can use,
        // so the following code will work fine for us:
        
        class Employee2 : Person
        {
            public void Display()
            {
                Console.WriteLine(Name);
            }
        }
        
        // Thus, a derived class can only access those members of the base class that are defined with the modifiers
        // private protected (if the base and derived classes are in the same assembly),
        // public, internal (if the base and derived classes are in the same assembly), protected, and protected internal.
        
        
        //
        
        
        // !!!Base keyword!!!

        // Now let's add constructors to our classes:
        
        class Person3
        {
            public string Name { get;  set; }
 
            public Person3(string name)
            {
                Name = name;
            }
 
            public void Display()
            {
                Console.WriteLine(Name);
            }
        }
 
        class Employee3 : Person3
        {
            public string Company { get; set; }
 
            public Employee3(string name, string company)
                : base(name)
            {
                Company = company;
            }
        }
        
        // The Person class has a constructor that sets the Name property.
        // Since the Employee class inherits and sets the same Name property,
        // it would be logical not to write the setup code a hundred times,
        // but somehow call the corresponding code of the Person class.
        // In addition, there can be many more properties
        // and parameters that need to be set in the constructor of the base class.

        // With the base keyword we can refer to the base class.
        // In our case, we need to set the name and company in the constructor of the Employee class.
        // But we pass the name for installation to the constructor of the base class, that is, to the constructor
        // of the Person class, using the expression base (name).
        
        // 2!
        
        
        //
        
        
        // !!!Derived Constructors!!!
       
        // Constructors are not passed on to the derived class when inheriting.
        // And if the base class does not define a default constructor without parameters,
        // but only constructors with parameters (as is the case with the base class Person),
        // then in the derived class we must call one of these constructors via the base keyword.
        //
        // For example, remove the constructor definition from the Employee class:
        
        /*class Employee : Person
        {
            public string Company { get; set; }
        }*/
        
        // In this case, we will get an error,
        // since the Employee class does not correspond to the Person class,
        // namely, it does not call the constructor of the base class.
        // Even if we added some kind of constructor that would set all the same properties, we would still get an error:
        
        /*public Employee(string name, string company)
        {
            Name = name;
            Company = company;
        }*/
        
        // That is, in the Employee class, through the 'base' keyword, you must explicitly call the constructor of the Person class:
        
        /*public Employee(string name, string company)
            : base(name)
        {
            Company = company;
        }*/
        
        // Alternatively, we could define a parameterless constructor in the base class:
        
        /*class Person
        {
            // rest of the class code
            // default constructor
            public Person()
            {
                FirstName = "Tom";
                Console.WriteLine("Вызов конструктора без параметров");
            }
        }*/
        
        //Then in any constructor of the derived class, where there is no reference to the constructor of the base class,
        //this default constructor would still be implicitly called. For example, the following constructor
        
        /*public Employee(string company)
        {
            Company = company;
        }*/
        
        // Would actually be equivalent to the following constructor:
        
        /*public Employee(string company)
            :base()
        {
            Company = company;
        }*/
        
        
        //
        
        
        // !!!Constructor Call Order!!!
        
        // When a class constructor is called, the constructors of the base classes are processed first,
        // and only then the constructors of the derived ones. For example, take the following classes:
        
        class Person4
        {
            string _name;
            int _age;
            public Person4(string name)
            {
                this._name = name;
                Console.WriteLine("Person(string name)");
            }
            public Person4(string name, int age) : this(name)
            {
                this._age = age;
                Console.WriteLine("Person(string name, int age)");
            }
        }
        
        class Employee4 : Person4
        {
            string company;
            
            public Employee4(string name, int age, string company) : base(name, age)
            {
                this.company = company;
                Console.WriteLine("Employee(string name, int age, string company)");
            }
        }
        
        // When creating an Employee object:
        
        //3!
        
        // We'll get the following console output:
        
        // Person(string name)
        // Person(string name, int age)
        // Employee(string name, int age, string company)
        
        // !!!As a result, we get the following chain of executions.!!!

        // First, the constructor Employee (string name, int age, string company) is called.
        // It delegates execution to the Person (string name, int age) constructor
            
        // The constructor Person (string name, int age) is called, which itself is not yet executed
        // and passes the execution to the constructor Person (string name)

        // The Person (string name) constructor is called, which passes execution to the constructor
        // of the System.Object class, since this is the default base class for Person.

        // The System.Object.Object () constructor is executed,
        // then the execution returns to the Person (string name) constructor

        // The body of the constructor Person (string name) is executed,
        // then execution is returned to the constructor Person (string name, int age)

        // The body of the constructor Person (string name, int age) is executed,
        // then the execution returns to the constructor Employee (string name, int age, string company)
        
        // The body of the constructor Employee (string name, int age, string company) is executed.
        // As a result, the Employee object is created
        
        // !!!
    }
}