using System;

namespace AssignmentOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            // Assigment
            var number = 23;
            Console.WriteLine(number);
            
            // Multiple assigment
            int a, b, c;
            a = b = c = 34;
            Console.WriteLine($"a = {a}, b = {b}, c = {c}");
            
            // It should be noted that assignment operations are of low priority.
            // And first the value of the right operand will be calculated,
            // and only then will this value be assigned to the left operand.
            // For example:
            // The expression 34 * 2/4 will be calculated first,
            // then the resulting value will be assigned to the variables.
            int a1, b1, c1;
            a1 = b1 = c1 = 34 * 2 / 4; // 17
            Console.WriteLine($"a1 = {a1}, b1 = {b1}, c1 = {c1}");
            
            var a3 = 10;
            a3 += 10;  // 20
            a3 -= 4;   // 16
            a3 *= 2;   // 32
            a3 /= 8;   // 4
            a3 <<= 4;  // 64
            a3 >>= 2;  // 16
            Console.WriteLine(a3);
            
            
            // Assignment operations are right-associative,
            // that is, they are performed from right to left.
            // For example:
            
            var a5 = 8;
            var b5 = 6;
            var c5 = a5 += b5 -= 5;    // 9
            Console.WriteLine(c5);
            
            // In this case, the expression will be executed as follows:
            //
            // b5 -= 5 (6-5 = 1)
            //
            // a5 += (b5- = 5) (8 + 1 = 9)
            //
            // c5 = (a5 += (b -= 5)) (c = 9)
        }
    }
}