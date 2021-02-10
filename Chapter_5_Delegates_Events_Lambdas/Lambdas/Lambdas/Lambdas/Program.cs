using System;

namespace Lambdas
{
    class Program
    {
        // 1!
        delegate int Operation(int x, int y);
        
        // 2!
        delegate int Square(int x); // declare a delegate that takes an int and returns an int
        
        // 3!
        delegate void Hello(); // delegate without parameters
        
        // 4!
        delegate void ChangeHandler(ref int x);
        
        // 5!
        // delegate void Hello(); // delegate without parameters
        
        // 6!
        delegate bool IsEqual(int x);

        static void Main(string[] args)
        {
            // 1!
            int Operation(int x, int y) => x + y;
            Console.WriteLine(Operation(10, 20));       // 30
            Console.WriteLine(Operation(40, 20));       // 60
            Console.WriteLine('\n');
            
            // 2!
            Square square = i => i * i; // the delegate object is assigned a lambda expression
 
            var z = square(6); // use a delegate
            Console.WriteLine(z); // displays the number 36
            Console.WriteLine('\n');
            
            // 3!
            Hello hello1 = () => Console.WriteLine("Hello");
            Hello hello2 = () => Console.WriteLine("Welcome");
            hello1();       // Hello
            hello2();       // Welcome
            Console.WriteLine('\n');
            
            // 4!
            var x = 9;
            ChangeHandler ch = (ref int n) => n = n * 2;
            ch(ref x);
            Console.WriteLine(x);   // 18
            Console.WriteLine('\n');
            
            // 5!
            Hello message = () => Show_Message();
            message();
            Console.WriteLine('\n');
            
            // 6!
            int [] integers = {1, 2, 3, 4, 5, 6, 7, 8, 9};
         
            // find the sum of numbers greater than 5
            var result1 = Sum(integers, x => x > 5);
            Console.WriteLine (result1); // thirty
         
            // find the sum of even numbers
            var result2 = Sum(integers, x => x % 2 == 0);
            Console.WriteLine (result2); //20
        }
        
        // Lambda expressions represent a simplified notation for anonymous methods.
        // Lambda expressions allow you to create capacious,
        // concise methods that can return some value and which can be passed as parameters to other methods.

        // Lambda expressions have the following syntax: to the left of the lambda operator => a parameter list is defined,
        // and to the right is an expression block using those parameters: (parameter_list) => expression.
        
        // For example:
        
        // 1!
        
        // Here the code is (x, y) => x + y; represents a lambda expression,
        // where x and y are parameters and x + y is an expression.
        // In this case, we do not need to specify the type of parameters,
        // and when returning the result, we do not need to use the return statement.

        // It should be borne in mind that each parameter in the lambda expression
        // is implicitly converted to the corresponding parameter of the delegate,
        // so the parameter types must be the same.
        // In addition, the number of parameters must be the same as that of the delegate.
        // And the return value of lambda expressions should be the same as that of the delegate.
        // That is, in this case,
        // the lambda expression used matches the Operation delegate in both the return type and the type and number of parameters.

        // If the lambda expression takes one parameter, then the parentheses around the parameter can be omitted:
        
        // 2!
        
        // It happens that parameters are not required.
        // In this case, empty parentheses are used instead of a parameter in the lambda expression.
        // It also happens that a lambda expression does not return any value:
        
        // 3!
        
        
        // In this case, the lambda expression does not return anything,
        // because after the lambda operator there is an action that does not return anything.

        // As you can see from the examples above, we do not need to specify the type of parameters in the lambda expression.
        // However, we definitely need to specify the type
        // if the delegate to which the lambda expression must match has parameters with ref and out modifiers:
        
        // 4!
        
        // Lambda expressions can also execute other methods:
        
        // 5!
        
        private static void Show_Message()
        {
            Console.WriteLine("Hello world!");
        }
        
        
        //
        
        
        // !!!Lambda expressions as method arguments!!!
        
        // Like delegates,
        // lambda expressions can be pass1ed as arguments to a method for those parameters that the delegate represents,
        // which is pretty convenient:
        
        // 6!
        
        private static int Sum(int[] numbers, IsEqual func)
        {
            var result = 0;
            
            foreach(var i in numbers)
            {
                if (func(i))
                    result += i;
            }
            
            return result;
        }
        
        // The Sum method takes an array of numbers and an IsEqual delegate as a parameter,
        // and returns the sum of the numbers in the array as an int object.
        // In a loop, go through all the numbers and add them.
        // Moreover, we add only those numbers for which the IsEqual func delegate returns true.
        // That is, the IsEqual delegate here actually sets the condition that the array values must meet.
        // But at the time of writing the Sum method, we do not know what this condition is.

        // When calling the Sum method, it is passed an array and a lambda expression:
            
        /*
         * int result1 = Sum (integers, x => x> 5);
         */
        
        //That is, the x parameter here will represent the number that is passed to the delegate:
        
        /*
         if (func (i))
         */
            
        // And the expression x> 5 represents the condition that the number must match.
        // If the number meets this condition, then the lambda expression returns true,
        // and the number passed is added to the other numbers.

        // The second call of the Sum method works in a similar way, only here the number is checked for parity, that is, if the remainder of the division by 2 is zero:
            
        /*
         * int result2 = Sum (integers, x => x% 2 == 0);
         */
    }
}