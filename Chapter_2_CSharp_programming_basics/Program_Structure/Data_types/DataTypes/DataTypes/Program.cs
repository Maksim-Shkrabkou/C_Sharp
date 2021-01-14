using System;

namespace DataTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            // bool
            bool alive = true;
            bool isDead = false;

            // byte (0 - 255) -> 1 byte
            byte bit1 = 1;
            byte bit2 = 102;
            
            // sbyte (-128 - 127) -> 1 byte
            sbyte sbit1 = -101;
            sbyte sbit2 = 102;
            
            // short (-32768 - 32767) -> 2 byte
            short s1 = 1;
            short s2 = 102;
            
            // ushort (0 - 65535) -> 2 byte
            ushort us1 = 1;
            ushort us2 = 102;
            
            // int (-2147483648 до 2147483647) -> 4 byte
            int int1 = 10;
            int int2 = 0b101;
            int int3 = 0xFF;
            
            // uint (0 - 4294967295) -> 4 byte
            uint uint1 = 10;
            uint uint2 = 0b101;
            uint uint3 = 0xFF;
            
            // long (–9 223 372 036 854 775 808  -  9 223 372 036 854 775 807) -> 8 byte
            long long1 = -10;
            long long2 = 0b101;
            long long3 = 0xFF;
            
            // ulong (0 - 18 446 744 073 709 551 615) -> 8 byte
            ulong ulong1 = 10;
            ulong ulong2 = 0b101;
            ulong ulong3 = 0xFF;
            
            // float (-3.4*1038 - 3.4*1038) -> 4 byte
            float float1 = 3_000.5F;
            float float2 = 5.4f;
            
            // double (±5.0*10-324 - ±1.7*10308) -> 8 byte
            double double1 = 3D;
            double double2 = 4d;
            double double3 = 3.934_001;
            
            // decimal (±1.0*10-28 - ±7.9228*1028) -> 16 byte
            decimal decimal1 = 3_000.5m;
            decimal decimal2 = 400.75M;
            
            // char -> 2 byte
            char char1 = 'A';
            char char2 = '\x5A';
            char char3 = '\u0420';
            
            // string
            string hello = "Hello";
            string word = "world";
            
            // object -> !!!can store any data type!!! (4 byte on 32-x and 8 byte on 64-x platform)
            object object1 = 322;
            object object2 = 34.34;
            object object3 = "Hello world";
            

            
            // Using suffixes
            
            // When assigning values, keep in mind the following subtlety:
            // all real literals are treated as double values.
            // And to indicate that a fractional number represents a float or a decimal type,
            // you need to add a suffix to the literal: F / f for float and M / m for decimal
            
            /*
             The literal without suffix or with the d or D suffix is of type double
             The literal with the f or F suffix is of type float
             The literal with the m or M suffix is of type decimal
            */
            
            float float4 = 3.14F;
            float float5 = 30.6f;
 
            decimal decimal4 = 1005.8M;
            decimal decimal5 = 334.8m;
            
            // Likewise, all integer literals are treated as int values.
            // To explicitly indicate that an integer literal represents a uint value,
            // use the U / u suffix, long with L / l, and ulong with UL / ul:
            
            uint unit6 = 10U;
            long long6 = 0L;
            ulong ulong6 = 30UL;
            
            
            // Using system types
            int int6 = 12;
            System.Int32 int7 = 18;
            
            
            // Implicit typing
            var hey = "Hello to World";
            var int8 = 20;
             
            Console.WriteLine(int8.GetType().ToString());
            Console.WriteLine(hey.GetType().ToString());
            
            
            // Sample
            
            string name = "Tom";
            int age = 33;
            bool isEmployed = false;
            double weight = 78.65;
             
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Age: {age}");
            Console.WriteLine($"Weight: {weight}");
            Console.WriteLine($"Work: {isEmployed}");
        }
    }
}