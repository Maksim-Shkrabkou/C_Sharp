using System;

namespace Delegates_Action_Predicate_Func
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1!
            
            /*
            * public delegate void Action<T> (T obj)
            */
            
            Action<int, int> op;
            op = Add;
            Operation(10, 6, op);
            op = Substract;
            Operation(10, 6, op);
            Console.WriteLine('\n');
            
            // 2!
            Predicate<int> isPositive = i => i > 0;
            
            Console.WriteLine(isPositive(20));
            Console.WriteLine(isPositive(-20));
            Console.WriteLine('\n');
            
            // 3!
            Func<int, int> retFunc = Factorial;
            var n1 = GetInt(6, retFunc);
            Console.WriteLine(n1);  // 720
     
            int n2 = GetInt(6, x => x * x);
            Console.WriteLine(n2); // 36
        }
        
        // .NET has several built-in delegates that are used in various situations.
        // The most commonly used are Action, Predicate and Func.
        
        
        //
        
        
        // !!!Action!!!
            
        // The Action delegate is generic, takes parameters, and returns void:
        
        /*
         * public delegate void Action <T> (T obj)
         */
        
        // This delegate has a number of overloads. Each version accepts a different number of parameters:
        // from Action <in T1> to Action <in T1, in T2, .... in T16>. Thus, you can pass up to 16 values to the method.

        // Typically, this delegate is passed as a parameter to a method
        // and calls for specific actions in response to the actions that have occurred. For example:
        
        // 1!
        
        static void Operation(int x1, int x2, Action<int, int> op)
        {
            if (x1 > x2)
                op(x1, x2);
        }
        
        static void Add (int x1, int x2) => 
            Console.WriteLine ("Sum of numbers:" + (x1 + x2));

        static void Substract (int x1, int x2) =>
            Console.WriteLine ("Difference of numbers:" + (x1 - x2));
        
        
        //
        
        
        // !!!Predicate!!!
        
        // The Predicate <T> delegate is generally used for comparison, matching some T object to a specific condition.
        // The output returns true if the condition is met, and false if not:
        
        /*
        Predicate<int> isPositive = delegate (int x) { return x > 0; }
            
        Console.WriteLine(isPositive(20));
        Console.WriteLine(isPositive(-20));
        */
        
        // In this case, true or false is returned depending on whether the number is greater than zero or not.
        
        
        //
        
        
        
        // Func
        
        // Another common delegate is Func. It returns the result of an action and can take parameters.
        // It also has various forms: from Func <out T> (),
        // where T is the return type, to Func <in T1, in T2, ... in T16, out TResult> (),
        // that is, it can take up to 16 parameters ...
        
        /*
        TResult Func<out TResult>()
        TResult Func<in T, out TResult>(T arg)
        TResult Func<in T1, in T2, out TResult>(T1 arg1, T2 arg2)
        TResult Func<in T1, in T2, in T3, out TResult>(T1 arg1, T2 arg2, T3 arg3)
        TResult Func<in T1, in T2, in T3, in T4, out TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        //...........................................
        */
        
        // This delegate is also often used as a parameter in methods:
        
        static int GetInt(int x1, Func<int, int> retF)
        {
            var result = 0;
            
            if (x1 > 0)
                result = retF(x1);
            
            return result;
        }
        
        static int Factorial(int x)
        {
            var result = 1;
            
            for (var i = 1; i <= x; i++)
            {
                result *= i;
            }
            
            return result;
        }
    }
}