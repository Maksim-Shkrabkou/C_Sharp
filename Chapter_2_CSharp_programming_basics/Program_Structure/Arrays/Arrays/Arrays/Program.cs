using System;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[4];
            
            // Here we first declared an array nums that will store data of type int.
            // Then, using the new operation, we allocated memory for 4 array elements: new int [4].
            // The number 4 is also called the length of the array.
            // With this definition, all elements receive the default value that is provided for their type.
            // For int, the default is 0.

            // Also, we can immediately specify values ​​for these elements:
            
            var nums2 = new int[4] { 1, 2, 3, 4 };
            var nums3 = new int[] { 1, 2, 3, 5 };
            var nums4 = new[] {1, 2, 3, 5};
            int[] nums5 = { 1, 2, 3, 5 };
            
            //
            
            var nums6 = new int[4];
            nums6[0] = 1;
            nums6[1] = 2;
            nums6[2] = 3;
            nums6[3] = 5;
            Console.WriteLine(nums6[3]);  // 5
            
            
            // Looping through arrays. Foreach loop
            
            Console.WriteLine('\n');
            var numbers = new[] { 1, 2, 3, 4, 5 };
            
            foreach (var element in numbers)
            {
                Console.WriteLine(element);
            }
            
            //

            Console.WriteLine('\n');
            var numbers2 = new[] { 1, 2, 3, 4, 5 };
            
            for (var i = 0; i < numbers2.Length; i++)
            {
                Console.WriteLine(numbers2[i]);
            }
            
            //
            
            Console.WriteLine('\n');
            var numbers3 = new[] { 1, 2, 3, 4, 5 };
            
            for (var i = 0; i < numbers3.Length; i++)
            {
                numbers3[i] = numbers3[i] * 2;
                Console.WriteLine(numbers3[i]);
            }
            
            
            // Multidimensional arrays

            // Arrays are characterized by such concepts as rank or number of dimensions.
            // Above, we considered arrays that have one dimension (that is, their rank is 1) -
            // such arrays can be represented as a horizontal row of an element.
            // But arrays can also be multidimensional. Such arrays have more than 1 dimension (i.e. rank).

            // Arrays that have two dimensions (rank equal to 2) are called two-dimensional.
            // For example, let's create one-dimensional and two-dimensional arrays that have the same elements:
            
            int[] nums7 = new int[] { 0, 1, 2, 3, 4, 5 };
            int[,] nums8 = { { 0, 1, 2 }, { 3, 4, 5 } };
            
            // Since the nums2 array is two-dimensional, it is a simple table.
            // All possible ways to define two-dimensional arrays:
            
            int[,] nums9;
            int[,] nums10 = new int[2, 3];
            int[,] nums11 = new int[2, 3] { { 0, 1, 2 }, { 3, 4, 5 } };
            int[,] nums12 = new int[,] { { 0, 1, 2 }, { 3, 4, 5 } };
            int[,] nums13 = new [,]{ { 0, 1, 2 }, { 3, 4, 5 } };
            int[,] nums14 = { { 0, 1, 2 }, { 3, 4, 5 } };
            
            // Arrays can have more dimensions. A 3D array declaration might look like this:
            
            int[,,] nums15 = new int[2, 3, 4];
            
            // Accordingly, there can be four-dimensional arrays and arrays with a large number of dimensions.
            // But in practice, one-dimensional and two-dimensional arrays are commonly used.

            // A certain complexity can be presented by iterating over a multidimensional array.
            // First of all, it should be borne in mind that the length of such an array is the total number of elements.
            
            Console.WriteLine('\n');
            int[,] mas = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }, { 10, 11, 12 } };
            
            foreach (var i in mas)
                Console.Write($"{i} ");
            
            Console.WriteLine();
            
            // But what if we want to go through each row in the table separately?
            // In this case, you need to get the number of elements in the dimension.
            // In particular, each array has a GetUpperBound (dimension) method
            // that returns the index of the last element in a specific dimension.
            // And if we are talking directly about a two-dimensional array,
            // then the first dimension (with index 0) is in fact a table.
            // And using the expression mas.GetUpperBound (0) + 1,
            // you can get the number of rows in the table represented by a two-dimensional array.
            // And through mas.Length / rows you can get the number of items in each row:
            
            Console.WriteLine('\n');
            int[,] mas1 = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }, { 10, 11, 12 } };
 
            int rows = mas1.GetUpperBound(0) + 1;
            int columns = mas1.Length / rows;
            // or
            // int columns = mas.GetUpperBound(1) + 1;
 
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < columns; j++)
                {
                    Console.Write($"{mas1[i, j]} \t");
                }
                Console.WriteLine();
            }
            
            
            // Array of arrays
            // An array of arrays or the so-called "jagged array" should be distinguished from multidimensional arrays:
            
            int[][] nums18 = new int[3][];
            nums18[0] = new int[2] { 1, 2 };          // allocate memory for the first subarray
            nums18[1] = new int[3] { 1, 2, 3 };       // allocate memory for the second subarray
            nums18[2] = new int[5] { 1, 2, 3, 4, 5 }; // allocate memory for the third subarray
            
            // Here, two groups of square brackets indicate that this is an array of arrays,
            // that is, an array that, in turn, contains other arrays.
            // Moreover, the length of the array is indicated only in the first square brackets,
            // all subsequent square brackets must be empty: new int [3] [].
            // In this case, our nums array contains three arrays.
            // Moreover, the dimension of each of these arrays may not coincide.
            
            // Moreover, we can use multidimensional as arrays:
            
            int[][,] nums19 = new int[3][,] 
            {
                new int[,] { {1,2}, {3,4} },
                new int[,] { {1,2}, {3,6} },
                new int[,] { {1,2}, {3,5}, {8, 13} } 
            };
            
            
            // So here we have an array of three arrays, with each of these arrays representing a two-dimensional array.
            // Using nested loops, you can iterate over jagged arrays. For example:
            Console.WriteLine('\n');
            
            int[][] numbers4 = new int[3][];
            numbers4[0] = new int[] { 1, 2 };
            numbers4[1] = new int[] { 1, 2, 3 };
            numbers4[2] = new int[] { 1, 2, 3, 4, 5 };
            
            foreach(var row in numbers4)
            {
                foreach(var number in row)
                {
                    Console.Write($"{number} \t");
                }
                Console.WriteLine();
            }

            // iteration with a for loop
            Console.WriteLine('\n');
            
            for (var i = 0; i < numbers4.Length; i++)
            {
                for (var j =0; j<numbers4[i].Length; j++)
                {
                    Console.Write($"{numbers4[i][j]} \t");
                }
                Console.WriteLine();
            }
            
            
            //Basic Array Concepts
            
            // To summarize the basic concepts of arrays:

            // Rank: the number of dimensions in the array

            // Dimension length: The length of an individual dimension in an array

            // Array length: the number of all elements in the array

            // For example, take an array
            
            int[,] numbers8 = new int[3, 4];
            
            // The numbers array is two-dimensional, that is, it has two dimensions, so its rank is 2.
            // The length of the first dimension is 3, the length of the second dimension is 4.
            // The length of the array (that is, the total number of elements) is 12.
            
            
            // Inversion of an array, that is, flipping it in reverse order:
            Console.WriteLine('\n');
            int[] numbers9;
            numbers9 = new[] { -4, -3, -2, -1,0, 1, 2, 3, 4 };
            var n = numbers9.Length; // array length
            var k = n / 2; // middle of array

            for(var i=0; i < k; i++)
            {
                var temp = numbers9[i]; // helper for value exchange
                numbers9[i] = numbers9[n - i - 1];
                numbers9[n - i - 1] = temp;
            }
            
            foreach(var i in numbers9)
            {
                Console.Write($"{i} \t");
            }

        }
    }
}