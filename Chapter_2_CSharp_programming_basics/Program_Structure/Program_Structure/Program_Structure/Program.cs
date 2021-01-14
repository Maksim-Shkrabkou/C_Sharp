using System;

namespace Program_Structure
{
    class Program
    {
        // Main method -> the starting point of the application
        static void Main(string[] args)
        {
            //statements
            Console.WriteLine("First block");
            {
                Console.WriteLine("Second block");
            }
            
            /*
             * Print your name:)
             */
            Console.Write("Set your name: ");
            Console.WriteLine($"Hey {Console.ReadLine()}");
        }
    }
}