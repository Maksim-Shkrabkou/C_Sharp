using System;

namespace TryCatchFinally
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1!  
            try
            {
                int x = 5;
                int y = x / 0;
                Console.WriteLine ($"Result: {y}");
            }
            catch
            {
                Console.WriteLine ("An exception was thrown!");
            }
            finally
            {
                Console.WriteLine ("finally block");
            }
            
            Console.WriteLine ("End of Program");
            Console.WriteLine('\n');
            
            // 2!
            Console.WriteLine ("Enter a number");
            int x2;
            var input = Console.ReadLine();
            
            if (Int32.TryParse (input, out x2))
            {
                x2 *= x2;
                Console.WriteLine ("Square number:" + x2);
            }
            else
            {
                Console.WriteLine ("Invalid input");
            }
        }
        
        // Sometimes, when executing a program, errors occur that are difficult to foresee or foresee,
        // and sometimes even impossible.
        // For example, when transferring a file over a network, the network connection may suddenly drop.
        // such situations are called exceptions.
        // The C # language provides developers with the ability to handle these situations.
        // The try ... catch ... finally construct is designed for this in C #.
        
        /*
         try
        {
     
        }
        catch
        {
     
        }
        finally
        {
     
        }
        */
        
        // When using a try ... catch..finally block, all statements in the try block are executed first.
        // If no exceptions have been thrown in this block, then after its execution the finally block starts to execute.
        // And then the try..catch..finally construct exits.

        // If an exception is thrown in the try block,
        // then normal execution stops and the CLR starts looking for a catch block that can handle the exception.
        // If the desired catch block is found, then it is executed, and after it finishes, the finally block is executed.

        // If the required catch block is not found, then when an exception is thrown, the program will crash.

        // Consider the following example:
        
        /*static void Main(string[] args)
        {
            int x = 5;
            int y = x / 0;
            Console.WriteLine($"Result: {y}");
            Console.WriteLine("End of program");
            Console.Read();
        }*/
        
        // In this case, the number is divided by 0, which will result in an exception being thrown.
        // And when starting the application in debug mode,
        // we will see a window in Visual Studio that informs about the exception.
        
        // In this window, we see that an exception was thrown, which is of type System.DivideByZeroException,
        // that is, an attempt to divide by zero. Using the View Details item, you can view more detailed information about the exception.

        // And in this case, the only thing that remains for us is to complete the execution of the program.

        // To avoid such an abnormal program termination,
        // you should use the try ... catch ... finally construct to handle exceptions.
        // So, let's rewrite the example as follows:
        
        // 1!
        
        
        // In this case, we will again have an exception in the try block, since we are trying to divide by zero.
        // And reaching the line

        // int y = x / 0;
        
        // the program will stop running. The CLR finds the catch block and transfers control to that block.

        // After the catch block, the finally block will be executed.
        
        /*
        An exception was thrown!
        Finally block
        End of program
        */
           
        // Thus, the program will still not perform division by zero and, accordingly,
        // will not display the result of this division, but now it will not crash,
        // and the exception will be handled in the catch block.

        // It should be noted that a try block is required in this construction. With a catch block, we can omit the finally block:
        
        /*
         try
        {
            int x = 5;
            int y = x / 0;
            Console.WriteLine ($ "Result: {y}");
        }
        catch
        {
        Console.WriteLine ("An exception was thrown!");
        }
        */
        
        // Conversely, with a finally block, we can omit the catch block and not handle the exception:

        /*
         try
        {
            int x = 5;
            int y = x / 0;
            Console.WriteLine ($ "Result: {y}");
        }
        finally
        {
        Console.WriteLine ("finally block");
        }*/
    
        // However, although from the point of view of C # syntax, such a construction is quite correct, nevertheless,
        // since the CLR cannot find the necessary catch block, the exception will not be handled, and the program will crash.
        
        
        //
        
        
        
        // !!!Exception handling and conditionals!!!
        
        // A number of exceptional situations can be foreseen by the developer.
        // For example, suppose a program involves entering a number and outputting its square:
        
        /*
        static void Main (string [] args)
        {
            Console.WriteLine ("Enter a number");
            int x = Int32.Parse (Console.ReadLine ());
 
            x * = x;
            Console.WriteLine ("Square number:" + x);
            Console.Read ();
        }
        */
        
        // If the user enters not a number, but a string, some other characters, then the program will fall into an error.
        // On the one hand, this is where the try..catch block can be used to handle a possible error.
        // However, it would be much more optimal to check the validity of the conversion:
        
        // 2!
        
        // The Int32.TryParse () method returns true if the transformation can be performed, and false if it cannot.
        // If the conversion is valid, the variable x will contain the entered number.
        // So, without using try ... catch, you can handle a possible exception.

        // From a performance point of view, using try..catch blocks is more expensive than using conditionals.
        // Therefore, whenever possible, instead of try..catch, it is better to use conditional constructs to check for exceptions.
    }
}