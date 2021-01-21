using System;

namespace BasicDataTypeConversions
{
    class Program
    {
        static void Main(string[] args)
        {
            byte a = 4;
            int b = a + 70;
            
            // byte a1 = 4;
            // byte b1 = a1 + 70;  // error
            
            // Here, only the type of the variable that receives the result of addition has changed - from int to byte.
            // However, when we try to compile the program, we will get an error at the compilation stage.
            //
            // During operations, we must take into account the range of values that a particular type can store.
            // But in this case the number 74, which we expect to receive,
            // fits well into the range of values of the byte type, nevertheless, we get an error.
            //
            // The fact is that the addition (and subtraction) operation returns an int value
            // if the operation involves integer data types with a bit width less than or
            // equal to int (that is, byte, short, int types). Therefore, the result of operation a + 70 will be
            // an object that is 4 bytes long in memory. Then we try to assign this object to the variable b,
            // which is of type byte and occupies 1 byte in memory.
            //
            // And to get out of this situation, you need to apply the type conversion operation:
            
            
            byte a1 = 4;
            byte b1 = (byte) (a1 + 70);  // works)
            
            
            // Narrowing and widening transformations
            // Conversions can be narrowing and widening.
            // Widening transformations expand the size of an object in memory. For example:
            
            // Implicit conversion
            byte a2 = 4;      // 0000100
            ushort b2 = a2;   // 000000000000100
            
            ushort a3 = 4;       // 000000000000100
            byte b3 = (byte) a3; // 0000100
            
            
            // Explicit conversion
            int a4 = 4;
            int b4 = 6;
            byte c4 = (byte)(a4+b4);
            
            /*
             * All safe conversions and automatic conversions can be described by the following table:
             *
             * byte : short, ushort, int, uint, long, ulong, float, double, decimal
             * sbyte : short, int, long, float, double, decimal
             * short : int, long, float, double, decimal
             * ushort : int, uint, long, ulong, float, double, decimal
             * int : long, float, double, decimal
             * uint : long, ulong, float, double, decimal
             * long : float, double, decimal
             * ulong : float, double, decimal
             * float : double
             * char : ushort, int, uint, long, ulong, float, double, decimal
             */
            
            
            
            // Data loss and the checked keyword
            int a5 = 33;
            int b5 = 600;
            byte c5 = (byte)(a5+b5); //121
            Console.WriteLine(c5);
            
            // The result is 121, so 633 is out of range for byte and the high order bits will be truncated.
            // As a result, the number 121 will be obtained. Therefore, when converting, this must be taken into account.
            // And in this case, we can either take such numbers a and b, which in total will give a number
            // no more than 255, or we can choose another data type instead of byte, for example, int.

            // However, situations can be different. We may not know exactly what values a and b will have.
            // And to avoid this kind of situation, c # has the checked keyword:
            
            try
            {
                var a6 = 33;
                var b6 = 600;
                byte c6 = checked((byte)(a6 + b6));
                Console.WriteLine(c6);
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            // When using the "checked" keyword, the application throws an overflow exception.
        }
    }
}