using System;

namespace Structures
{
    class Program
    {
        // Along with classes, structs provide another way to create your own data types in C #.
        // Moreover, many primitive types, for example, int, double, etc., are in fact structures.

        // For example, let's define a structure that represents a person:

        struct User
        {
            public string Name;
            public int Age;
 
            public void DisplayInfo()
            {
                Console.WriteLine($"Name: {Name},  Age: {Age}");
            }
        }
        
        // Like classes, structs can store state as variables and define behavior as methods.
        // So, in this case, two variables are defined - name and age to store the name and age of the person,
        // respectively, and the DisplayInfo method to display information about the person.

        
        // !!!
        
        
        // !!!Structure constructors!!!
        
        // Like a class, a struct can define constructors.
        // But unlike a class, we don't need to call a constructor to create a struct object:
        
        /*
         * User tom;
         */
        
        // However, if we create a structure object in this way,
        // then it is imperative to initialize all the fields (global variables) of the structure
        // before getting their values or before calling the structure's methods.
        
        // That is, for example, in the following case, we will receive an error,
        // since the access to the fields and methods occurs before they are assigned initial values:
        
        /*
         * User tom;
         * int x = tom.age;    // Error
         * tom.DisplayInfo();  // Error
         */
        
        // We can also use to create a structure a constructor without parameters,
        // which is in the structure by default and when called,
        // the fields of the structure will be assigned a default value
        // (for example, for numeric types this number is 0):
        
        /*
         * User tom = new User();
         * tom.DisplayInfo();  // Name:   Age: 0
         */
        
        // Note that when using the default constructor,
        // we do not need to explicitly initialize the structure's fields.

        // We can also define our own constructors. For example, let's change the User structure:
        
        struct User2
        {
            public string Name;
            public int Age;
            
            public User2(string name, int age)
            {
                this.Name = name;
                this.Age = age;
            }
            
            public void DisplayInfo()
            {
                Console.WriteLine($"Name: {Name},  Age: {Age}");
            }
        }
        
        // !!! It is important to take into account that if we define a constructor in a structure,
        // then it must initialize all the fields of the structure,
        // as in this case the values for the name and age variables are set.
        
        
        // Just like for a class, you can use an initializer to create a structure:
        
        /*
         * User person = new User { name = "Sam", age = 31 };
         */
        
        
        // But unlike a class, you cannot initialize the structure fields directly when declaring them,
        // for example, as follows:
        
        /*
         * struct User
         * {
         *   public string Name = "Sam";     // ! Error
         *   public int age = 23;            // ! Error
         *
         *   public void DisplayInfo()
         *   {
         *     Console.WriteLine($"Name: {name}  Age: {age}");
         *    }
         * }
         */
        
        static void Main(string[] args)
        {
            //In this case, the tom object is created. It has the values of the global numbers set,
            //and then information about it is displayed.
            User tom;
            tom.Name = "Tom";
            tom.Age = 34;
            tom.DisplayInfo();
            Console.WriteLine('\n');
            
            
            // !!! It is important to take into account that if we define a constructor in a structure,
            // then it must initialize all the fields of the structure,
            // as in this case the values for the name and age variables are set.
            User2 tom2 = new User2("Tom", 34);
            tom2.DisplayInfo();
            Console.WriteLine('\n');
 
            
            // We can also use to create a structure a constructor without parameters,
            // which is in the structure by default and when called,
            // the fields of the structure will be assigned a default value
            // (for example, for numeric types this number is 0):
            User bob = new User();
            bob.DisplayInfo();
            Console.WriteLine('\n');
            
        }
    }
}