using System;

namespace StaticMembersAndStaticModifier
{
    class Program
    {
        static void Main(string[] args)
        {
            
            // 1!
            Console.WriteLine(Account.bonus);      // 100
            Account.bonus += 200;
         
            var account1 = new Account(150);
            Console.WriteLine(account1.totalSum);   // 450
 
 
            var account2 = new Account(1000);
            Console.WriteLine(account2.totalSum);   // 1300
            Console.WriteLine('\n');
            
            // 2!
            var user1 = new User();
            var user2 = new User();
            var user3 = new User();
            var user4 = new User();
            var user5 = new User();

            User.DisplayCounter(); // 5
            Console.WriteLine('\n');
            
            // 3!
            var user21 = new User2(); // here the static constructor will fire
            var user22 = new User2();
        }
        
        // In addition to ordinary fields, methods, properties, a class can have static fields, methods, properties.
        // Static fields, methods, properties refer to the entire class,
        // and it is not necessary to create an instance of the class to refer to such class members. For example:
        
        // 1!
        
        class Account
        {
            public static decimal bonus = 100;
            public decimal totalSum;
            
            public Account(decimal sum)
            {
                totalSum = sum + bonus; 
            }
        }
        
        // In this case, the Account class has two fields: bonus and totalSum.
        // The bonus field is static, so it stores the state of the class as a whole,
        // not a separate object. And so we can refer to this field by the class name:
        
        /*
         * Console.WriteLine(Account.bonus);
         * Account.bonus += 200;
         */
        
        // At the memory level, a section in memory will be created for static fields,
        // which will be common to all objects of the class.
        
        // !!!In this case, memory for static variables is allocated even if no object of this class has been created!!!.

        
        //
        
        
        // !!!Static properties and methods!!!
        
        // Similarly, we can create and use static methods and properties:
        
        class Account2
        {
            public Account2(decimal sum, decimal rate)
            {
                if (sum < MinSum) throw new Exception("Invalid amount!");
                Sum = sum; Rate = rate;
            }
            
            private static decimal minSum = 100; // minimum allowable amount for all accounts
            public static decimal MinSum
            {
                get { return minSum; }
                set { if(value>0) minSum = value; }
            }
 
            public decimal Sum { get; private set; }    // account amount
            public decimal Rate { get; private set; }   // interest rate
 
            // calculating the amount on the account after a certain period at a certain rate
            public static decimal GetSum(decimal sum, decimal rate, int period)
            {
                decimal result = sum;
                
                for (int i = 1; i <= period; i++)
                    result = result + result * rate / 100;
                
                return result;
            }
        }
        
        // The minSum variable, the MinSum property,
        // and the GetSum method are defined here with the static keyword, that is, they are static.

        // The minSum variable and the MinSum property represent the minimum amount that is allowed to create an invoice.
        // This indicator does not refer to any particular account, but refers to all accounts as a whole.
        // If we change this figure for one account, then it must also change for the other account.
        // That is, unlike the Sum and Rate properties, which store the state of an object,
        // the minSum variable stores the state for all objects of this class.
        
        // The same is with the GetSum method - it calculates the amount
        // in the account after a certain period at a certain interest rate for a certain initial amount.
        // The call and result of this method is independent of a particular object or its state.

        // Thus, variables and properties that store state common to all objects in a class should be defined as static.
        // And also methods that define the behavior common to all objects should also be declared as static.

        // Static members of a class are common to all objects of this class,
        // so they must be referred to by the class name:
        
        /*
         * Account.MinSum = 560;
         * decimal result = Account.GetSum(1000, 10, 5);
         */
        
        // !!!Keep in mind that static methods can only access static members of a class.
        // We cannot refer to non-static methods, fields, properties inside a static method.!!!

        // Static fields are often used to store counters. F
        // or example, let's say we have a User class,
        // and we want to have a counter that lets us know how many User objects have been created:
        
        // 2!
        
        class User
        {
            private static int counter = 0;
            
            public User()
            {
                counter++;
            }
 
            public static void DisplayCounter()
            {
                Console.WriteLine($"Created {counter} objects User");
            }
        }
        
        
        //
        
        
        // !!!Static constructor!!!
        
        // In addition to regular constructors,
        // a class can also have static constructors. Static constructors have the following distinctive features:

        // Static constructors must not have an accessor modifier and take no parameters

        // As with static methods, static constructors cannot use the this keyword to refer to the current class object
        // and can only access static members of the class.

        // Static constructors cannot be called manually in a program.
        // They are executed automatically at the very first creation of an object of this class
        // or at the first call to its static members (if any)
        
        // Static constructors are usually used to initialize static data,
        // or perform actions that only need to be done once.

        // Let's define a static constructor:
        
        // 3!
        class User2
        {
            static User2()
            {
                Console.WriteLine("First user created");
            }
        }
        
        
        //
        
        
        // !!!Static classes!!!
        
        // Static classes are declared with the static modifier
        // and can only contain static fields, properties, and methods.
        
        // For example, if the Account class had only static variables, properties and methods,
        // then it could be declared as static:
        
        static class Account3
        {
            private static decimal minSum = 100; // minimum allowable amount for all accounts
            
            public static decimal MinSum
            {
                get { return minSum; }
                set { if(value>0) minSum = value; }
            }
 
            // calculating the amount on the account after a certain period at a certain rate
            public static decimal GetSum(decimal sum, decimal rate, int period)
            {
                decimal result = sum;
                
                for (int i = 1; i <= period; i++)
                    result = result + result * rate / 100;
                
                return result;
            }
            
            // In C #, an illustrative example of a static class is the Math class,
            // which is used for various mathematical operations.
        }
    }
}