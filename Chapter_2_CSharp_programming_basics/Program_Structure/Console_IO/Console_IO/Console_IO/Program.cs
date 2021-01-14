using System;

namespace Console_IO
{
    class Program
    {
        static void Main(string[] args)
        {
            var hello = "Hello world";
            Console.WriteLine(hello);
            Console.WriteLine("Welcome to C#!");
            Console.WriteLine(24.5);
            
            //
            
            var name = "Tom";
            var age = 34;
            var height = 1.7;
            Console.WriteLine('\n');
            Console.WriteLine($"Name: {name}  Age: {age}  Height: {height} m and {4+7}");
            
            //
            
            var name1 = "Tom";
            var age1 = 34;
            var height1 = 1.7;
            Console.WriteLine('\n');
            Console.WriteLine("Name: {0}  Age: {2}  Height: {1}м", name1, height1, age1);
             
            //
            
            Console.WriteLine('\n');
            
            Console.Write("Set name: ");
            var name2 = Console.ReadLine();
 
            Console.Write("Set age: ");
            var age2 = Convert.ToInt32(Console.ReadLine());
 
            Console.Write("Set height: ");
            var height2 = Convert.ToDouble(Console.ReadLine());
 
            Console.Write("Set salary: ");
            var salary2 = Convert.ToDecimal(Console.ReadLine());
 
            Console.WriteLine($"Name: {name2}  Age: {age2}  Height: {height2}м  Salary: {salary2}$");
        }
    }
}