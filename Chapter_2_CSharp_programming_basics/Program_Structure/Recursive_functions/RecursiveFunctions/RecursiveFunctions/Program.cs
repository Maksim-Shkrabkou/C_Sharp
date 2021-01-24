using System;

namespace RecursiveFunctions
{
    class Program
    {
        static void Main(string[] args)
        {
            // Let's dwell on recursive functions separately.
            // A recursive function is a construct in which the function calls itself.

            // Take, for example, a factorial calculation that uses the formula n! = 1 * 2 *… * n.
            // For example, the factorial of the number 5 is 120 = 1 * 2 * 3 * 4 * 5.

            // Let's define a method for finding the factorial:
            
            static int Factorial(int x)
            {
                if (x == 0)
                {
                    return 1;
                }
                else
                {
                    return x * Factorial(x - 1);
                }
            }
            
            // So, here we have a condition that if the input number is not equal to 0,
            // then we multiply this number by the result of the same function,
            // into which the number x-1 is passed as a parameter.
            // That is, recursive descent occurs.
            // And so on until we reach the point where the parameter value is not equal to one.

            // When creating a recursive function, there must be some basic variant in it,
            // which uses the return statement and is placed at the beginning of the function.
            // In the case of factorial, this is if (x == 0) return 1 ;.
            
            // And in addition, all recursive calls must call sub-functions,
            // which eventually converge to the base case.
            // So, when passing a positive number to a function,
            // with further recursive calls of subfunctions,
            // each time a number less by one will be passed to them.
            // And in the end we will get to a situation where the number will be equal to 0,
            // and the base case will be used.
            
            // Another common illustrative example of a recursive function is a function
            // that calculates Fibbonacci numbers.
            // The n-th term of the Fibonacci sequence is determined by the formula:
            // f (n) = f (n-1) + f (n-2), and f (0) = 0, and f (1) = 1.
            // That is, the Fibonacci sequence will look like this 0 (0th term),
            // 1 (1st term), 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, ....
            // For For determining the numbers of this sequence, we define the following method:
            
            static int Fibonachi(int n)
            {
                if (n == 0)
                {
                    return 0;
                }
                else if (n == 1)
                {
                    return 1;
                }
                else
                {
                    return Fibonachi(n - 1) + Fibonachi(n - 2);
                }
            }
            
            // Or, if you shorten the first two conditionals, like this:
            
            static int FibonachiTwo(int n)
            {
                if (n == 0 || n == 1)
                {
                    return n;
                }
                else
                {
                    return Fibonachi(n - 1) + Fibonachi(n - 2);
                }
            }
            
            // This is the simplest example of recursive functions to help you understand how recursion works.
            // At the same time, for both functions, instead of recursion, you can use looping constructs.
            // And generally, loop-based alternatives are faster and more efficient than recursion.
            //
            // For example, calculating Fibonacci numbers using loops:
            
            static int FibonacciLoop(int n)
            {
                var a = 0;
                var b = 1;
                int tmp;
 
                for (var i = 0; i < n; i++)
                {
                    tmp = a;
                    a = b;
                    b += tmp;
                }
 
                return a;
            }

            Console.WriteLine(FibonacciLoop(5));
            
            // At the same time, in some situations, recursion provides an elegant solution,
            // for example, when traversing various tree views, for example, a tree of directories and files.
        }
    }
}