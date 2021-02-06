using System;

namespace FindingCatchBlockWhenHandlingExceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1!
            try
            {
                TestClass.Method1();
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Catch in Main: {ex.Message}");
            }
            finally
            {
                Console.WriteLine ("finally block in Main");
            }
            
            Console.WriteLine ("End of Main method");
        }
        
        
        // If the code that raises the exception is not placed in the try block or is placed in the try..catch construction
        // that does not contain the corresponding catch block to handle the thrown exception,
        // then the system searches for the corresponding exception handler in the call stack.

        // For example, consider the following program:
        
        // 1!
        
        class TestClass
        {
            public static void Method1()
            {
                try
                {
                    Method2();
                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine($"Catch in Method1 : {ex.Message}");
                }
                finally
                {
                    Console.WriteLine("Block finally in Method1");
                }
                
                Console.WriteLine("End of Method1");
            }
            
            static void Method2()
            {
                try
                {
                    var x = 8;
                    var y = x / 0;
                }
                finally
                {
                    Console.WriteLine("Block finally в Method2");
                }
                
                Console.WriteLine("End of Method2");
            }
        }
        
        // In this case, the call stack looks like this: the Main method calls Method1, which in turn calls Method2.
        // And in Method2, a DivideByZeroException is thrown. Visually, the call stack can be represented as follows:

        // Finding a catch block while handling an exception in C #
        // At the bottom of the stack is the Main method that started execution, and at the very top is Method2.

        // What will happen in this case when an exception is thrown?

        // 1. The Main method calls Method1, which calls Method2, which throws a DivideByZeroException.

        // 2. The system sees that the code that caused the exception was placed in the try..catch construction
        
        /*try
        {
            int x = 8;
            int y = x / 0;
        }
        finally
        { 
        Console.WriteLine ("finally block in Method2");
        }*/
    
        // The system looks for a catch block in this construction that handles the DivideByZeroException exception.
        // However, there is no such catch block.
        
        
        // 3. The system is dropped in the call stack into the Method1 method that called Method2.
        // Here Method2 call is placed in try..catch construct
        
        /*try
        {
            Method2 ();
        }
        catch (IndexOutOfRangeException ex)
        {
            Console.WriteLine ($ "Catch in Method1: {ex.Message}");
        }
        finally
        {
            Console.WriteLine ("finally block in Method1");
        }*/
    
        // The system also looks in this construction for a catch block that handles the DivideByZeroException exception.
        // However, there is no such catch block here either.
        
        // 4. The system then descends on the call stack to the Main method that called Method1.
        // Here the call to Method1 is placed in the try..catch construct
            
        /*
        try
        {
            TestClass.Method1 ();
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine ($ "Catch in Main: {ex.Message}");
        }
        finally
        {
            Console.WriteLine ("finally block in Main");
        }*/
        
        // The system again looks for a catch block in this construction that handles the DivideByZeroException exception.
        // And in this case, a weaving block was found.
        
        // 5. The system finally found the right catch block in the Main method to handle the exception
        // that was thrown in the Method2 - that is, to the initial method where the exception was thrown directly.
        // But so far this catch block is NOT executed.
        // The system climbs back up the call stack to the top of Method2 and executes a finally block there:
        
        /*finally
        {
            Console.WriteLine ("finally block in Method2");
        }*/
        
        // 6. Then the system goes back down the call stack to Method1 and executes the finally block in it:
        
        /*
        finally
        {
            Console.WriteLine ("finally block in Method1");
        }*/
        
        // 7. The system then steps down the call stack to the Main method and executes the catch block it finds and the subsequent finally block there:
        
        /*catch (DivideByZeroException ex)
        {
            Console.WriteLine ($ "Catch in Main: {ex.Message}");
        }
        finally
        {
            Console.WriteLine ("finally block in Main");
        }*/
        
        // 8. Next, the code that goes in the Main method after the try..catch construction is executed:
        
        /*
         * Console.WriteLine ("End of Main method");
         */
            
        // It is worth noting that the code that follows the try ... catch construct in the Method1
        // and Method2 methods is not executed, because the exception handler was found in the Main method.
    }
}