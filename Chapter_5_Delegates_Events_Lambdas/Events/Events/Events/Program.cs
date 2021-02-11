using System;

namespace Events
{
    class Program
    {
        delegate void ActionHandler(string message);
        
        static void Main(string[] args)
        {
           // 1!
           var acc = new Account (100);
           acc.Put (20); // add to account 20
           Console.WriteLine ($"Account Amount: {acc.Sum}");
           acc.Take (70); // trying to withdraw 70
           Console.WriteLine ($"Account Amount: {acc.Sum}");
           acc.Take (180); // trying to withdraw 180 from the account
           Console.WriteLine ($"Account Amount: {acc.Sum}");
           Console.WriteLine('\n');
           
           // 2!
           var acc2 = new Account2(100);
           acc2.Notify += DisplayMessage; // Add a handler for the Notify event
           acc2.Put (20); // add to account 20
           Console.WriteLine ($"Account Amount: {acc2.Sum}");
           acc2.Take (70); // trying to withdraw 70
           Console.WriteLine ($"Account Amount: {acc2.Sum}");
           acc2.Take (180); // trying to withdraw 180 from the account
           Console.WriteLine ($"Account Amount: {acc2.Sum}");
           Console.WriteLine('\n');
           
           // 3!
           Account2 acc3 = new Account2(100);
           acc3.Notify += DisplayMessage; // add a DisplayMessage handler
           acc3.Notify += DisplayRedMessage; // add a DisplayMessage handler
           acc3.Put(20); // add to account 20
           acc3.Notify -= DisplayRedMessage; // remove the DisplayRedMessage handler
           acc3.Put (20); // add to account 20
           Console.WriteLine('\n');
           
           // 4!
           Account2 acc4 = new Account2(100);
           // set up a delegate that points to the DisplayMessage method
           acc4.Notify += new Account2.AccountHandler(DisplayMessage);
           // set as a handler for the DisplayMessage method
           acc4.Notify += DisplayMessage; // add a DisplayMessage handler
           acc4.Put(20); // add to account 20
           Console.WriteLine('\n');
           
           // 5!
           
           Account2 acc5 = new Account2(100);
           
           acc5.Notify += delegate(string mes)
           {
               Console.WriteLine(mes);
           };
           
           acc5.Put(20);
           Console.WriteLine('\n');
           
           // 6!
           Account2 acc6 = new Account2(100);
           acc6.Notify += (mes) => Console.WriteLine(mes);
           acc6.Put(20);
           Console.WriteLine('\n');
           
           // 7!
           Account3 acc7 = new Account3(100);
           acc7.Notify += DisplayMessage; // add a DisplayMessage handler
           acc7.Put(20); // add to account 20
           acc7.Notify -= DisplayMessage; // remove the DisplayRedMessage handler
           acc7.Put (20); // add to account 20
           Console.WriteLine('\n');
           
           // 8!
           Account4 acc8 = new Account4(100);
           acc8.Notify += DisplayMessage;
           acc8.Put(20);
           acc8.Take(70);
           acc8.Take(150);
        }
        
        // Events signal the system that a certain action has occurred. And if we need to track these actions, then just we can apply events.

        // For example, take the following class that describes a bank account:
        
        class Account
        {
            public Account (int sum)
            {
                Sum = sum;
            }
            
            // amount on the account
            public int Sum {get; private set;}
            
            // adding funds to the account
            public void Put (int sum)
            {
                Sum += sum;
            }
            
            // debiting funds from the account
            public void Take (int sum)
            {
                if (Sum >= sum)
                {
                    Sum -= sum;
                }
            }
        }
        
        
        // In the constructor, we set the initial amount, which is stored in the Sum property.
        // Using the Put method, we can add funds to the account, and using the Take method, on the contrary,
        // we can withdraw money from the account.
        // Let's try to use the class in the program - create an account, deposit and withdraw money from it:
        
        // 1!
        
        // Console output:

        /*
        Account amount: 120
        Account amount: 50
        Account amount: 50
        */
        
        //All operations work as expected. But what if we want to notify the user about the results of his operations.
        //We could, for example, change the Put method to do this:
        
        /*public void Put (int sum)
        {
            Sum += sum;
            Console.WriteLine ($ "Received: {sum}");
        }*/
        
        // It seemed that now we will be notified of the operation by seeing the corresponding message on the console.
        // But there are a number of remarks here. At the time of class definition,
        // we may not know exactly what action we want to perform in the Put method in response to the addition of money.
        // This can be output to the console, or maybe we want to notify the user by email or sms.
        // Moreover, we can create a separate class library that will contain this class, and add it to other projects.
        // And already from these projects to decide what action should be performed.
        
        // We might want to use the Account class in a graphical application
        // and display when added to an account in a graphical message rather than the console.
        // Or our class library will be used by another developer
        // who has his own opinion on what to do when added to the account. And we can solve all these questions using events.
        
        
        //
        
        
        // !!!Defining and Raising Events!!!
        
        // Events are declared in the class using the event keyword, followed by the type of delegate that represents the event:
        
        /*
        delegate void AccountHandler(string message);
        private event AccountHandler Notify;
        */
        
        
        // In this case, we first define the AccountHandler delegate, which takes one parameter of type string.
        // Then, using the event keyword, an event named Notify is defined, which is represented by the AccountHandler delegate.
        // The name for the event can be arbitrary, but in any case it must represent some kind of delegate.

        // Having defined an event, we can call it in the program as a method using the event name:
        
        /*
         * Notify("An action has occurred");
         */
        
        // Since the Notify event is an AccountHandler delegate that takes one parameter of type string - a string,
        // we need to pass a string to it when we call the event.

        // However, when calling events, we can face the fact that the event is null if no handler is defined for it.
        // Therefore, when calling an event, it is better to always check for null. For example, like this:

        /*
         * if (Notify! = null)
         *      Notify("An action has occurred");
         */
        
        // Or like this:
        
        /*
         * Notify?.Invoke("An action has occurred");
         */
        
        // In this case, since the event is a delegate, we can call it using the Invoke() method,
        // passing in the necessary values for the parameters.

        // Put it all together and create and fire an event:
        
        class Account2
        {
            public delegate void AccountHandler (string message);
            public event AccountHandler Notify; // 1.Defining the event
            
            public Account2 (int sum)
            {
                Sum = sum;
            }
            
            public int Sum {get; private set;}
            
            public void Put(int sum)
            {
                Sum += sum;
                Notify?.Invoke($"Received: {sum}"); // 2.Calling the event
            }
            
            public void Take(int sum)
            { 
                if (Sum >= sum)
                {
                    Sum -= sum;
                    Notify?.Invoke($"Withdrawn from account: {sum}"); // 2.Calling the event
                }
                else
                {
                    Notify?.Invoke($"Not enough money in the account. Current balance: {Sum}"); ;
                }
            }
        }
        
        // Now, using the Notify event, we notify the system that funds have been added
        // and that funds are withdrawn from the account or there are not enough funds in the account.
        
        
        //
        
        
        
        // !!!Adding an event handler!!!
            
        // An event can have one or more handlers associated with it.
        // Event handlers are exactly what gets executed when events are called. Methods are often used as event handlers.
        // Each event handler must match the delegate that represents the event in terms of the parameter list and return type. To add an event handler, use the + = operation:
        
        /*
         *Notify + = event handler;
         */
        
        // Let's define handlers for the Notify event to receive the required notifications in the program:
        
        private static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
        
        
        // In this case, the DisplayMessage method is used as a handler,
        // which matches the AccountHandler delegate in the parameter list and return type.
        // As a result, when the Notify?.Invoke() event is called, the DisplayMessage method will be called,
        // which for the message parameter will be passed a string that is passed to Notify?.Invoke().
        // In DisplayMessage, we simply display the message received from the event, but any logic could be defined.

        // If in this case the handler had not been set, then nothing would happen when the Notify?.Invoke() event was called,
        // since the Notify event would have been null.

        // Console output of the program:
        
        /*
        Account received: 20
        Account amount: 120
        Withdrawn from account: 70
        Account amount: 50
        There is not enough money in the account. Current balance: 50
        Account amount: 50
        */
        
        // Now we can separate the Account class into a separate class library and add it to any project.
        
        
        //
        
        
        // Adding and removing handlers
        
        // For one event, you can install several handlers and then remove them at any time.
        // To remove handlers, use the -= operation. For example:
        
        // 3!

        private static void DisplayRedMessage(string message)
        {
            // Set the symbol color to red
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            // Reset color settings
            Console.ResetColor();
        }
        
        // Console output:

        /*
        Account received: 20
        Account received: 20
        Account received: 20
        */
        
        // Not only regular methods can be used as handlers, but also delegates, anonymous methods, and lambda expressions.
        // Using delegates and methods:
        
        // 4!
        
        // In this case, there will be no difference between the two handlers.

        // Setting an anonymous method as a handler:
        
        // 5!
        
        // Setting as a handler for a lambda expression:
        
        // 6!
        
        
        //
        
        
        // !!!Handler management!!!
        
        // With the help of the add / remove special accessors, we can control the addition and removal of handlers.
        // Typically, this functionality is rarely needed, but we can still use it. For example:
        
        class Account3
        {
            public delegate void AccountHandler (string message);
            private event AccountHandler _notify;
            
            public event AccountHandler Notify
            {
                add
                {
                    _notify += value;
                    Console.WriteLine ($"{value.Method.Name} added");
                }
                remove
                {
                    _notify -= value;
                    Console.WriteLine ($"{value.Method.Name} deleted");
                }
            }
            
            public Account3 (int sum)
            {
                Sum = sum;
            }
            
            public int Sum {get; private set;}
            
            public void Put (int sum)
            {
                Sum += sum;
                _notify?.Invoke($"Received: {sum}");
            }
 
            public void Take (int sum)
            {
                if (Sum >= sum)
                {
                    Sum -= sum;
                    _notify?.Invoke($"Account withdrawn: {sum}");
                }
                else
                {
                    _notify?.Invoke($"Not enough money in the account. Current balance: {Sum}"); ;
                }
            }
        }
        
        // The event definition is now split into two parts. First, we just define a variable through which we can call associated handlers:
        
        /* private event AccountHandler _notify;*/
        
        //In the second part, we define the add and remove accessors.
        //The add accessor is called when a handler is added, that is, during the += operation.
        //The added handler is available through the value keyword.
        //Here we can get information about the handler (for example, the name of the method via value.Method.Name)
        //and define some logic. In this case, for simplicity, a message is simply printed to the console:

        /*
            add
           {
               _notify + = value;
               Console.WriteLine ($ "{value.Method.Name} added");
           }*/            
    
        // The remove block is called when a handler is removed. Similarly, here you can set some additional logic:
    
        /*
        remove
        {
            _notify - = value;
            Console.WriteLine ($ "{value.Method.Name} deleted");
        }
        */

        // Inside the class, the event is also called through the _notify variable.
        // But to add and remove handlers in the program, just Notify is used:
        
        // 7!
        
        // Console output of the program:

        /*
        DisplayMessage added
        Account received: 20
        DisplayMessage removed
        */
        
        
        //
        
        
        // !!!AccountEventArgs Event Data Class!!!
        
        // Often, when an event occurs, an event handler needs to pass some information about the event.
        // For example, let's add a new class AccountEventArgs to our program with the following code:
        
        class AccountEventArgs
        {
            // Message
            public string Message {get;}
            
            // The amount by which the account has changed
            public int Sum {get;}
 
            public AccountEventArgs (string mes, int sum)
            {
                Message = mes;
                Sum = sum;
            }
        }
        
        // This class has two properties:
        // Message - for storing the displayed message and Sum - for storing the amount by which the account has changed.

        // Now let's apply the AccoutEventArgs class, changing the Account class as follows:

        class Account4
        {
            public delegate void AccountHandler(object sender, AccountEventArgs e);

            public event AccountHandler Notify;

            public Account4(int sum)
            {
                Sum = sum;
            }

            public int Sum { get; private set; }

            public void Put(int sum)
            {
                Sum += sum;
                Notify?.Invoke(this, new AccountEventArgs($"Received {sum}", sum));
            }

            public void Take(int sum)
            {
                if (Sum >= sum)
                {
                    Sum -= sum;
                    Notify?.Invoke(this,
                        new AccountEventArgs($"Amount {sum} has been withdrawn from the account", sum));
                }
                else
                {
                    Notify?.Invoke(this, new AccountEventArgs("Not enough money in the account", sum));
                }
            }
        }
        
        // Compared to the previous version of the Account class, here only the number of parameters for the delegate has changed and, accordingly,
        // the number of parameters when the event is called. They now also accept an AccountEventArgs object,
        // which stores information about the event as retrieved through the constructor.

        // Now let's change the main program:
        
        // 8!
        
        private static void DisplayMessage(object sender, AccountEventArgs e)
        {
            Console.WriteLine($"Transaction amount: {e.Sum}");
            Console.WriteLine(e.Message);
        }
        
        // Compared to the previous version, here we only change the number of parameters and the essence of their use in the DisplayMessage handler.
    }
}