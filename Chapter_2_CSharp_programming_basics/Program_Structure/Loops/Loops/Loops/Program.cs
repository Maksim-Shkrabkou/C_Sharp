using System;

namespace Loops
{
    class Program
    {
        static void Main(string[] args)
        {
            // for
            // foreach
            // while
            // do...while
            
            
            // for 
            
            for (var i = 0; i < 9; i++)
            {
                Console.WriteLine($"Square of number {i} equals {i*i}");
            }
            
            // for (endless)
            //
            // var i1 = 0;
            // for (; ;)
            // {
            //     Console.WriteLine($"Square of number {i1} equals {i1*i1}");
            // }
            
            // for (counter outside of loop)
            Console.WriteLine("\n");
            var i2 = 0;
            
            for (; i2 < 9;)
            {
                Console.WriteLine($"Square of number {++i2} equals {i2 * i2}");
            }
            
            
            // do...while
            // In a do loop, the loop code is first executed, and then the condition in the while statement is checked.
            // And as long as this condition is true, the cycle repeats. For example:
            Console.WriteLine("\n");
            var i3 = 6;
            
            do
            {
                Console.WriteLine(i3);
                i3--;
            } while (i3 > 0);
            
            // Here, the loop code will run 6 times until i becomes zero.
            // But it's important to note that the do loop guarantees at least one execution of the action,
            // even if the condition in the while statement is not true. That is, we can write:
            Console.WriteLine("\n");
            var i4 = -1;
            
            do
            {
                Console.WriteLine(i4);
                i4--;
            }
            while (i4 > 0);
            
            
            // while
            // Unlike the do loop, the while loop immediately checks the truth of some condition,
            // and if the condition is true, then the loop code is executed:
            Console.WriteLine("\n");
            var i5 = 6;
            
            while (i5 > 0)
            {
                Console.WriteLine(i5);
                i5--;
            }
            
            
            // The continue and break statements
            // Sometimes a situation arises when you need to exit the loop without waiting for it to complete.
            // In this case, we can use the break statement.
            Console.WriteLine("\n");
            
            for (var i = 0; i < 9; i++)
            {
                if (i == 5)
                    break;
                Console.WriteLine(i);
            }
            
            // Although the loop condition says that the loop will run until counter i reaches 9,
            // in reality the loop will run 5 times. Since when counter i reaches 5,
            // the 'break' statement will be triggered and the loop will end.
            
            // Now let's set ourselves another task. But what if we want the loop not to end when checking,
            // but to just skip the current iteration. To do this, we can use the 'continue' statement:
            Console.WriteLine("\n");
            
            for (var i = 0; i < 9; i++)
            {
                if (i == 5)
                    continue;
                Console.WriteLine(i);
            }
        }
    }
}