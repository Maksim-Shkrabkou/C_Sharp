using System;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1!
            var account1 = new Account { Sum = 5000 };
            var account2 = new Account { Sum = 4000 };
            account1.Id = 2;
            account2.Id = "4356";
            int id1 = (int)account1.Id;
            string id2 = (string)account2.Id;
            Console.WriteLine(id1);
            Console.WriteLine(id2);
            Console.WriteLine('\n');

            // 2!
            Account<int> account3 = new Account<int> { Sum = 5000 };
            Account<string> account4 = new Account<string> { Sum = 4000 };
            account3.Id = 2;        // no boxing needed
            account4.Id = "4356";
            int id3 = account3.Id;  // no unboxing needed
            string id4 = account4.Id;
            Console.WriteLine(id3);
            Console.WriteLine(id4);
            Console.WriteLine('\n');
            
            // 3!
            Account3<int> account5 = new Account3<int> { Sum = 5000 };
            Account3<int>.session = 5436;

            Account3<string> account6 = new Account3<string> { Sum = 4000 };
            Account3<string>.session = "45245";
 
            Console.WriteLine(Account3<int>.session);      // 5436
            Console.WriteLine(Account3<string>.session);   // 45245
            Console.WriteLine('\n');

            
            // 4!
            
            Account<int> acc1 = new Account<int> { Id = 1857, Sum = 4500 };
            Account<int> acc2 = new Account<int> { Id = 3453, Sum = 5000 };
 
            Transaction<Account<int>, string> transaction1 = new Transaction<Account<int>, string>
            {
                FromAccount = acc1,
                ToAccount = acc2,
                Code = "45478758",
                Sum = 900
            };
            
            // 5!
            
            int x = 7;
            int y = 25;
            Swap <int> (ref x, ref y); // or so Swap (ref x, ref y);
            Console.WriteLine ($"x = {x} y = {y}"); // x = 25 y = 7
 
            string s1 = "hello";
            string s2 = "bye";
            Swap <string> (ref s1, ref s2); // or so Swap (ref s1, ref s2);
            Console.WriteLine ($"s1 = {s1} s2 = {s2}"); // s1 = bye s2 = hello
        }
        
        // In addition to common types,
        // the .NET framework also includes generic types (generics) as well as generic method creation.
        // To understand the peculiarities of this phenomenon,
        // first let's look at the problem that could have been before generic types.
        // Let's take a look at an example. Let's say we define a class to represent a bank account.
        // For example, he could do the following:
        
        /*class Account
        {
            public int Id { get; set; }
            public int Sum { get; set; }
        }*/

        
        // The Account class defines two properties: Id - a unique identifier and Sum - the amount on the account.

        // Here the ID is set as a numeric value, that is, bank accounts will have the values 1, 2, 3, 4, and so on.
        // However, it is also common to use string values for the identifier.
        // Numeric and string values both have their pros and cons.
        // And at the time of writing the class,
        // we may not know exactly what is better to choose for storing the identifier - a string or a number.
        // Or, perhaps this class will be used by other developers who may have their own opinion on this issue.
        
        class Account
        {
            public object Id { get; set; }
            public int Sum { get; set; }
        }
        
        // This class could then be used to create bank accounts in the program:
        
        // 1!
        
        // Everything seems to work great, but this solution is not very optimal.
        // The fact is that in this case we are faced with such phenomena as boxing and unboxing.
        
        // So, when assigning a value of type int to the Id property, this value is packed into the Object type:
        
       // account1.Id = 2; // boxing into int values into Object type
       
       // To get the data back into a variable of int types, you need to unpack:
           
       // int id1 = (int) account1.Id; // Unpacking into int type
       
       // Boxing involves converting an object of a value type (such as int) to type object.
       // When packaging, the common language CLR wraps the value in an object of type System.Object
       // and stores it in the managed heap. Unboxing, on the other hand,
       // involves converting an object of type object to a value type.
       // Packing and unpacking will degrade performance as the system needs to make the necessary changes.

       // Besides, there is another problem - the problem of type safety. 
       
       // Account account2 = new Account {Sum = 4000};
       // account2.Id = "4356";
       // int id2 = (int) account2.Id; // Exception InvalidCastException
       
       
       // We may not know which particular object represents the Id,
       // and when trying to get a number in this case, we will encounter an InvalidCastException.

        // These problems were intended to eliminate generic types (also often called generic types).
        // Generic types allow you to specify a specific type to be used.
        // Therefore, let's define the Account class as generic:
        
        class Account<T>
        {
            public T Id { get; set; }
            public int Sum { get; set; }
        }
        
        // The angle brackets in the description for class Account <T> indicate that the class is generic,
        // and the type T enclosed in angle brackets will be used by that class.
        // It is not necessary to use the letter T, it can be any other letter or character set.
        // And now we do not know what kind of type it will be, it can be any type.
        // Therefore, the parameter T in angle brackets is also called a generic parameter,
        // since any type can be substituted for it.

        // For example, instead of the T parameter, you can use an int object,
        // that is, a number that represents an account number.
        // It can also be a string object, or any other class or structure:
        
        // 2!
        
        // Since the Account class is generic, when defining a variable after the type name in angle brackets,
        // you must specify the type that will be used instead of the universal parameter T.
        // In this case, the Account objects are typed with int and string types:
        
        /*
         Account <int> account1 = new Account <int> {Sum = 5000};
         Account <string> account2 = new Account <string> {Sum = 4000};
         */
        
        // Therefore, the first account1 object has the Id property of type int, and the account2 object has the string type.

        //When we try to assign the value of the Id property to a variable of a different type, we get a compilation error:
        
        /*
         Account <string> account2 = new Account <string> {Sum = 4000};
         account2.Id = "4356";
         int id1 = account2.Id; // compilation error
         */
        
        // This avoids type safety problems. Thus, by using a generic version of the class,
        // we reduce execution time and potential errors.
        
        
        //
        
        
        // !!!Default values!!!
        // Sometimes it becomes necessary to assign some initial value to variables of generic parameters, including null. But we cannot assign it directly:

        /*
         * T id = null;
         */
        
        // In this case, we need to use the 'default(T)' statement. It assigns null to reference types and 0 to value types:

        class Account2<T>
        { 
            T _id = default(T);
        }
        
        
        //
        
        
        // !!!Generic Class Static Fields!!!
        
        // When typing a generic class with a specific type, its own set of static members will be created.
        // For example, the Account class defines the following static field:

        
        class Account3 <T>
        {
            public static T session;
     
            public T Id {get; set; }
            public int Sum {get; set; }
        }
     
        // Now we type the class with two types int and string:
        
        // 3!
        
        // As a result, a session variable will be created for Account <string> and for Account <int>.
        
        
        //
        
        
        // !!!Using multiple generic parameters!!!
        
        // Generics can use multiple generic parameters at the same time, which can represent different types:
        
        class Transaction <U, V>
        {
            public U FromAccount {get; set; }   // from which account the transfer
            public U ToAccount {get; set; }     // to which account the transfer
            public V Code {get; set; }          // operation code
            public int Sum {get; set; }         // transfer amount
        }
        
        // The Transaction class uses two generic parameters here. Let's apply this class:
        
        // 4!
        
        // Here the Transaction object is typed by the types Account <int> and string.
        // That is, the Account <int> class is used as the universal parameter U,
        // and the string type is used for the V parameter. At the same time, as you can see,
        // the class with which Transaction is typed is itself generic.

        
        //
        
        
        // !!!Generalized methods!!!
        
        // In addition to generic classes,
        // you can also create generic methods that will use generic parameters in the same way. For example:
        
        // 5!
        
        public static void Swap<T>(ref T x, ref T y)
        {
            T temp = x;
            x = y;
            y = temp;
        }
        
        
        // This defines a generic Swap method that takes parameters by reference and changes their values.
        // Moreover, in this case, it does not matter what type these parameters represent.

        // In the Main method, we call the Swap method, type it with a certain type and pass some values to it.
    }
}