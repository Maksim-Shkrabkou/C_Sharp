using System;

namespace Literals
{
    class Program
    {
        static void Main(string[] args)
        {
            // Boolean Literals
            Console.WriteLine(true);
            Console.WriteLine(false);
            
            // Integer Literals
            Console.WriteLine(-11);
            Console.WriteLine(5);
            Console.WriteLine(505);
            
            Console.WriteLine(0b11);        // 3
            Console.WriteLine(0b1011);      // 11
            Console.WriteLine(0b100001);    // 33
            
            Console.WriteLine(0x0A);    // 10
            Console.WriteLine(0xFF);    // 255
            Console.WriteLine(0xA1);    // 161
            
            // Floating-point Literals
            Console.WriteLine(3.14);
            Console.WriteLine(100.001);
            Console.WriteLine(-0.38);
            
            Console.WriteLine(3.2e3);
            Console.WriteLine(1.2E-1);
            
            // Character Literals
            Console.WriteLine('2');
            Console.WriteLine('A');
            Console.WriteLine('T');
            
            Console.WriteLine('\n');
            Console.WriteLine("\t tab");
            
            Console.WriteLine('\x78');    // x
            Console.WriteLine('\x5A');    // Z
            
            Console.WriteLine('\u0420');    // Р
            Console.WriteLine('\u0421');    // С
            
            // String Literals
            Console.WriteLine("hello");
            Console.WriteLine("hello word");
            
            Console.WriteLine("Company \"Kraken\"");
            
            Console.WriteLine("Hello \n world");
            
            // Null Literals
            int? sample = null;
        }
    }
}