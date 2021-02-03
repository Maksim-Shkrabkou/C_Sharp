using System;

namespace OverloadingTypeConversionOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1!
            Counter counter1 = new Counter { Seconds = 23 };
 
            int x = (int)counter1;
            Console.WriteLine(x);   // 23

            Counter counter2 = x;
            Console.WriteLine(counter2.Seconds);  // 23
            Console.WriteLine('\n');
            
            // 2!
            Counter counter3 = new Counter { Seconds = 115 };
            
            Timer timer = counter3;
            Console.WriteLine($"{timer.Hours}:{timer.Minutes}:{timer.Seconds}"); // 0:1:55
 
            Counter counter4 = (Counter)timer;
            Console.WriteLine(counter4.Seconds);  //115
        }
        
        // The previous topic covered the topic of operator overloading.
        // And closely related to this topic is the topic of overloading type conversion operators.

        // Earlier, we looked at explicit and implicit conversions of primitive types. For example:
        
        
        /*
         int x = 50;
         byte y = (byte) x; // explicit conversion from int to byte
         int z = y; // implicit conversion from byte to int
         */
        
        // And it would be nice to be able to define the logic for converting one type to another.
        // And with operator overloading, we can do that. To do this, the class defines a method of the following form:
        
        /*
         public static implicit | explicit operator Type_to_which_to_convert (original_type param)
        {
            // transformation logic
        }
        */
        
        // The public static modifiers are followed by the keyword explicit (if the conversion is explicit,
        // that is, a casting operation is needed) or implicit (if the conversion is implicit).
        // Then comes the operator keyword and then the return type to which the object should be converted.
        // The object to be converted is passed in parentheses as a parameter.

        // For example, suppose we have the following Counter class that represents
        // a stopwatch counter and stores the number of seconds in the Seconds property:
        
        class Counter
        {
            public int Seconds { get; set; }
 
            public static implicit operator Counter(int x)
            {
                return new Counter { Seconds = x };
            }
            
            public static explicit operator int(Counter counter)
            {
                return counter.Seconds;
            }
            
            public static explicit operator Counter(Timer timer)
            {
                int h = timer.Hours * 3600;
                int m = timer.Minutes * 60;
                
                return new Counter { Seconds = h + m + timer.Seconds };
            }
            public static implicit operator Timer(Counter counter)
            {
                int h = counter.Seconds / 3600;
                int m = (counter.Seconds % 3600) / 60;
                int s = counter.Seconds % 60;
                
                return new Timer { Hours = h, Minutes = m, Seconds = s };
            }
        }
        
        // The first operator converts a number - an object of type int to type Counter.
        // Its logic is simple - a new Counter object is created, in which the Seconds property is set.

        // The second operator converts the Counter object to int, that is, it gets a number from Counter.

        // Application of conversion operators in the program:
        
        // 1!
        
        // Since the conversion operation from Counter to int is defined with the explicit keyword,
        // that is, as an explicit conversion, in this case it is necessary to apply the casting operation:
        
        // int x = (int)counter1;
        
        // In the case of the conversion operation from int to Counter, nothing of the kind needs to be done,
        // since this operation is defined with the implicit keyword, that is, as implicit.
        // Which transformation operations to make explicit and which implicit ones are not so important in this case,
        // the developer decides at his own discretion.

        // Note that the type conversion operator must convert from or to the type in which it is defined.
        // That is, a conversion operator defined in type Counter must either
        // take an object of type Counter as a parameter, or return an object of type Counter.
        
        // Consider also more complex conversions, such as from one composite type to another composite type.
        // Let's say we also have a Timer class:
        
        class Timer
        {
            public int Hours { get; set; }
            public int Minutes { get; set; }    
            public int Seconds { get; set; }
        }
        
        // The Timer class represents a conditional timer that stores hours, minutes, and seconds.
        // The Counter class represents a conditional stopwatch that stores the number of seconds.
        // Based on this, we can define some logic for converting from one type to another,
        // that is, getting from seconds in the Counter object the hours, minutes and seconds in the Timer object.
        //
        // For example, 3675 seconds are essentially 1 hour, 1 minute and 15 seconds.

        // Applying transformation operations:
        
        // 2!
    }
}