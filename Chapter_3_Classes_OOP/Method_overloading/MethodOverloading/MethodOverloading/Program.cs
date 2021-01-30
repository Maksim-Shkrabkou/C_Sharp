using System;

namespace MethodOverloading
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1!
            var calc = new Calculator();
            calc.Add(1, 2); // 3
            calc.Add(1, 2, 3); // 6
            calc.Add(1, 2, 3, 4); // 10
            calc.Add(1.4, 2.5); // 3.9
        }
        
        // Sometimes it becomes necessary to create the same method, but with a different set of parameters.
        // And depending on the available parameters, apply a specific version of the method.
        // This feature is also called method overloading.

        // And in C #, we can create several methods in a class with the same name but different signatures.
        // What is a signature? The signature consists of the following aspects:

        // Method name

        // Number of parameters

        // Parameter types

        // Parameter order

        // Parameter modifiers

        // But the names of the parameters are NOT included in the signature. For example, take the following method:
        
        /*
         * public int Sum(int x, int y) 
            { 
                return x + y;
            }
         */
        
        // For this method, the signature will look like this: Sum (int, int)

        // And method overloading consists in the fact that methods have different signatures,
        // in which only the name of the method matches. That is, the methods should differ in:

        // Number of parameters

        // Parameter type

        // Order of parameters

        // Parameter modifiers

        // For example, let's say we have the following class:
        
        class Calculator
        {
            public void Add(int a, int b)
            {
                var result = a + b;
                Console.WriteLine($"Result is {result}");
            }
            
            public void Add(int a, int b, int c)
            {
                var result = a + b + c;
                Console.WriteLine($"Result is {result}");
            }
            
            public int Add(int a, int b, int c, int d)
            {
                var result = a + b + c + d;
                Console.WriteLine($"Result is {result}");
                return result;
            }
            
            public void Add(double a, double b)
            {
                double result = a + b;
                Console.WriteLine($"Result is {result}");
            }
        }
        
        // There are four different versions of the Add method, that is, four overloads of this method are defined.

        // The first three versions of the method differ in the number of parameters.
        // The fourth version coincides with the first in the number of parameters,
        // but differs in their type. Moreover, it is sufficient that at least one parameter differs in type.
        // Therefore, this is also a valid overload of the Add method.

        // That is, we can represent the signatures of these methods as follows:
        
        // Add(int, int)
        // Add(int, int, int)
        // Add(int, int, int, int)
        // Add(double, double)
        
        // After identifying the overloaded versions, we can use them in the program:
        
        // 1!
        
        // Also, overloaded methods may differ in the modifiers used. For example:
        
        /*
         * void Increment(ref int val)
           {
                val++;
                Console.WriteLine(val);
            }
 
            void Increment(int val)
            {
                val++;
                Console.WriteLine(val);
            }
         */
        
        
        // In this case, both versions of the Increment method have the same set of parameters of the same type,
        // but in the first case, the parameter has a ref modifier.
        // Therefore, both versions of the method will be valid overloads of the Increment method.
        

        // And the difference between methods in return type or in parameter names is not a reason for overloading.
        // For example, take the following set of methods:
        
        /*
         *  int Sum(int x, int y)
            {
                return x + y;
            }

            int Sum(int number1, int number2)
            {
                return x + y;
            }

            void Sum(int x, int y)
            {
                Console.WriteLine(x + y);
            }
         */
        
        // All these methods will have the same signature:
        
        // Sum (int, int)
        
        // Therefore, this set of methods does not represent correct overloads of the Sum method and will not work.
    }
}