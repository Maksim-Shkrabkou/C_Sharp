using System;
using static System.Console;
using static System.Math;
using static NamespacesAliasesAndStaticImport.Geometry;
using printer = System.Console;
using Person = NamespacesAliasesAndStaticImport.User;
using NamespacesAliasesAndStaticImport.AccountSpace;

namespace NamespacesAliasesAndStaticImport
{
    // !!!Namespaces!!!
    
    // All defined classes and structures, as a rule, do not exist by themselves,
    // but are contained in special containers - namespaces.
    //
    // The default Program class is already in the namespace, which is usually the same as the project name:
    
    /*
     * namespace HelloApp
     * {
     *    class Program
     *    {
     *      static void Main(string[] args)
     *      {
     *      }
     *    }
     * }
     */
    
    // The namespace is defined using the namespace keyword followed by the name.
    // So in this case, the full name of the Program class will be HelloApp.Program.

    // The Program class sees all classes that are declared in the same namespace:
    
    /*
     * class Program
    {
        static void Main(string[] args)
        {
            Account account = new Account(4);
        }
    }
    
    class Account
    {
        public int Id { get; private set;} // account number
        public Account(int _id)
        {
            Id = _id;
        }
    }
     */
    
    
    // But in order to use classes from other namespaces, these spaces must be connected using the using directive:
    
    /*
     *  using System;
     *
     *  namespace HelloApp
        {  
        class Program  
        {
            static void Main(string[] args) 
            {
                Console.WriteLine("hello");
            }
        }
        }
     */
    
    // This brings in the System namespace, which defines the Console class.
    // Otherwise, we would have to write the full path to the class:
    
    
    /*
     static void Main(string[] args) 
    {
        System.Console.WriteLine("hello");
    }
    */
    
    // Namespaces can be defined inside other namespaces:
    
    /*
     * using HelloApp.AccountSpace;
    namespace HelloApp
    {  
        class Program  
        {
            static void Main(string[] args) 
            {
                Account account = new Account(4);
            }
        }
 
        namespace AccountSpace
        {
            class Account
            {
                public int Id { get; private set;}
                public Account(int _id)
                {
                    Id = _id;
                }
            }
        } 
    }
     */
    
    
    // In this case, to connect the space, its full path is specified,
    // taking into account external namespaces: using NamespacesAliasesAndStaticImport.AccountSpace;
    
    
    //

    
    // !!! Aliases! !!
    
    // We can use aliases for different classes. Then the program uses its alias instead of the class name.
    // For example, the Console.WriteLine () method is used to display a string on the screen.
    // But now let's set an alias for the Console class:
    
    /*
    using printer = System.Console;
    class Program
    {
        static void Main(string[] args)
        {
            printer.WriteLine("Hello from C#");
            printer.Read();
        }
    }
    */
    
    // With the statement using printer = System.Console,
    // we indicate that the alias for the System.Console class will be printer.
    // This expression has nothing to do with including namespaces at the beginning of the file,
    // although it does use a using statement.
    // This uses the fully qualified class name based on the namespace in which the class is defined.
    // And then the expression printer.WriteLine ("Hello from C #") is used to print the line.
    
    // And another example. Let's define a class and an alias for it:
    
    /*
     *  using Person = HelloApp.User;
        using Printer = System.Console;
        namespace HelloApp
        {
            class Program
            {
                static void Main(string[] args)
                {
                    Person person = new Person();
                    person.name = "Tom";
                    Printer.WriteLine(person.name);
                    Printer.Read();
                }
            }
 
            class User
            {
                public string name;
            }
        }
     */
    
    // The class is named User, but the program uses the alias Person for it.

    
    //
    
    
    // Static import
    
    // Also in C # it is possible to import the functionality of classes.
    // For example, let's import the capabilities of the Console class:
    
    
    /*
     *  using static System.Console;
        namespace HelloApp
        {
        class Program
        {
            static void Main(string[] args)
            {
                WriteLine("Hello from C# 8.0");
                Read();
            }
        }
        }
     */
    
    // The using static statement includes all static methods and properties,
    // as well as constants in the program. And after that, we can omit the name of the class when calling the method.

    // Similarly, you can define your own classes and import them:
    
    /*
     using static System.Console;
     using static System.Math;
     using static HelloApp.Geometry;
     namespace HelloApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                double radius = 50;
                double result = GetArea(radius); //Geometry.GetArea
                WriteLine(result); //Console.WriteLine
                Read(); // Console.Read
            }
        }
 
        class Geometry
        {
            public static double GetArea(double radius)
            {
                return PI * radius * radius; // Math.PI
            }
        }
    }
    */
    
    class Program
    {
        static void Main(string[] args)
        {
            Account account = new Account(4);
            
            //
            
            Console.WriteLine("hello");
            printer.WriteLine('\n');
            
            //
            
            System.Console.WriteLine("Hello");
            printer.WriteLine('\n');

            Account2 account2 = new Account2(5);
            
            //
            
            printer.WriteLine("Hello from C#");
            printer.WriteLine('\n');
            
            //
            
            Person person = new Person();
            person.name = "Tom";
            printer.WriteLine(person.name);
            printer.WriteLine('\n');
            
            //
            
            WriteLine("Hello from C# 8.0");
            WriteLine('\n');
            
            //
            
            double radius = 50;
            double result = GetArea(radius); //Geometry.GetArea
            WriteLine(result); //Console.WriteLine
        }
    }
    
    class Account
    {
        public int Id { get; private set;} // account number
        public Account(int _id)
        {
            Id = _id;
        }
    }
    
    namespace AccountSpace
    {
        class Account2
        {
            public int Id { get; private set;}
            
            public Account2(int _id)
            {
                Id = _id;
            }
        }
    }
    
    class User
    {
        public string name;
    }
    
    class Geometry
    {
        public static double GetArea(double radius)
        {
            return PI * radius * radius; // Math.PI
        }
    }
}