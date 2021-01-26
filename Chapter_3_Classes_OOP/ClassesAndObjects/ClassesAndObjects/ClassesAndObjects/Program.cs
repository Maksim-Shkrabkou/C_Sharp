using System;

namespace ClassesAndObjects
{
    class Program
    {
        //C # is a complete object-oriented language.
        //This means that a C # program can be represented as interconnected interacting objects.

        // A description of an object is a class, and an object represents an instance of that class.
        // You can also draw the following analogy.
        // We all have some idea of a person who has a name, age, some other characteristics.
        // That is, some template - this template can be called a class.
        // The exact implementation of this pattern may differ, for example, some people have one name,
        // others a different name.
        // And a real person (actually an instance of this class) will represent an object of this class.
        
        // By default, a console application project already contains one Program class,
        // from which program execution begins.

        // Essentially, a class represents a new user-defined type. A class is defined using the class keyword:
        
        // Where is the class defined?
        // A class can be defined inside a namespace, outside a namespace, inside another class.
        // Typically, the classes are placed in separate files.
        // But in this case, let's put a new class in the file where the Program class is located.
        // That is, the Program.cs file will look like this:
        
        class Person
        {
         
            // All the functionality of a class is represented by its members -
            // fields (fields are called class variables), properties, methods, events.
            
            // For example, let's define fields and a method in the Person class:
            
            public string Name;     // name
            public int Age = 18;    // age
 
            public void GetInfo()
            {
                Console.WriteLine($"Name: {Name},  Age: {Age}");
            }
            
        }
        
        // In this case, the Person class represents a person.
        // The name field holds the name and the age field holds the person's age.
        // And the GetInfo method outputs all data to the console.
        // To make all data available outside the Person class,
        // the variables and method are defined with the public modifier.
        // Since the fields are actually the same variables,
        // they can be initialized, as in the case above, the age field is initialized to 18.

        // Since a class is a new type, in the program we can define variables that represent this type.
        // So, here, in the Main method, the variable tom is defined, which represents the Person class.
        // But so far this variable does not point to any object and it is null by default.
        // Therefore, you first need to create an object of the Person class.
        
        
        // !!!
        
        // !!!Constructors!!!
        
        // In addition to ordinary methods, classes also use special methods called constructors.
        // Constructors are called when a new object of this class is created. Constructors perform object initialization.

        // Default constructor
        // If no constructor is defined in a class, a default constructor is automatically created for that class.
        // Such a constructor has no parameters and no body.

        // The Person class above does not have any constructors.
        // Therefore, a default constructor is automatically generated for it. And we can use this constructor.
        // In particular, let's create one object of the Person class:
        
        // The expression new Person () is used to create a Person object.
        // The new operator allocates memory for the Person object. And then the default constructor is called,
        // which takes no parameters. As a result, after the execution of this expression,
        // a section will be allocated in memory where all the data of the Person object will be stored.
        // And the variable tom will receive a reference to the created object.

        // If the constructor does not initialize the values of the object's variables,
        // then they get the default values. For variables of numeric types,
        // this number is 0, and for type strings and classes, it is null (that is, virtually no value).
        
        // !!!Creating constructors!!!
        
        // Above, the default constructor was used to initialize the object.
        // However, we ourselves can define our own constructors:
        
        
        class Person2
        {
            public string Name;
            public int Age;
 
            public Person2() { Name = "Unknown"; Age = 18; }         // 1 constructor
     
            public Person2(string n) { Name = n; Age = 18; }         // 2 constructor
     
            public Person2(string n, int a) { Name = n; Age = a; }   // 3 constructor
     
            public void GetInfo()
            {
                Console.WriteLine($"Name: {Name},  Age: {Age}");
            }
        }
        
        // The class now defines three constructors,
        // each of which takes a different number of parameters and sets the values of the class fields.
        //
        // We use these constructors:
        
        // Moreover, if constructors are defined in the class, then when creating an object,
        // one of these constructors must be used.

        // It is worth noting that starting with C# 9.0 we can shorten the constructor call
        // by removing the type name from it.
        
        
        // !!!
        
        // !!!The this keyword!!!
        
        // The this keyword represents a reference to the current instance of the class.
        // In what situations can it be useful to us?
        // In the example above, three constructors are defined.
        // All three constructors perform the same type of action - they set the values of the name and age fields.
        // But there could have been more of these repetitive actions.
        // And we can not duplicate the functionality of constructors,
        // but simply refer from one constructor to another through the this keyword,
        // passing the necessary values for the parameters:
        
        class Person3
        {
            public string Name;
            public int Age;
 
            public Person3() : this("Unknown")
            {
            }
            
            public Person3(string name) : this(name, 18)
            {
            }
            
            public Person3(string name, int age)
            {
                this.Name = name;
                this.Age = age;
            }
            
            public void GetInfo()
            {
                Console.WriteLine($"Age: {Name}  Name: {Age}");
            }
        }
        
        // In this case, the first constructor calls the second, and the second constructor calls the third.
        //
        // By the number and type of parameters, the compiler knows which constructor is being called.
        // For example, in the second constructor:
        
        /*
         * public Person(string name) : this(name, 18)
         * {
         * }
         */
        
        // There is a call to the third constructor, to which two values are passed.
        // Moreover, at the beginning it will be the third constructor that will be executed,
        // and only then the code of the second constructor.

        // It is also worth noting that in the third constructor, the parameters are named the same as the class fields.
        
        /*
         * public Person(string name, int age)
         * {
         *   this.name = name;
         *   this.age = age;
         * }
         */
        
        //And to distinguish between parameters and fields of a class,
        //the fields of a class are accessed through the this keyword.
        
        //So, in the expression this.name = name;
        //the first part of this.name means that name is a field of the current class,
        //not the name of the name parameter. If our parameters and fields were named differently,
        //then it would be unnecessary to use the word this. Also, through the this keyword,
        //you can refer to any field or method.
        
        
        // !!!
        
        // !!!Object initializers!!!
        
        // Initializers can be used to initialize class objects.
        // Initializers represent passing values in curly braces to the available fields and properties of an object:
        
        /*
         * Person tom = new Person { Name = "Tom", Age=31 };
         * tom.GetInfo();          // Name: Tom,  Age: 31
         */
        
        // Using an object initializer, you can assign values to all available fields and properties of an object at the time of creation without explicitly calling the constructor.

        // Consider the following points when using initializers:
        
        // Using the initializer, we can set the values of only fields and object properties available from the external code.
        // For example, in the example above, the name and age fields are public, so they are accessible from anywhere in the program.

        // !!!The initializer is executed after the constructor,!!!
        // so if the values of the same fields and properties are set in both the constructor and the initializer,
        // the values set in the constructor are replaced by the values from the initializer.
        
        static void Main(string[] args)
        {
            Person tom = new Person();
            tom.GetInfo(); // Name: ,  Age: 18 
 
            tom.Name = "Tom";
            tom.Age = 34;
            tom.GetInfo(); // Name: Tom,  Age: 34
            Console.WriteLine('\n');
            
            //
            
            Person2 tom2 = new Person2();                  // call the 1st constructor without parameters
            Person2 bob = new Person2("Bob");           // call the 2nd constructor with one parameter
            Person2 sam = new Person2("Sam", 25);     // call the 3rd constructor with two parameters
     
     
            bob.GetInfo();          // Name: Bob,  Age: 18
            tom2.GetInfo();         // Name: Unknown,  Age: 18
            sam.GetInfo();          // Name: Sam,  Age: 25
            
            
            // !!!C# 9!!!
            
            // Moreover, if constructors are defined in the class, then when creating an object,
            // one of these constructors must be used.

            // It is worth noting that starting with C# 9.0 we can shorten the constructor call
            // by removing the type name from it:

            Person2 tom3 = new ();                  // similarly new Person2();
            Person2 bob2 = new ("Bob");           // similarly new Person2("Bob");
            Person2 sam2 = new ("Sam", 25);     // similarly new Person2("Sam", 25);
            
        }
    }
}