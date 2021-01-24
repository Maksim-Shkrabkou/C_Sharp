using System;

namespace Enum
{
    class Program
    {
        static void Main(string[] args)
        {
            OperationThree op3Add = OperationThree.Add;
            Console.WriteLine(op3Add); // Add
            Console.WriteLine((int) op3Add); // 1
            Console.WriteLine('\n');
            
            //
            
            var op3Subtract = OperationThree.Subtract;
            Console.WriteLine(op3Subtract); // Subtract
            Console.WriteLine((int) op3Subtract); // 2
            Console.WriteLine('\n');
            
            //
            
            Operation op;
            op = Operation.Add;
            Console.WriteLine(op); // Add
            Console.WriteLine((int) op); // 1
            Console.WriteLine('\n');
            
            // In a program, we can assign a value to this variable.
            // In this case, one of the constants defined in this enumeration must act as its value.
            // That is, despite the fact that each constant is mapped to a certain number,
            // we cannot assign a numeric value to it, for example, Operation op = 1 ;.
            // And also if we print the value of this variable to the console, we will get constants for them,
            // not a numeric value. If you need to get a numeric value, then you should cast to a numeric type:
            
            Operation op2;
            op2 = Operation.Multiply;
            Console.WriteLine((int) op2); // 3
            Console.WriteLine('\n');

            //

            var op4 = OperationFour.Multiply;
            Console.WriteLine(op4); // Multiply
            Console.WriteLine('\n');
              
            //
                
            // The operation type is set using the Operation.Add constant, which is equal to 1
            MathOp (10, 5, Operation.Add);
            // The operation type is set using the Operation.Multiply constant, which is equal to 3
            MathOp (11, 5, Operation.Multiply);
            
            // Here we have an Operation enum, which represents arithmetic operations.
            // We also have a MathOp method defined, which takes two numbers and an operation type as parameters.
            // In the main Main method, we call the MathOp procedure twice,
            // passing in two numbers and the type of operation.
        }

        // Besides primitive data types, C # has such a type as enum or enumeration.
        // Enumerations represent a collection of logically related constants.
        // An enumeration is declared using the enum operator.
        // Next comes the name of the enumeration, after which the type of the enumeration is indicated
        // - it must necessarily represent an integer type (byte, int, short, long).
        // If the type is not explicitly specified, the default is int.
        // Then comes a comma-separated list of enumeration elements:
        
        enum Days
        {
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Sunday
        }
        
        enum Time : byte
        {
            Morning,
            Afternoon,
            Evening,
            Night
        }
        
        // In these examples, each element of the enumeration is assigned an integer value,
        // with the first element being 0, the second 1, and so on.
        // We can also specify the values of the elements explicitly,
        // either by specifying the value of the first element:
        
        enum Operation
        { 
            Add = 1,   // each next element is incremented by one by default
            Subtract,  // this element is 2
            Multiply,  // equals 3
            Divide     // equals 4
        }
        
        // But you can also explicitly specify values for all elements:

        enum OperationTwo
        {
            Add = 2,
            Subtract = 4,
            Multiply = 8,
            Divide = 16
        }
        
        // In this case, the enumeration constants can have the same values,
        // or you can even assign one constant the value of another constant:
        
        enum Color
        {
            White = 1,
            Black = 2,
            Green = 2,
            Blue = White // Blue = 1
        }
        
        // Each enum actually defines a new data type.
        // Then in the program, we can define a variable of this type and use it:
        
        enum OperationThree
        {
            Add = 1,
            Subtract,
            Multiply,
            Divide
        }
        
        // Often, an enumeration variable acts as a state store, depending on which some actions are performed.
        // So, let's consider the use of enumeration using a more real-life example:
        
        static void MathOp(double x, double y, Operation op)
        {
            var result = op switch
            {
                Operation.Add => x + y,
                Operation.Subtract => x - y,
                Operation.Multiply => x * y,
                Operation.Divide => x / y,
                _ => 0.0
            };

            Console.WriteLine("The result of the operation is {0}", result);
        }
    }
    
    // It is also worth noting that the enumeration does not have to be defined inside the class,
    // it is possible outside the class, but within the namespace:
    
    enum OperationFour
    {
        Add = 1,
        Subtract,
        Multiply,
        Divide
    }
}