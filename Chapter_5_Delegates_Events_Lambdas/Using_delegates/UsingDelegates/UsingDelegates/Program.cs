using System;

namespace UsingDelegates
{
    class Program
    {
        static void Main(string[] args)
        {
            // 3!
            // create a bank account
            Account account = new Account(200);
            // Add a link to the Show_Message method to the delegate
            // and the delegate itself is passed as a parameter to the RegisterHandler method
            account.RegisterHandler(new Account.AccountStateHandler (Show_Message));
            // We try to withdraw money twice in a row
            account.Withdraw(100);
            account.Withdraw(150);
            Console.WriteLine('\n');
            
            // 5!
            Account account2 = new Account(200);
            Account.AccountStateHandler colorDelegate = new Account.AccountStateHandler(Color_Message);
 
            // Add a method reference to the delegate
            account2.RegisterHandler(new Account.AccountStateHandler (Show_Message));
            account2.RegisterHandler(colorDelegate);
            // We try to withdraw money twice in a row
            account2.Withdraw(100);
            account2.Withdraw(150);
 
            // Remove the delegate
            account2.UnregisterHandler(colorDelegate);
            account2.Withdraw(50);
            
        }
        
        // In the last topic, delegates were discussed in detail. However, these examples may not show the true power of delegates,
        // since in this case we can call the methods we need directly without any delegates.
        // However, the biggest strength of delegates is that they allow you to delegate execution to some code from the outside.
        // And at the time of writing the program, we may not know what kind of code will be executed.
        // We just call the delegate. And which method will be directly executed when calling the delegate will be decided later.
        // For example, our classes will be distributed as a separate class library that will be plugged into another developer's project.
        // And this developer will want to define some of his own processing logic, but he cannot change the source code of our class library.
        // And delegates just provide an opportunity to call some action
        // that is set from the outside and which at the time of writing the code may not be known.

        // Let's look at a detailed example. Let's say we have a class describing a bank account:
        
        class Account
        {
            // 1!
            // Declare a delegate
            public delegate void AccountStateHandler(string message);
            // Create a delegate variable
            AccountStateHandler _del;
 
            // 4!
            // Register a delegate
            /*public void RegisterHandler(AccountStateHandler del)
            {
                _del = del;
            }*/
            
            int _sum; // Variable for storing the sum
            
            // 4!
            // Register a delegate
            public void RegisterHandler(AccountStateHandler del)
            {
                _del += del; // add a delegate
            }
            
            // 4!
            // Unregister the delegate
            public void UnregisterHandler(AccountStateHandler del)
            {
                _del -= del; // remove the delegate
            }
 
            public Account(int sum)
            {
                _sum = sum;
            }
 
            public int CurrentSum
            {
                get { return _sum; }
            }
 
            public void Put(int sum)
            {
                _sum += sum;
            }
 
            /*public void Withdraw(int sum)
            {
                if (sum <= _sum)
                {
                    _sum -= sum;
                }
            }*/
            
            // 2!
            public void Withdraw(int sum)
            {
                if (sum <= _sum)
                {
                    _sum -= sum;
 
                    if (_del != null)
                        _del($"The amount {sum} has been withdrawn from the account");
                }
                else
                {
                    if (_del != null)
                        _del("Not enough money in the account");
                }
            }
        }
        
        
        // Suppose, in the case of withdrawing money using the Withdraw method, we need to somehow notify
        // the client himself and, perhaps, other objects about this.
        // To do this, we will create a delegate AccountStateHandler.
        // To use a delegate, we need to create a variable of this delegate, and then assign it a method that will be called by the delegate.

        // So, let's add the following lines to the Account class:
        
        // 1!
        
        // Here, in fact, the same steps are taken as above, and there is almost everything except calling the delegate.
        // In this case, our delegate takes a parameter of type string. Now let's change the Withdraw method as follows:
        
        // 2!
        
        // Now, when we withdraw money through the Withdraw method, we first check if the delegate has a reference
        // to any method (otherwise it is null). And if the method is set, then we call it,
        // passing the appropriate message as a parameter.

        // Now let's test the class in the main program:
        
        // 3!
        
        private static void Show_Message(string message)
        {
            Console.WriteLine(message);
        }
        
        // By running the program, we get two different messages:

        /*
        The amount of 100 has been withdrawn from the account
        Not enough money in the account
        */
        
        // Thus, we have created a callback mechanism for the Account class, which is triggered in case of money withdrawal.
        // Since the delegate is declared inside the Account class, the expression Account.AccountStateHandler is used to access it.

        // Again, the question may arise: why not display a message about the withdrawal in the code of the Withdraw () method?
        // Why do I need to use a delegate?
        
        // The fact is that we do not always have access to the class code. For example,
        // some of the classes can be created and compiled by one person who will not know how these classes will be used.
        // And these classes will be used by another developer.

        // So, here we are printing a message to the console. However, for the Account class, it doesn't matter how this message is displayed.
        // The Account class does not even know what will be done at all as a result of debiting money.
        // It just sends a notification of this through the delegate.
        
        // As a result, if we create a console application, we can output a message to the console through the delegate.
        // If we are creating a graphical Windows Forms or WPF application,
        // then we can display the message in the form of a graphical window. Or you can not just display a message.
        // And, for example, when writing off information about this action in a file or send a notification by e-mail.
        // In general, handle the call to the delegate by any means. And the processing method will not depend on the Account class.
        
        // Although in the example our delegate accepted an address for one method, in reality it can point to several methods at once.
        // In addition, if necessary,
        // we can remove references to the addresses of certain methods so that they are not called when the delegate is called.
        // So, let's change the RegisterHandler method in the Account class
        // and add a new UnregisterHandler method that will remove methods from the list of delegate methods:
        
        // 4!
        
        // The first method combines the _del and del delegates into one, which is then assigned to the _del variable.
        // The second method removes the del delegate. Now let's move on to the main program:
        
        // 5!
        
        private static void Color_Message(string message)
        {
            // Set the symbol color to red
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            // Reset color settings
            Console.ResetColor();
        }
        
        // For testing purposes, we created another method, Color_Message, which displays the same message only in red.
        // A separate variable is created for the first delegate.
        // But there is no big difference between passing both to the account.RegisterHandler method: just in one case,
        // we immediately pass the object created
        // by the account.RegisterHandler constructor (new Account.AccountStateHandler (Show_Message));

        // In the second case, we create a variable and pass it to the account.RegisterHandler (colorDelegate); method.
        
        
        // In the line account.UnregisterHandler (colorDelegate); this method is removed from the delegate's invocation list,
        // so this method will no longer fire. The console output will be in the following form:

        /*
        The amount of 100 has been withdrawn from the account
        The amount of 100 has been withdrawn from the account
        Not enough money in the account
        Not enough money in the account
        The amount of 50 has been withdrawn from the account
        */
    }
}