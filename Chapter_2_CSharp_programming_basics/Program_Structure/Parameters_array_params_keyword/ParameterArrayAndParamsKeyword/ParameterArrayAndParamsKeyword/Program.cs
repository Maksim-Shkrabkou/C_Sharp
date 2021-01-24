using System;

namespace ParameterArrayAndParamsKeyword
{
    class Program
    {
        static void Main(string[] args)
        {
            
            // In all the previous examples, we used a constant number of parameters.
            // But using the 'keyword', we can pass an indefinite number of parameters:
            Addition(1, 2, 3, 4, 5);
     
            var array = new int[] { 1, 2, 3, 4 };
            Addition(array);
 
            Addition();
            
            // The parameter itself with the params keyword when defining a method must represent
            // a one-dimensional array of the type whose data we are going to use.
            // When calling a method instead of a parameter with the params modifier,
            // we can pass both individual values and an array of values, or not pass parameters at all.

            // If we need to pass any other parameters,
            // then they must be specified before the parameter with the params keyword:
            
            /*
             * //Works
             * static void Addition( int x, string mes, params int[] integers)
             * {}
            */
            
            Addition(1,"Hi", 1, 2, 3, 4, 5);
            
            
            // !!!
            // Array as parameter
            // Also, this method of passing parameters must be distinguished from passing an array as a parameter:
            Addition(1, 2, 3, 4, 5);
 
            var array1 = new int[] { 1, 2, 3, 4 };
            AdditionMas(array1, 2);
            
            // Since the AdditionMas method accepts an array as a parameter without the params keyword,
            // !!!we must pass an array as a parameter when calling it.!!!
        }
        
        // passing a parameter with params
        static void Addition(params int[] integers)
        {
            var result = 0;
            
            for (var i = 0; i < integers.Length; i++)
            {
                result += integers[i];
            }
            
            Console.WriteLine(result);
        }
        
        // params must be in the end of arguments!!!
        static void Addition( int x, string mes, params int[] integers)
        {}

        // passing array
        static void AdditionMas(int[] integers, int k)
        {
            var result = 0;
            
            for (var i = 0; i < integers.Length; i++)
            {
                result += (integers[i]*k);
            }
            
            Console.WriteLine(result);
        }
    }
}