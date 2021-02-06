using System;

namespace CatchBlockAndExceptionFilters
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1!
            var x = 1;
            var y = 0;
 
            try
            {
                int result = x / y;
            }
            catch(DivideByZeroException) when (y==0 && x == 0)
            {
                Console.WriteLine("y must not be 0");
            }
            catch(DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
        // !!!Catch block definition!!!

        // The catch block is responsible for handling the exception, which can take the following forms:
        
        /*
         catch
        {
            // instructions to execute
        }
        */
        
        //Handles any exception that is thrown in the try block.
        //An example of such a block has already been demonstrated above.
        
        
        
        //
        
        
        
        /*
         catch (exception_type)
        {
            // instructions to execute
        }
        */
        
        // Handles only those exceptions that match the type specified in parentheses after the catch statement.

        // For example, let's handle only exceptions of type DivideByZeroException:
        
        
        /*
        try
        {
            int x = 5;
            int y = x / 0;
            Console.WriteLine ($ "Result: {y}");
        }
        catch (DivideByZeroException)
        {
        Console.WriteLine ("DivideByZeroException thrown");
        }
        */
    
        // However, if exceptions of other types other than DivideByZeroException are thrown in the try block,
        // they will not be processed.
        
        
        //
        
        
        /*
         catch (exception_type variable_name)
        {
            // instructions to execute
        }
        */
        
        // Handles only those exceptions that match the type specified in parentheses after the catch statement.
        // And all information about the exception is placed in a variable of this type. For example:
        
        /*
        try
        {
            int x = 5;
            int y = x / 0;
            Console.WriteLine ($ "Result: {y}");
        }
        catch (DivideByZeroException ex)
        {
        Console.WriteLine ($ "An exception occurred {ex.Message}");
        }
        */
    
        // In fact, this case is similar to the previous one, with the exception that a variable is used here.
        // In this case, information about the thrown exception is placed in the ex variable,
        // which represents the DivideByZeroException type. And using the Message property, we can get the error message.
        
        // If we do not need information about the exception, then the variable can be omitted as in the previous case.
        
        
        //
        
        
        // !!!Exception filters!!!
        
        // Exception filters allow you to handle exceptions based on certain conditions.
        // To apply them, the catch expression is followed by a when expression followed by a condition in parentheses:
        
        /*
         catch when (condition)
        {
     
        }
        */
       
        // In this case, the exception is handled in the catch block only if the condition in the when expression is true. For example:

        // 1!
        
        /*
        int x = 1;
        int y = 0;
 
        try
        {
            int result = x / y;
        }
        catch (DivideByZeroException) when (y == 0 && x == 0)
        {
        Console.WriteLine ("y must not be 0");
        }
        catch (DivideByZeroException ex)
        {
        Console.WriteLine (ex.Message);
        }
        */
        
        // In this case, an exception will be thrown since y = 0. There are two catch blocks,
        // and both of them handle DivideByZeroException exceptions,
        // that is, essentially all exceptions thrown when divided by zero.
        // But since the first block specifies the condition y == 0 && x == 0,
        // it will not handle the exception - the condition specified after the when clause returns false.
        // Therefore, the CLR will continue to look for the corresponding catch blocks further
        // and will select the second catch block to handle the exception.
        // As a result, if we remove the second catch block, the exception will not be handled at all.
    }    
}