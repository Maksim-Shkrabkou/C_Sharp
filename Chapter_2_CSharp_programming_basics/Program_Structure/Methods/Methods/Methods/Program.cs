using System;

namespace Methods
{
    class Program
    {
        //[modifiers] return_type method_name ([parameters])
        //{
        // method body
        //}
        
        // Call method
        // method_name (values_for_method_parameters);
        
        
        static void Main(string[] args)
        {

            SayHello();
            SayGoodbye();
            
            var message = GetHello();
            var sum = GetSum();
 
            Console.WriteLine(message);  // Hello
            Console.WriteLine(sum);     // 5
 
            
        }
        
        static void SayHello()
        {
            Console.WriteLine("Hello");
        }
        static void SayGoodbye()
        {
            Console.WriteLine("GoodBye");
        }
        
        
        //Abbreviated notation of methods
        // If a method defines only one statement as a body, then we can shorten the method definition.
        // For example, let's say we have a method:
        static string GetHello() => "Hello";

        static int GetSum()
        {
            var x = 2;
            var y = 3;

            return  x + y;
        }
        
        // However, we can use the return statement in methods with void types.
        // In this case, no return value is placed after the return statement
        // (after all, the method does not return anything).
        // A typical situation is to exit the method depending on the specified conditions:
        
        static void SayHelloTwo()
        {
            var hour = 23;
            
            if(hour > 22)
            {
                return;
            }
            else
            {
                Console.WriteLine("Hello");
            }
        }

    }
}