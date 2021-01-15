using System;

namespace ArithmeticOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            // +
            var x = 10;
            var z = x + 12; // 22
            
            // -
            var x1 = 10;
            var z1 = x1 - 6; // 4
            
            // *
            var x2 = 10;
            var z2 = x2 * 5; // 50
            
            // /
            var x4 = 10;
            var z4 = x / 5; // 2
 
            double a = 10;
            double b = 3;
            var c = a / b; // 3.33333333
            
            double z5 = 10 /  4; // 2
            double z6 = 10.0 /  4.0; // 2.5
            
            // %
            var x7 = 10.0;
            double z7 = x % 4.0; // 2

            // ++
            
            /*
             * The increment can be prefixed: ++ x - first, the value of the variable x is increased by 1, and then its value is returned as the result of the operation.
             * And there is also a postfix increment: x ++ - first the value of the variable x is returned as the result of the operation, and then 1 is added to it.
            */
            
            var x8 = 5;
            var z8 = ++x8; // z8=6; x8=6
            Console.WriteLine($"{x8} - {z8}");
 
            var x9 = 5;
            var z9 = x9++; // z9=5; x9=6
            Console.WriteLine($"{x9} - {z9}");
            
            // --
            
            var x10 = 5;
            var z10 = --x10; // z10=4; x10=4
            Console.WriteLine($"{x10} - {z10}");
 
            var x11 = 5;
            var z11= x11--; // z11=5; x11=4
            Console.WriteLine($"{x11} - {z11}");
            
            //
            
            /*
             * When performing several arithmetic operations at once, consider the order in which they are performed. Priority of operations from highest to lowest:
             * 
             * 1 -> Increment, decrement
             * 2 -> Multiplication, division, getting the remainder
             * 3 -> Addition, subtraction
             *
             * Brackets are used to change the order of operations.
             */
            
            var a1 = 3;
            var b1 = 5;
            var c1 = 40;
            var d1 = c1---b1*a1;    // a1=3  b1=5  c1=39  d1=25
            Console.WriteLine($"a={a1}  b={b1}  c={c1}  d={d1}");
            
            
            var a2 = 3;
            var b2 = 5;
            var c2 = 40;
            var d2 = (c2-(--b2))*a2;    // a2=3  b2=4  c2=40  d2=108
            Console.WriteLine($"a={a2}  b={b2}  c={c2}  d={d2}");
            
            // Operator associativity
            
            var x12 = 10 / 5 * 2; // 4
            
            /*
             * When operations have the same priority, the order of evaluation is determined by the associativity of the operators. There are two types of operators depending on associativity:
             *
             * Left associative operators that run from left to right
             * Right associative operators that execute from right to left
             *
             * All arithmetic operators (except for prefix increment and decrement) are left associative, that is, they are executed from left to right.
             *
             * Therefore, the expression 10/5 * 2 must be interpreted as (10/5) * 2, that is, the result will be 4.
             */
        }
    }
}