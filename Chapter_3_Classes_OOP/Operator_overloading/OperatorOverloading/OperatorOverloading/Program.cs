using System;

namespace OperatorOverloading
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1!
            var c1 = new Counter { Value = 23 };
            var c2 = new Counter { Value = 45 };
 
            var result = c1 > c2;
            var c3 = c1 + c2;
            
            // 2!
            var c4 = new Counter { Value = 23 };
            var c5 = new Counter { Value = 45 };
            var result2 = c4 > c5;
            Console.WriteLine(result2); // false
            Console.WriteLine('\n');
 
            var c6 = c4 + c5;
            Console.WriteLine(c6.Value);  // 23 + 45 = 68
            Console.WriteLine('\n');
            
            // 3!
            
            var c7 = new Counter { Value = 23 };
            var d = c7 + 27; // 50
            Console.WriteLine(d);
            Console.WriteLine('\n');

            // 4!
            var counter = new Counter() { Value = 10 };
            Console.WriteLine($"{counter.Value}");      // 10
            Console.WriteLine($"{(++counter).Value}");  // 20
            Console.WriteLine($"{counter.Value}");      // 20
            Console.WriteLine('\n');
            
            // 5!
            var counter2 = new Counter() { Value = 10 };
            Console.WriteLine($"{counter2.Value}");      // 10
            Console.WriteLine($"{(counter2++).Value}");  // 10
            Console.WriteLine($"{counter2.Value}");      // 20
            Console.WriteLine('\n');
            
            // 6!
            var counter3 = new Counter() { Value = 0 };
            if (counter3)
                Console.WriteLine(true);
            else
                Console.WriteLine(false);
        }
        
        // Along with methods, we can also overload operators.
        // For example, suppose we have the following Counter class:
        
        /*class Counter
         {
            public int Value { get; set; }
         }
        */
        
        // This class represents some counter, the value of which is stored in the Value property.
        
        // And let's say we have two objects of the Counter class - two counters that we want to compare
        // or add based on their Value properties using standard comparison and addition operations:
        
        // 1!
        
        /*
         * public static return_type operator operator (parameters)
         * {}
         */
        
        // This method must have public static modifiers, as the overloaded operator
        // will be used for all objects of this class. Next is the name of the return type.
        // The return type represents the type from which we want to get the objects.
        // For example, as a result of adding two Counter objects, we expect to get a new Counter object.
        // And as a result of comparing the two, we want to get an object of type bool,
        // which indicates whether the conditional expression is true or false.
        // But depending on the task, the return types can be anything.
        
        // Then, instead of the method name, there is the operator keyword and the operator itself.
        // And then parameters are listed in brackets.
        // Binary operators take two parameters, unary operators take one parameter.
        // And in any case,
        // one of the parameters must represent the type - the class or structure in which the operator is defined.

        // For example, let's overload a number of operators for the Counter class:
        
        class Counter
        {
            public int Value { get; set; }
         
            public static Counter operator +(Counter c1, Counter c2)
            {
                return new Counter { Value = c1.Value + c2.Value };
            }
            public static bool operator >(Counter c1, Counter c2)
            {
                return c1.Value > c2.Value;
            }
            public static bool operator <(Counter c1, Counter c2)
            {
                return c1.Value < c2.Value;
            }
            
            public static int operator +(Counter c1, int val)
            {
                return c1.Value + val;
            }
            
            public static Counter operator ++(Counter c1)
            {
                return new Counter { Value = c1.Value + 10 };
            }
            
            public static bool operator true(Counter c1)
            {
                return c1.Value != 0;
            }
            public static bool operator false(Counter c1)
            {
                return c1.Value == 0;
            }
        }
        
        // Since all overloaded operators are binary - that is,
        // they are performed over two objects, then for each overload there are two parameters.

        // Since in the case of the addition operation we want to add two objects of the Counter class,
        // the operator takes two objects of this class.
        // And since we want to get a new Counter object as a result of addition,
        // this class is also used as the return type.
        // All actions of this operator are reduced to creating a new object,
        // the Value property of which combines the values of the Value property of both parameters:
        
        /*
         * public static Counter operator +(Counter c1, Counter c2)
          {
            return new Counter { Value = c1.Value + c2.Value };
          }
         */
        
        // Two comparison operators have also been redefined.
        // If we override one of these comparison operations, then we must also override the second of these operations.
        // The comparison operators themselves compare the values of the Value properties and,
        // depending on the result of the comparison, return either true or false.

        // Now we use overloaded operators in the program:
        
        // 2!
        
        // It is worth noting that since, in fact, the definition of an operator is a method,
        // we can also overload this method, that is, create another version for it.
        //
        // For example, let's add another operator to the Counter class:
        
        /*
         * public static int operator +(Counter c1, int val)
         * {
         *      return c1.Value + val;
         * }
         */
        
        // This method adds the value of the Value property and a number, returning their sum.
        // And we can also use this operator:
        
        // 3!
        
        // It should be borne in mind that during overloading,
        // those objects that are passed to the operator through parameters should not be changed.
        // For example, we can define an increment operator for the Counter class:
        
        /*
         * public static Counter operator ++(Counter c1)
         * {
         *      c1.Value += 10;
         *
         *      return c1;
         * }
         */
        
        // Since the operator is unary,
        // it takes only one parameter - an object of the class in which this operator is defined.
        // But this is an incorrect definition of the increment,
        // since the operator should not change the values of its parameters.

        // And a more correct overload of the increment operator would look like this:
        
        /*
         * public static Counter operator ++(Counter c1)
         * {
                return new Counter { Value = c1.Value + 10 };
           }
         */
        
        // That is, a new object is returned that contains the incremented value in the Value property.

        // At the same time, we do not need to define separate operators for
        // prefix and postfix increments (as well as decrements), since one implementation will work in both cases.

        // For example, let's use the prefix increment operation:
        
        // 4!
        
        // Now we use the postfix increment:
        
        // 5!
        
        // It is also worth noting that we can override the true and false operators.
        // For example, let's define them in the Counter class:
        
        // "in Counter class"
        
        // These operators are overloaded when we want to use an object of the type as a condition. For example:
        
        // 6!
        
        // When overloading operators, keep in mind that not all operators can be overloaded.
        // In particular, we can overload the following operators:

        // unary operators +, -,!, ~, ++, -

        // binary operators +, -, *, /,%

        // comparison operations ==,! =, <,>, <=,> =
        
        // logical operators &&, ||

        // And there are a number of operators that cannot be overloaded,
        // such as the equality operator = or the ternary operator?:, As well as a number of others.

        // A complete list of overloaded operators can be found in the msdn documentation
    
        // When overloading operators,
        // you should also remember that we cannot change the precedence of an operator or its associativity,
        // we cannot create a new operator or change the logic of operators in types, which is by default in .NET.
    }
}