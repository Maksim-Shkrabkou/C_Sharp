using System;

namespace ThrowingAnExceptionAndTheThrowStatement
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1!
            try
            {
                Console.Write ("Enter string:");
                var message = Console.ReadLine ();
                
                if (message != null && message.Length > 6)
                {
                    throw new Exception("String length is more than 6 characters");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine ($"Error: {e.Message}");
            }
            
            // 2!
            try
            {
                try
                {
                    Console.Write ("Enter string:");
                    var message = Console.ReadLine ();
                    
                    if (message.Length> 6)
                    {
                        throw new Exception ("String length is more than 6 characters");
                    }
                }
                catch
                {
                    Console.WriteLine ("An exception was thrown");
                    throw;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine (ex.Message);
            }
        }
        
        // Usually, the system itself throws exceptions in certain situations, for example, when dividing a number by zero.
        // But C # also allows you to manually throw exceptions using the throw statement.
        // That is, with the help of this operator, we ourselves can create an exception and raise it at runtime.

        // For example, in our program, a string is being input,
        // and we want an exception to be thrown if the length of the string is more than 6 characters:
        
        // 1!
        
        // After the throw operator, an exception object is specified,
        // through the constructor of which we can transmit an error message.
        // Naturally, instead of the Exception type, we can use an object of any other type of exceptions.

        // Then, in the catch block, the exception we thrown will be handled.

        // Similarly, we can throw exceptions anywhere in the program.
        // But there is also another form of using the throw statement, where no exception object is specified after the statement.
        // In this form, the throw statement can only be used in a catch block:
        
        // 2!
        
        // In this case, when you enter a string with a length of more than 6 characters, an exception will be thrown,
        // which will be handled by the inner catch block. However, since this block uses a throw statement,
        // the exception will be passed on to the outer catch block.
    }
}