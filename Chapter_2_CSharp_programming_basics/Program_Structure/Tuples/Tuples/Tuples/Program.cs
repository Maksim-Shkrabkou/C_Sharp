using System;
using System.Threading;

namespace Tuples
{
    class Program
    {
        static void Main(string[] args)
        {
            // Tuples provide a convenient way to work with a set of values that was added in C # 7.0.

            // A tuple represents a set of values enclosed in parentheses:

            var tuple = (5, 10);
            
            // In this case, a tuple is defined, which has two values: 5 and 10.
            // In the future, we can refer to each of these values
            // through the fields named Item [ordinal_number_of_field_in_tuple]. For example:
            
            Console.WriteLine(tuple.Item1); // 5
            Console.WriteLine(tuple.Item2); // 10
            tuple.Item1 += 26;
            Console.WriteLine(tuple.Item1); // 31
            Console.WriteLine('\n');
            
            // In this case, the type is determined implicitly.
            // But we can also explicitly specify the type for a tuple variable:

            (int, int) tuple2 = (5, 10);
            
            // Since a tuple contains two numbers, we need to specify two numeric types in the type definition.
            // Or another example of defining a tuple:

            (string, int, double) tuple3 = ("Hi", 5, 88.88);
            
            // The first element of the tuple in this case represents a string,
            // the second element is of type int, and the third is of type double.

            // We can also name the fields of the tuple:
            
            var tuple4 = (count:5, sum:10);
            Console.WriteLine(tuple4.count); // 5
            Console.WriteLine(tuple4.sum); // 10
            Console.WriteLine('\n');
            
            // Now, to refer to the fields of the tuple, their names are used, rather than the names Item1 and Item2.
            
            Console.WriteLine(tuple4.count);
            Console.WriteLine(tuple4.sum);
            Console.WriteLine('\n');

            // We can even not use a variable to define the entire tuple, but use separate variables for its fields:
            
            var (name, age) = ("Tom", 23);
            Console.WriteLine(name);    // Tom
            Console.WriteLine(age);     // 23
            Console.WriteLine('\n');
            
            // In this case,
            // we can work with the fields of the tuple as with the variables that are defined within the method.
            
            
            // 
            
            // Using tuples
            
            // Tuples can be passed as parameters to a method,
            // they can be the return result of a function, or they can be used in some other way.

            // For example, one of the common situations is when a function returns two or more values,
            // while a function can only return one value. And tuples represent the optimal way to accomplish this task:
            
            var tuple5 = GetValues();
            Console.WriteLine(tuple5.Item1); // 1
            Console.WriteLine(tuple5.Item2); // 3
            Console.WriteLine('\n');
            
            // Here's a GetValues() method that returns a tuple.
            
            // A tuple is defined as a set of values, enclosed in parentheses.
            // And in this case, we return a tuple of two elements of type int, that is, two numbers.

            // Another example:
            
            var tuple6 = GetNamedValues(new int[]{ 1,2,3,4,5,6,7});
            Console.WriteLine(tuple6.count);
            Console.WriteLine(tuple6.sum);
            Console.WriteLine('\n');
            
            // And also a tuple can be passed as a parameter to a method:
            
            var (name1, age1) = GetTuple(("Tom", 23), 12);
            Console.WriteLine(name1);    // Tom
            Console.WriteLine(age1);     // 35
            
        }
        
        
        private static (int, int) GetValues()
        {
            var result = (1, 3);
            
            return result;
        }
        
        private static (int sum, int count) GetNamedValues(int[] numbers)
        {
            var result = (sum:0, count: 0);
            
            for (var i=0; i < numbers.Length; i++)
            {
                result.sum += numbers[i];
                result.count++;
            }
            return result;
        }
        
        // And also a tuple can be passed as a parameter to a method:
        private static (string name, int age) GetTuple((string n, int a) tuple, int x)
        {
            var result = (name: tuple.n, age: tuple.a + x);
            
            return result;
        }
    }
}