using System;

namespace Variables
{
    class Program
    {
        static void Main(string[] args)
        {
            string mobileName;
            mobileName = "Tom";
            Console.WriteLine(mobileName);
            
            var name = "Tom";  // define a variable and initialize
            Console.WriteLine(name);    // Tom
 
            name = "Bob";       // change variable meaning
            Console.WriteLine(name);    // Bob
        }
    }
}