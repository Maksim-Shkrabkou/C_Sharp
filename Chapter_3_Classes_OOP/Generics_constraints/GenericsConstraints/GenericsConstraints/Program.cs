using System;

namespace GenericsConstraints
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1!
            Account acc1 = new Account(1857) { Sum = 4500 };
            Account acc2 = new Account(3453) { Sum = 5000 };
            
            Transaction<Account> transaction1 = new Transaction<Account>
            {
                FromAccount = acc1,
                ToAccount = acc2,
                Sum = 6900
            };
            
            transaction1.Execute();
            Console.WriteLine('\n');
            
            // 2!
            Account<int> acc3 = new Account<int>(1857) { Sum = 4500 };
            Account<int> acc4 = new Account<int>(3453) { Sum = 5000 };
             
            Transaction2<Account<int>> transaction2 = new Transaction2<Account<int>>
            {
                FromAccount = acc3,
                ToAccount = acc4,
                Sum = 6900
            };
            
            transaction1.Execute();
            Console.WriteLine('\n');
            
            // 3!
            /*
             Account<int> acc5 = new Account<int>(1857) { Sum = 4500 };
             Account<int> acc6 = new Account<int>(3453) { Sum = 5000 };
 
            Transact<Account<int>>(acc1, acc2, 900);
            */
        }
        
        // !!!Restrictions on generic types!!!
       
        // With generic parameters, we can use generic classes of any type.
        // However, sometimes it becomes necessary to concretize the type.
        // For example, we have the following class Account, which represents a bank account:
        
        class Account
        {
            public int Id { get; private set;} // account number
            public int Sum { get; set; }
            
            public Account(int _id)
            {
                Id = _id;
            }
        }
        
        // To transfer funds from one account to another, we can define the Transaction class,
        // which will use objects of the Account class to perform all operations.

        // But the Account class can have many heirs: DepositAccount (deposit account), DemandAccount (demand account), etc.
        // And we cannot know which account types will be used in the Transaction class.
        // It is possible that transactions will only be conducted between demand accounts.
        // And in this case, the Account type can be set as a universal parameter:
        
        class Transaction<T> where T: Account
        {
            public T FromAccount {get; set; } // from which account the transfer
            public T ToAccount {get; set; } // to which account the transfer
            public int Sum {get; set; }        // transfer amount
 
            public void Execute()
            {
                if (FromAccount.Sum > Sum)
                {
                    FromAccount.Sum -= Sum;
                    ToAccount.Sum += Sum;
                    Console.WriteLine($"Account {FromAccount.Id}: {FromAccount.Sum}$ +" +
                                      " '\n' +" +
                                      $" Account {ToAccount.Id}: {ToAccount.Sum}$");
                }
                else
                {
                    Console.WriteLine($"Not enough money on account {FromAccount.Id}");
                }
            }
        }
        
        // With the where T: Account clause, we indicate that the type T used must be of the Account class or its inheritor.
        // Thanks to this restriction,
        // we can use all objects of type T inside the Transaction class exactly as Account objects and,
        // accordingly, access their properties and methods.

        // Now let's apply the Transaction class in the program:
        
        // 1!
        
        // Please note that only one class can be used as a constraint.

        // A generic class can also act as a constraint:
        
        // 2!
        
        class Account <T>
        {
            public T Id {get; private set; } // Account number
            public int Sum {get; set; }
            
            public Account (T _id)
            {
                Id = _id;
            }
        }
        
        
        class Transaction2 <T> where T: Account <int>
        {
            public T FromAccount {get; set; }   // from which account the transfer
            public T ToAccount {get; set; }     // to which account the transfer
            public int Sum {get; set; }         // transfer amount
 
            public void Execute ()
            {
                if (FromAccount.Sum> Sum)
                {
                    FromAccount.Sum -= Sum;
                    ToAccount.Sum += Sum;
                    Console.WriteLine ($"Account {FromAccount.Id}: {FromAccount.Sum} $" +
                                       $" \nAccount {ToAccount.Id}: {ToAccount.Sum} $");
                }
                else
                {
                    Console.WriteLine ($"Not enough money on account {FromAccount.Id}");
                }
            }
        }
        
        // In this case, the Transaction class is typed by the Account <int> class.
        // The Account class can be typed by absolutely any type.
        // However, the Transaction class can only use objects of the Account <int> class or its descendants.
        // That is, the following code is wrong and will not work:
        
        
        /*
         Account <string> acc1 = new Account <string> ("34") {Sum = 4500};
         Account <string> acc2 = new Account <string> ("45") {Sum = 5000};
             
        // this cannot be written, since Bank must be typed by the Account <int> class or its inheritor
        Transaction2 <Account <string>> transaction1 = new Transaction2 <Account <string>>
        {
            FromAccount = acc1,
            ToAccount = acc2,
            Sum = 900
        };
        */
        
        // We can use the following types as constraints:

        // Classes

        // Interfaces

        // class - a generic parameter should represent a class

        // struct - generic parameter must represent a structure

        // new () - a generic parameter must represent a type that has a public parameterless constructor

        
        //
        
        
        // !!!Standard restrictions!!!
        
        // There are a number of standard constraints that we can use.
        // In particular, you can specify a restriction so that only structures or other value types are used:
        
        /*
         class Account <T> where T: struct
        {}
        */
        
        // At the same time, it is impossible to use concrete structures as a constraint, unlike classes.

        // You can also set reference types as constraints:
        
        /*
         class Transaction <T> where T: class
        {}
        */
        
        // And you can also use the word new as a constraint to specify a class or structure that has a public parameterless constructor:
        
        /*
         class Transaction <T> where T: new()
        {}
        */
        
        //If several restrictions are specified for a universal parameter, then they must go in a certain order:

        // Class name, class, struct. Moreover, we can simultaneously determine only one of these restrictions

        // Interface name

        // new ()

        // For example:
        
        interface IAccount
        {
            int CurrentSum { get; set;}
        }
        
        class Person
        {
            public string Name { get; set; }
        }
 
        class Transaction3<T> where T: Person, IAccount, new()
        {
 
        }
        
        
        //
        
        
        // !!!Using multiple generic parameters!!!
        
        // If a class uses several universal parameters, then you can sequentially set restrictions to each of them:

        class Transaction<U, V>
            where U: Account<int>
            where V: struct
        {
        }
        
        
        //
        
        
        // !!!Method limitations!!!
        
        // Method restrictions can be used in a similar way:
        
        // 3!
        
        /*public static void Transact<T>(T acc1, T acc2, int sum) where T : Account<int>
        {
            if (acc1.Sum > sum)
            {
                acc1.Sum -= sum;
                acc2.Sum += sum;
            }
            
            Console.WriteLine($"acc1: {acc1.Sum}   acc2: {acc2.Sum}");
        }*/
        
        // The Transact method takes the Account <int> type as a constraint.
    }
}