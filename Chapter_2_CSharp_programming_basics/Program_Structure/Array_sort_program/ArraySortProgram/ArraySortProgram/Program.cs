using System;

namespace ArraySortProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            // Enter numbers
            var nums = new int[7];
            Console.WriteLine("Enter seven numbers");
            
            for (var i = 0; i < nums.Length; i++)
            {
                Console.Write("{0}-е number: ", i + 1);
                nums[i] = int.Parse(Console.ReadLine() ?? string.Empty);
            }
 
            // Sorting
            for (var i = 0; i < nums.Length-1; i++)
            {
                for (var j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] > nums[j])
                    {
                        var temp = nums[i];
                        nums[i] = nums[j];
                        nums[j] = temp;
                    }
                }
            }
             
            // Output
            Console.WriteLine("Sorted array output");
            
            foreach (var num in nums)
            {
                Console.WriteLine(num);
            }
            Console.ReadLine();
        }
    }
}