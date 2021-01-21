using System;

namespace ConditionalExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            // Comparison operations
            
            // ==
            // Compares two operands for equality. If they are equal,
            // then the operation returns true, if they are not equal, then false is returned:
            var a = 10;
            var b = 4;
            var c = a == b; // false
            Console.WriteLine(c);
            
            
            // !=
            // Compares two operands and returns true if the operands are not equal and false if they are equal.
            var a1 = 10;
            var b1 = 4;
            var c1 = a1 != b1;    // true
            var d1 = a1 != 10;    // false
            
            
            // <
            // Less than operation. Returns true if the first operand is less than the second,
            // and false if the first operand is greater than the second:
            var a2 = 10;
            var b2 = 4;
            var c2 = a2 < b2; // false
            
            
            // >
            // Greater than operation. Compares two operands and returns true if
            // the first operand is greater than the second, otherwise returns false:
            var a3 = 10;
            var b3 = 4;
            var c3 = a3 > b3;     // true
            var d3 = a3 > 25;    // false
            
            
            // <=
            // Less than or equal to operation. Compares two operands and returns true if
            // the first operand is less than or equal to the second. Returns false otherwise.
            var a4 = 10;
            var b4 = 4;
            var c4 = a4 <= b4;     // false
            var d4 = a4 <= 25;    // true
            
            
            // > =
            // Greater than or equal to operation. Compares two operands and returns true if
            // the first operand is greater than or equal to the second, otherwise it returns false:
            var a5 = 10;
            var b5 = 4;
            var c5 = a5 >= b5;    // true
            var d5 = a5 >= 25;    // false
            
            
            // !!! Operations <,> <=,> = have higher precedence than == and! =. !!!
            
            
            
            // Logical operations
            
            // |
            // Logical addition or logical OR. Returns true if at least one of the operands returns true.
            var x1 = (5 > 6) | (4 < 6); // 5 > 6 - false, 4 < 6 - true, so returns true
            var x2 = (5 > 6) | (4 > 6); // 5 > 6 - false, 4 > 6 - false, so returns false
            
            
            // &
            // Logical multiplication or logical AND operation Returns true if both operands are simultaneously true.
            var x3 = (5 > 6) & (4 < 6); // 5 > 6 - false, 4 < 6 - true, so returns false
            var x4 = (5 < 6) & (4 < 6); // 5 < 6 - true, 4 < 6 - true, so returns true
            
            
            // ||
            // Logical addition operation. Returns true if at least one of the operands returns true.
            var x5 = (5 > 6) || (4 < 6); // 5 > 6 - false, 4 < 6 - true, so returns true
            var x6 = (5 > 6) || (4 > 6); // 5 > 6 - false, 4 > 6 - false, so returns false
            
            
            // &&
            // Logical multiplication operation. Returns true if both operands are simultaneously true.
            var x7 = (5 > 6) && (4 < 6); // 5 > 6 - false, 4 < 6 - true, so returns false
            var x8 = (5 < 6) && (4 < 6); // 5 < 6 - true, 4 < 6 - true, so returns true
            
            // !
            // Operation of logical negation. It is performed on one operand and returns true if
            // the operand is false. If the operand is true, then the operation returns false:
            var a6 = true;
            var b6 = !a6;    // false
            
            // ^
            // Exclusive OR operation. Returns true if either the first or second operand (but not both) are true,
            // otherwise it returns false
            var x9 = (5 > 6) ^ (4 < 6); // 5 > 6 - false, 4 < 6 - true, so returns true
            var x10 = (50 > 6) ^ (4 / 2 < 3); // 50 > 6 - true, 4/2 < 3 - true, so returns false
            var x11 = (5 > 6) ^ (4 > 6); // 5 > 6 - false, 4 > 6 - false, so returns false
            
            
            /*
             * Here we have two pairs of operations | and || (and & and &&) do similar things, but they are not the same.
             * In the expression z = x | y; both x and y will be calculated.
             * In the expression z = x || y; first, the value of x will be calculated, and if it is true
             * then the calculation of the value of y does not make sense, since in any case, z will already be equal to true.
             * The y value will only be calculated if x is false
             * 
             * The same goes for the & / && pair of operations. In the expression z = x & y; both x and y will be calculated.
             * In the expression z = x && y; first, the value of x will be calculated, and if it is false,
             * then the calculation of the value of y does not make sense, since in any case,
             * z will already be equal to false. The y value will only be calculated if x is true
             *
             * Therefore, the operations || and && are more convenient in calculations,
             * as they reduce the time spent on evaluating the value of an expression,
             * and thereby increase performance. And operations | and & are more suitable for performing bitwise operations on numbers.
             */
        }
    }
}