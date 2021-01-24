using System;

namespace PassingParametersByReferenceAndValueOutputParameters
{
    class Program
    {
        static void Main(string[] args)
        {
            // There are two ways to pass parameters in a C # method: by value and by reference.
            
            // Passing parameters by 'value'
            // The simplest way of passing parameters is passing by value, in fact,
            // this is the usual way of passing parameters:
            
            Console.WriteLine(Sum(10, 15));        //  parameters passing by value
            Console.WriteLine('\n');
           
            
            // !!!
            // Passing parameters by reference and 'ref' modifier
            // When passing parameters by reference, the ref modifier is used before the parameters:
            
            var x = 10;
            var y = 15;
            Console.WriteLine(x); // x = 10
            Addition(ref x, y); // calling method
            Console.WriteLine(x);   // x = 25
            Console.WriteLine('\n');
            
            // Note that the ref modifier is specified both when declaring a method and when calling
            // it in the Main method.
            
            
            // Comparison of pass by value and by reference
            // What is the difference between the two methods of passing parameters?
            // When passed by value, the method receives not the variable itself, but its copy.
            // And when passing a parameter by reference, the method receives the address of the variable in memory.
            // And thus, if the value of the parameter passed by reference changes in the method,
            // the value of the variable that is passed in its place also changes.

            // Let's look at two similar examples. The first example is passing a parameter by value:
            
            var a = 5;
            Console.WriteLine($"The initial value of the variable a = {a}");
 
            // Passing variables by value
            // After executing this code, still a = 5, since we only passed a copy of it
            IncrementVal(a);
            Console.WriteLine($"The variable a after passing by value is equal to = {a}");
            Console.WriteLine('\n');
            
            // When called, the IncrementVal method gets a copy of the variable a and increases the value of that copy.
            // Therefore, in the IncrementVal method itself, we see that the value of the x parameter has increased by 1,
            // but after the execution of the method, the variable a has the same value - 5. That is, the copy changes,
            // but the variable itself does not change.

            // The second example is a similar method with passing a parameter by reference:
            
            var a1 = 5;
            Console.WriteLine($"The initial value of the variable a = {a}");
 
            // Passing variables by reference
            // AAfter executing this code, a = 6, since we passed the variable itself
            IncrementRef(ref a1);
            Console.WriteLine($"The variable a after passing by value is equal to = {a1}");
            Console.WriteLine('\n');
            
            // A reference to the variable a1 itself in memory is passed to the IncrementRef method.
            // And if the value of the parameter in IncrementRef changes,
            // then this also leads to a change in the variable a1,
            // since both the parameter and the variable point to the same address in memory.
            
            
            // !!!
            // Output parameters. 'Out' modifier
            // Above, we have used input parameters. But the parameters can also be output.
            // To make a parameter output, an out modifier is placed before it:
            // Here, the result is returned not through a 'return' statement, but through an output parameter.
            var x1 = 10;
            int z1;
            Sum(x1, 15, out z1);
            Console.WriteLine(z1);
            Console.WriteLine('\n');
            
            // Moreover, as in the case of ref, the out keyword is used both when defining a method and when calling it.
            
            // The beauty of using such parameters is that, in fact, we can return from a method not one option,
            // but several. For example:
            var x2 = 10;
            int area;
            int perimetr;
            GetData(x2, 15, out area, out perimetr);
            Console.WriteLine("Area : " + area);
            Console.WriteLine("Perimeter : " + perimetr);
            Console.WriteLine('\n');
            
            // Here we have a GetData method that, for example, takes the side of a rectangle.
            // And we use two output devices to calculate the area and perimeter of the rectangle.

            // Essentially, as with the ref keyword, an out-of-pass word is used for by-reference arguments.
            // However, unlike refs, numbers that are sent with output terminals do not require initialization. And besides, the called method must necessarily assign a value to them.

            // It is worth noting that starting from version C # 7.0,
            // you can define variables in directly when calling a method. That is, instead of:
            
            /*
             int x = 10;
             int area;
             int perimetr;
             GetData(x, 15, out area, out perimetr);
             Console.WriteLine($"Area : {area}");
             Console.WriteLine($"Perimeter : {perimetr}");
            */
            
            // We can write:
            var x4 = 10;
            GetData(x4, 15, out int area4, out int perimetr4);
            Console.WriteLine($"Area : {area4}");
            Console.WriteLine($"Perimeter : {perimetr4}");
            Console.WriteLine('\n');

            
            // !!!
            // Input parameters. 'In' modifier
            // In addition to the output parameters with the out modifier,
            // the method can use the input parameters with the in modifier.
            // The in modifier indicates that this parameter will be passed to the method by reference,
            // but inside the method its parameter value cannot be changed. For example, take the following method:

            var x5 = 23;
            GetData(in x5, 12, out int area5, out int perimetr5);
            Console.WriteLine($"Area : {area5}");
            Console.WriteLine($"Perimeter : {perimetr5}");
            
            // In this case, values are passed to the method through the x and y parameters,
            // but in the method itself you can change only the value of the y parameter,
            // since the x parameter is specified with the in modifier.
        }
        
        static int Sum(int x, int y) => x + y;
        
        
        // parameter x is passed by reference
        static void Addition(ref int x, int y) => x += y;
        
        
        // parameter x is passed by value
        static void IncrementVal(int x)
        {
            x++;
            Console.WriteLine($"IncrementVal: {x}");
        }
        
        // parameter x is passed by reference
        static void IncrementRef(ref int x)
        {
            x++;
            Console.WriteLine($"IncrementRef: {x}");
        }
        
        static void Sum(int x, int y, out int a)
        {
            a = x + y;
        }
        
        static void GetData(int x, int y, out int area, out int perim)
        {
            area = x * y;
            perim = (x + y) * 2; 
        }
        
        static void GetData(in int x, int y, out int area, out int perim)
        {
            // x = x + 10; parameter value x cannot be changed
            y = y + 10;
            area = x * y;
            perim = (x + y) * 2;
        }
    }
}