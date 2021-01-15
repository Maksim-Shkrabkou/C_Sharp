using System;

namespace BitwiseOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            // Logical operations
            
            
            // & (logical multiplication)
            
            var x1 = 2; //010
            var y1 = 5; //101
            Console.WriteLine(x1 & y1); // 0
             
            var x2 = 4; //100
            var y2 = 5; //101
            Console.WriteLine(x2 & y2); // 4
            
            /*
             * In the first case, we have two numbers 2 and 5. 2 in binary represents the number 010, and 5 - 101.
             * Multiply the numbers (0 * 1, 1 * 0, 0 * 1) bit by bit and get 000 as a result.
             *
             * In the second case, instead of two, we have the number 4, which has 1 in the first bit,
             * just like the number 5, so in the end we get (1 * 1, 0 * 0, 0 * 1) = 100, that is, the number 4 in decimal format.
             */


            
            // | (logical addition)
            
            /*
             * It looks like logical multiplication, the operation is also performed on binary digits,
             * but now one is returned if at least one number in this bit has a one. For example:
            */
            
            var x3 = 2; //010
            var y3 = 5; //101
            Console.WriteLine(x3 | y3); // 7 - 111
            
            var x4 = 4; //100
            var y4 = 5; //101
            Console.WriteLine(x4 | y4); // 5 - 101
            
            
            // ^ (logical exclusive OR)
            
            /*
             * Here, again, bitwise operations are performed. If we have different values of the current bit for both numbers,
             * then 1 is returned, otherwise 0 is returned.
             *
             * 
             */
            
            var x = 45; // The value to be encrypted is in binary form -> 101101
            var key = 102; // Let this be the key - in binary 1100110
            var encrypt = x ^ key; //  75
            Console.WriteLine("Encrypted digit: " + encrypt);
 
            var decrypt = encrypt ^ key; // The result will be the original number 45
            Console.WriteLine("Decrypted digit: " + decrypt);
            
            
            // ~ (logical negation or inverse)
            
            /*
             * Another bitwise operation that inverts all bits: if the bit value is 1, then it becomes zero, and vice versa.
            */
            
            var x5 = 12;            // 00001100
            Console.WriteLine(~x5);  // 11110011   или -13
            
            
            
            // Representing negative numbers
            
            /*
             * To write signed numbers in C #, a two's complement is used, in which the most significant bit is signed.
             *
             * If its value is 0, then the number is positive, and its binary representation does not differ from that of an unsigned number. For example, 0000 0001 in decimal 1.
             * If the most significant bit is 1, then we are dealing with a negative number. For example, 1111 1111 in decimal represents -1. Accordingly, 1111 0011 represents -13.
             *
             * To get negative from a positive number, you need to invert it and add one: 
            */

            var x6 = 12;
            var y6 = ~x6;
            y6 += 1;
            Console.WriteLine(y6); // -12
            
            
            // Bitwise shifts
            
            /*
             * The shift operators << and >> shift the bits in a variable left or right by a specified number.
             * In this case, zeros are set on the vacated positions (except for a right shift of a negative number, in this case ones are set on free positions,
             * since numbers are represented in a two's complement code and the sign bit must be maintained).
             * Left shift can be used to multiply a number by two, right shift can be used to divide.
             *
             * x = 7 // 00000111 (7)
             * x = x >> 1 // 00000011 (3)
             * x = x << 1 // 00000110 (6)
             * x = x << 5 // 11000000 (-64)
             * x = x >> 2 // 11110000 (-16)
             */
        }
    }
}