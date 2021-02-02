using System;
using System.Net.Http;

namespace TypeConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1!
            var employee = new Employee("Tom", "Microsoft");
            Person person = employee;   // conversion from Employee to Person
 
            Console.WriteLine(person.Name);
            Console.WriteLine('\n');
            
            // 2!
            Person person2 = new Client("Bob", "ContosoBank");   // // conversion from Client to Person
            
            // 3!
            object person3 = new Employee("Tom", "Microsoft");   // from Employee to object
            object person4 = new Client("Bob", "ContosoBank");      // from Client to object
            object person5 = new Person("Sam");                         // from Person to object

            // 4!
            var employee6 = new Employee("Tom", "Microsoft");
            Person person6 = employee6;   // conversion from Employee to Person
 
            //Employee employee2 = person;    // this is not possible, you need an explicit transformation
            Employee employee2 = (Employee) person;  // conversion from Person to Employee 
            
            
            // 5!
            // Employee object also represents type object
            object obj = new Employee ("Bill", "Microsoft");
 
            // to access the capabilities of the Employee type, cast the object to the Employee type
            Employee emp = (Employee) obj;
    
            // the Client object also represents the Person type
            Person person7 = new Client ("Sam", "ContosoBank");
            
            // convert from type Person to Client
            Client client = (Client) person7;
            
            
            //6!
            // Employee object also represents type object
            object obj1 = new Employee ("Bill", "Microsoft");
 
            // cast to Person to call the Display method
            ((Person) obj1) .Display (); 
            // or so
            // ((Employee) obj) .Display ();
            
            Console.WriteLine('\n');
 
            // cast to Employee to get the Company property
            string comp = ((Employee) obj1) .Company;
            
            
            // 7!
            Person person8 = new Person("Tom");
            Employee emp8 = person8 as Employee;
            
            if (emp8 == null)
            {
                Console.WriteLine("Conversion failed");
                Console.WriteLine('\n');
            }
            else
            {
                Console.WriteLine(emp.Company);
                Console.WriteLine('\n');
            }

            
            // 8!
            Person person9 = new Person("Tom");
            
            try
            {
                Employee emp9 = (Employee) person9;
                Console.WriteLine(emp9.Company);
                Console.WriteLine('\n');
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine('\n');
            }
            
            
            // 9!
            Person person10 = new Person("Tom");
            
            if(person10 is Employee)
            {
                Employee emp10 = (Employee)person10;
                Console.WriteLine(emp.Company);
            }
            else
            {
                Console.WriteLine("Conversion not valid");
            }
        }
        
        // In the previous chapter, we talked about converting objects of simple types.
        // Now let's touch on the topic of converting class objects. Let's say we have the following class hierarchy:
        
        class Person
        {
            public string Name { get; set; }
            
            public Person(string name)
            {
                Name = name;
            }
            
            public void Display()
            {
                Console.WriteLine($"Person {Name}");
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
 
        class Client : Person
        {
            public string Bank { get; set; }
            
            public Client(string name, string bank) : base(name)
            {
                Bank = bank;
            }
        }
        
        // In this class hierarchy, we can trace the following chain of inheritance:
        // Object (all classes implicitly inherit from the Object type) -> Person -> Employee | Client.
        
        // Moreover, in this class hierarchy, base types are at the top, and derived types are at the bottom.
        
        
        //
        
        
        // !!!Upstream transformation. Upcasting!!!
        
        // Objects of a derived type (which is at the bottom of the hierarchy) also represent the base type.
        // For example, the Employee object is also an object of the Person class.
        // Which, in principle, is natural, since each employee (Employee) is a person (Person).
        // And we can write, for example, like this:
        
        // 1!
        
        // In this case, the variable person, which represents the type Person,
        // is assigned a reference to the Employee object.
        // However, to store a reference to an object of one class into a variable of another class,
        // you must perform a type conversion — in this case, from the type Employee to the type Person.
        // And since Employee inherits from the Person class,
        // an implicit up-conversion is automatically performed - converting to the types
        // that are at the top of the class hierarchy, that is, to the base class.

        // As a result, the variables employee and person will point to the same object in memory,
        // but only the part that represents the functionality of the Person type will be available to the person variable.
        
        // Other upstream transformations are done in a similar way:
        
        // 2!
        
        // Here, the variable person2, which represents the type Person, holds a reference to the Client object,
        // so an implicit bottom-up conversion is also performed from the derived Client class to the base Person type.

        // The upward implicit conversion will also occur in the following case:
        
        // 3!
        
        // Since the object type is basic for all other types, conversion to it will be done automatically.
        
        
        //
        
        
        // Downward transformations. Downcasting
        
        // But besides upstream conversions from derived to base type,
        // there are downcasting or downcasting from base to derived type.
        // For example, in the following code, the person variable stores a reference to the Employee object:
        
        /*
         Employee employee = new Employee("Tom", "Microsoft");
         Person person = employee;   // conversion from Employee to Person
        */
        
        // And the question may arise whether it is possible to access the functionality of the Employee type through
        // a variable of the Person type. But such transformations do not go through automatically,
        // because not every person (Person object) is an employee of the enterprise (Employee object).
        // And for a downward conversion, you need to apply explicit conversions,
        // indicating in parentheses the type to which you want to convert:
        
        // 4!
        
        // Let's look at some examples of transformations:
        
        // 5!
        
        // In the first case, the variable obj is assigned a reference to the Employee object,
        // so we can convert the obj object to any type that is located in the class hierarchy between the type object and Employee.

        // If we need to refer to some individual properties or methods of an object,
        // then we do not need to assign the transformed object to a variable:
        
        // 6!
        
        // At the same time, care must be taken when making such conversions. For example, what happens in the following case:
        
        /*
         * // Employee object also represents type object
         * object obj = new Employee ("Bill", "Microsoft");
         *
         * // cast to Client to get Bank property
         * string bank = ((Client) obj) .Bank; // Error
         * */
        
        // In this case, we will get an error because the obj variable holds a reference to the Employee object.
        // This object is also an object of types object and Person, so we can convert it to these types.
        // But we cannot convert to Client type.

        // Another example:
        
        /*
         Employee emp = new Person("Tom");   // ! Error
 
        Person person = new Person("Bob");
        Employee emp2 = (Employee) person;  // ! Error
        */
        
        
        //
        
        
        // !!!Conversion methods!!!
        
        // First, the as keyword can be used. Using it, the program tries to convert the expression to a specific type,
        // without throwing an exception. If the conversion fails, the expression will contain null:
        
        // 7!
        
        // The second way is to catch the InvalidCastException thrown by the conversion:
        
        // 8!
        
        // The third way is to check the validity of the conversion using the is keyword:
        
        // 9!
        
        // The person is Employee expression tests whether the person variable is an object of type Employee.
        // But since in this case it is clearly not, then such a check will return false, and the conversion will not work.
    }
}