using System;

namespace ConditionalConstructs
{
    class Program
    {
        static void Main(string[] args)
        {
            // The if / else construction checks the truth of a certain condition and,
            // depending on the results of the test, executes a certain code:
            var num1 = 8;
            var num2 = 6;
            
            if(num1 > num2)
            {
                Console.WriteLine($"The number {num1} is greater than the number {num2}");
            }
            
            //
            
            var num3 = 8;
            var num4 = 6;
            
            if(num3 < num4)
            {
                Console.WriteLine($"The number {num3} is greater than the number {num4}");
            }
            else
            {
                Console.WriteLine($"The number {num3} is lower than the number {num4}");
            }
            
            //
            
            var num5 = 8;
            var num6 = 8;
            
            if(num5 > num6)
            {
                Console.WriteLine($"The number {num5} is greater than the number {num6}");
            }
            else if (num5 == num6)
            {
                Console.WriteLine($"The number {num5} equals {num6}");
            }
            else
            {
                Console.WriteLine($"The number {num5} is lower than the number {num6}");
            }
            
            //
            
            var num7 = 8;
            var num8 = 6;
            
            if(num7 > num8 && num7 == 8)
            {
                Console.WriteLine($"The number {num7} is greater than the number {num8}");
            }
            
            
            
            // The switch / case construction is similar to the if / else construction,
            // since it allows you to process several conditions at once:
            
            Console.WriteLine("Press Y or N");
            var selection = Console.ReadLine();
            
            switch (selection)
            {
                case "Y":
                    Console.WriteLine("You press the letter Y");
                    break;
                case "N":
                    Console.WriteLine("You press the letter N");
                    break;
                default:
                    Console.WriteLine("You press the unknown letter");
                    break;
            }
            
            // The expression to be compared follows the switch keyword in parentheses.
            // The value of this expression is sequentially compared with the values placed after the case operator.
            // And if a match is found, then a specific case block will be executed.

            // At the end of each case block, one of the jump statements must be placed: break, goto case, return or throw.
            // Typically, the break statement is used. When applied, other case blocks will not be executed.
            
            // However, if we want, on the contrary,
            // that after the execution of the current case block another case block is executed,
            // then we can use the "goto case" statement instead of "break":
            
            var number = 1;
            
            switch (number)
            {
                case 1:
                    Console.WriteLine("case 1");
                    goto case 5; // jump to case 5
                case 3:
                    Console.WriteLine("case 3");
                    break;
                case 5:
                    Console.WriteLine("case 5");
                    break;
                default:
                    Console.WriteLine("default");
                    break;
            }
            
            
            // If we also want to handle the situation when no match is found, then we can add a default block,
            // as in the example above.
            
            // Using the return statement will allow you to exit not only from the case block,
            // but also from the calling method. That is, if in the Main method after the switch..case construction,
            // in which the return statement is used, there are any statements and expressions,
            // they will not be executed, and the Main method will exit.
            
            
            
            // Ternary operation
            
            // The ternary operation has the following syntax: [first operand is a condition]? [second operand]: [third operand].
            // There are three operands at once.
            // Depending on the condition, the ternary operation returns the second or third operand:
            // if the condition is true, then the second operand is returned;
            // if the condition is false, then the third.
            //
            // For example:
            
            var x=3;
            var y=2;
            Console.WriteLine("Press + or -");
            var select = Console.ReadLine();
 
            var z = select == "+" ? (x+y) : (x-y);
            Console.WriteLine(z);
        }
    }
}