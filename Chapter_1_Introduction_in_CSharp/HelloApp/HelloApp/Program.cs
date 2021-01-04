using System;

namespace HelloApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.Write("Set your name: ");
            Console.WriteLine($"Hey {Console.ReadLine()}");
        }
    }
}