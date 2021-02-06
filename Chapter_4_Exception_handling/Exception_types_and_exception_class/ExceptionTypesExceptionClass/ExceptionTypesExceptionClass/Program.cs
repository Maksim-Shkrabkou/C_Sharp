using System;

namespace ExceptionTypesExceptionClass
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1!
            try
            {
                var x = 5;
                var y = x / 0;
                Console.WriteLine ($"Result: {y}");
            }
            catch (Exception ex)
            {
                Console.WriteLine ($"Exception: {ex.Message}");
                Console.WriteLine ($"Method: {ex.TargetSite}");
                Console.WriteLine ($"Stack trace: {ex.StackTrace}");
                Console.WriteLine($"Inner exception: {ex.InnerException}");
                Console.WriteLine($"Source: {ex.Source}");
                Console.WriteLine("\n");
            }
            
            // 2!
            try
            {
                var numbers = new int[4];
                numbers[7] = 9;     // IndexOutOfRangeException
 
                var x = 5;
                var y = x / 0;  // DivideByZeroException
                Console.WriteLine($"Result: {y}");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("An exception was thrown -> DivideByZeroException");
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            Console.WriteLine("\n");
            
            // 3!
            try
            {
                object obj = "you";
                var num = (int) obj; // InvalidCastException
                Console.WriteLine ($"Result: {num}");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine ("DivideByZeroException thrown");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine ("An IndexOutOfRangeException was thrown");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }  
            
            Console.WriteLine("\n");
        }
        
        // The type of exception is basic for all types of exceptions.
        // This type defines a number of properties that can be used to obtain information about an exception.

        // InnerException: Stores information about the exception.
        
        // Message: stores the exception message, error text

        // Source: Stores the name of the object or assembly that threw the exception

        // StackTrace: returns a string representation of the call stack that throws the exception

        // TargetSite: Returns the method where the exception was thrown

        // For example, let's handle an exception of type Exception:
        
        // 1!
        
        
        // However, since the Exception type is the base type for all exceptions,
        // the catch (Exception ex) expression will handle any exceptions that might be thrown.

        // But there are also more specialized types of exceptions that are designed to handle specific types of exceptions.
        // There are quite a few of them, I will give just a few:

        // DivideByZeroException: Represents the exception that is thrown when divided by zero

        // ArgumentOutOfRangeException: Thrown if the argument value is out of range

        // ArgumentException: thrown if an invalid value is passed to the method for a parameter

        // IndexOutOfRangeException: Thrown if the index of an element in an array or collection is out of range
        
        // InvalidCastException: Thrown when trying to perform invalid type conversions

        // NullReferenceException: thrown when trying to access an object that is null (that is, inherently undefined)

        // And if necessary, we can differentiate the handling of different types of exceptions by including additional catch blocks:
        
        // 2!
        
        // In this case, the catch blocks handle exceptions of the IndexOutOfRangeException, DivideByZeroException, and Exception types. When an exception is thrown in the try block, the CLR will look for the correct catch block to handle the exception. So, in this case, on the line
            
        // numbers [7] = 9;
        
        // the 7th element of the array is accessed. However, since there are only 4 elements in the array,
        // we will get an IndexOutOfRangeException.
        // The CLR will find a catch block that handles the exception and transfer control to it.
        
        // It should be noted that in this case in the try block there is a situation
        // for throwing a second exception - division by zero.
        // However, since after the IndexOutOfRangeException is thrown, control passes to the corresponding catch block,
        // division by zero int y = x / 0 will in principle not be performed,
        // so an exception of the DivideByZeroException type will never be thrown.

        // However, consider a different situation:
        
        /*
        try
        {
            object obj = "you";
            var num = (int) obj; // InvalidCastException
            Console.WriteLine ($"Result: {num}");
        }
        catch (DivideByZeroException)
        {
        Console.WriteLine ("DivideByZeroException thrown");
        }
        catch (IndexOutOfRangeException)
        {
        Console.WriteLine ("An IndexOutOfRangeException was thrown");
        }
        */
        
        // In this case, an InvalidCastException exception is thrown in the try block,
        // but there is no corresponding catch block to handle this exception. Therefore, the program will crash.

        // We can also define our own catch block for InvalidCastException,
        // but the point is that, in theory, various types of exceptions themselves can be thrown in the code.
        // And it makes no sense to define catch blocks for all types of exceptions if the exception handling is the same.
        // And in this case, we can define a catch block for the base Exception type:
        
        // 3!
        
        // And in this case, the catch (Exception ex) {} block will handle all exceptions
        // except DivideByZeroException and IndexOutOfRangeException. In this case, catch blocks for more general,
        // more basic exceptions should be placed at the end - after catch blocks for more specific, specialized types.
        // Because the CLR chooses to handle the exception with the first catch block that matches the type of exception thrown.
        // Therefore, in this case,
        // the DivideByZeroException and IndexOutOfRangeException exception is first handled, and only then the Exception
        // (since DivideByZeroException and IndexOutOfRangeException are inherited from the Exception class).
    }
}