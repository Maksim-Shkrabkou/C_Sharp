using System;

namespace Delegates
{
    class Program
    {
        // 1!
        delegate void Message(); // 1. We declare the delegate
        
        // 2!
        delegate int Operation(int x, int y);
        
        // 3!
        delegate int Operation2(int x, int y);
        
        // 4!
        delegate int Operation3(int x, int y);
        
        // 5!
        delegate void Message2();
        
        // 9!
        delegate int Operation4(int x, int y);
        delegate void Message3();
        
        // 13!
        delegate void GetMessage();
        
        // 14!
        delegate T Operation<T, K>(K val);


        static void Main(string[] args)
        {
           // 1!
           Message mes; // 2. Create a delegate variable

           if (DateTime.Now.Hour < 12)
           {
               mes = GoodMorning; // 3. Assign the method address to this variable 
           }
           else
           {
               mes = GoodEvening;
           }
           
           mes(); // 4. Call the method
           Console.WriteLine('\n');
           
           // 2!
           Operation del = Add; // delegate points to Add method
           var result = del(4, 5); // actually Add (4, 5)
           Console.WriteLine(result);
 
           del = Multiply; // now the delegate points to the Multiply method
           result = del(4, 5); // actually Multiply (4, 5)
           Console.WriteLine(result);
           Console.WriteLine('\n');
           
           // 3!
           Math math = new Math();
           Operation2 del2 = math.Sum;
           var result2 = del(4, 5);     // math.Sum(4, 5)
           Console.WriteLine(result2);  // 9
           Console.WriteLine('\n');
           
           // 4!
           Operation3 del5 = Add;  // Both methods are equivalent.
           Operation3 del6 = new Operation3(Add);  // Both methods are equivalent.
           
           // 5!
           Message2 message2 = Hello;
           message2 += HowAreYou; // message2 now points to two methods
           message2(); // both methods are called - Hello and HowAreYou
           Console.WriteLine('\n');
           
           // 6!
           Message message3 = Hello;
           message3 += HowAreYou;
           message3 += Hello;
           message3 += Hello;
 
           message3();
           Console.WriteLine('\n');
           
           // 7!
           Message message4 = Hello;
           message4 += HowAreYou;
           message4(); // all methods from message4 are called
           message4 -= HowAreYou; // remove the HowAreYou method
           Console.WriteLine('\n');
           message4(); // method Hello is called
           Console.WriteLine('\n');
           
           // 8!
           Message mes1 = Hello;
           Message mes2 = HowAreYou;
           Message mes3 = mes1 + mes2; // merge delegates
           mes3(); // all methods from mes1 and mes2 are called
           Console.WriteLine('\n');
           
           // 9!
           Message3 message5 = Hello;
           message5.Invoke();
           Operation4 op4 = Add;
           Console.WriteLine(op4.Invoke(9, 9));
           Console.WriteLine('\n');
           
           // 10!
           /*
            Message mes = null; // mes (); //! Error: delegate is null

            Operation op = Add;
            op -= Add; // op delegate is empty
            op(3, 4); //! Error: delegate is null
            */
           
           // 11!
           /*
           Message mes = null;
           mes?.Invoke(); // no error, the delegate is simply not called
    
           Operation op = Add;
           op -= Add; // op delegate is empty
           op?.Invoke (3, 4); // no error, the delegate is simply not called
           */
           
           // 12!
           Operation op = Subtract;
           op += Multiply;
           op += Add;
           Console.WriteLine(op(7, 2));    // Add(7,2) = 9
           Console.WriteLine('\n');
           
           // 13!
           if (DateTime.Now.Hour < 12)
           {
               Show_Message(GoodMorning);
           }
           else
           {
               Show_Message(GoodEvening);
           }
           Console.WriteLine('\n');
           
           // 14!
           Operation<decimal, int> op2 = Square;
           Console.WriteLine(op2(5));
        }
        
        // Delegates represent objects that point to methods.
        // That is, delegates are pointers to methods and using delegates we can call these methods.

        // !!!Defining delegates!!!
        
        // The delegate keyword is used to declare a delegate, followed by the return type, name, and parameters.
        // For example:
        
        /*
         * delegate void Message();
         */
        
        // The Message delegate is void (that is, it returns nothing) and does not take any parameters.
        // This means that this delegate can point to any method that takes no parameters and returns nothing.

        // Consider using this delegate:
        
        // 1!
        
        private static void GoodMorning() =>
            Console.WriteLine("Good Morning");

        private static void GoodEvening() =>
            Console.WriteLine("Good Evening");
        
        //Here we first define the delegate:
            
        /*delegate void Message();*/ // 1. We declare the delegate
        
        // In this case, the delegate is defined inside the class, but you can also define the delegate outside the class inside the namespace.

        // To use a delegate, a variable of this delegate is declared:
            
        /*Message mes;*/ // 2. Create a delegate variable
        
        // Using the DateTime.Now.Hour property, we get the current hour. And depending on the time,
        // the address of a specific method is passed to the delegate.
        // Note that these methods have the same return value
        // and the same set of parameters (in this case, no parameters) as the delegate.

        /*mes = GoodMorning;*/ // 3. Assign the method address to this variable
        
        // Then, through the delegate, we call the method that this delegate refers to:
        
        // 2!
        
        private static int Add(int x, int y) => x+y;

        private static int Multiply (int x, int y) => x * y;
        
        
        // In this case, the Operation delegate returns an int and has two int parameters.
        // Therefore, this delegate corresponds to any method that returns an int value and takes two int parameters.
        // In this case, these are the Add and Multiply methods.
        // That is, we can assign any of these methods to a delegate variable and call.

        // Since the delegate takes two parameters of type int, when calling it,
        // you need to pass values for these parameters: del (4,5).

        // Delegates can optionally only point to methods that are defined in the same class
        // where the delegate variable is defined. It can also be methods from other classes and structures.
        
        // 3!
        
        class Math
        {
            public int Sum(int x, int y) { return x + y; }
        }
        
        
        //
        
        
        // !!!Method reference assignment!!!
        
        // Above the delegate variable was directly assigned the method.
        // There is another way - creating a delegate object using the constructor, which is passed the required method:
     
        // 4!
        
        // Both methods are equivalent.
        
        
        //
        
        
        // !!!Mapping Methods to a Delegate!!!
        
        // As described above, methods correspond to a delegate if they have the same return type and the same set of parameters.
        // But it should be borne in mind that the 'ref' and 'out' modifiers are also taken into account.
        // For example, let's say we have a delegate:
        
        /*delegate void SomeDel (int a, double b);*/
        
        //This delegate corresponds, for example, the following method:
            
        /*void SomeMethod1 (int g, double n) {}*/
        
        // And the following methods DO NOT match:
            
        /*
         int SomeMethod2 (int g, double n) {}
         void SomeMethod3 (double n, int g) {}
         void SomeMethod4 (ref int g, double n) {}
         void SomeMethod5 (out int g, double n) {g = 6;}
         */
        
        // Here the SomeMethod2 method has a different return type than the delegate type. SomeMethod3 has a different set of parameters.
        // SomeMethod4 and SomeMethod5 parameters also differ from delegate parameters because they have ref and out modifiers.
        
        
        //
        
        
        // !!!Adding Methods to the Delegate!!!
            
        // In the examples above, the delegate variable pointed to one method.
        // In reality, a delegate can point to many methods that have the same signature and return type.
        // All methods in the delegate fall into a special list - the invocation list or invocation list.
        // And when the delegate is called, all methods from this list are sequentially called.
        // And we can add not one, but several methods to this list.
        
        // 5!
        
        private static void Hello() => 
            Console.WriteLine("Hello");

        private static void HowAreYou() =>
            Console.WriteLine("How are you?");
        
        // In this case, two methods, Hello and HowAreYou, are added to the mes1 delegate invocation list.
        // And when mes1 is called, both of these methods are called at once.

        // The '+=' operation is used to add delegates.
        // However, it is worth noting that in reality a new delegate object will be created,
        // which will receive the methods of the old copy of the delegate and the new method,
        // and the newly created delegate object will be assigned to the mes1 variable.

        // When adding delegates, it should be borne in mind that we can add a reference to the same method several times,
        // and then there will be several references to the same method in the list of the delegate call.
        // Accordingly, when calling a delegate, the added method will be called as many times as it was added:
        
        // 6!
        
        /*
        Message message3 = Hello;
        message3 += HowAreYou;
        message3 += Hello;
        message3 += Hello;
 
        message3();
        */
        
        
        // Console output:

        /*
        Hello 
        How are you?
        Hello 
        Hello
        */
        
        // Similarly, we can remove methods from a delegate using the '-=' operation:
        
        // 7!
        
        // Removing methods from a delegate will actually create a new delegate,
        // which will contain one less method in the method call list.

        // When deleting, keep in mind that if a delegate contains multiple references to the same method,
        // then the '-=' operation starts searching from the end of the delegate invocation list and removes only the first found occurrence.
        // If there is no such method in the call list of the delegate, then the - = operation has no effect.
        
        
        //
        
        
        // !!!Combining delegates!!!
        
        // Delegates can be combined into other delegates. For example:
        
        // 8!
        
        // In this case, the mes3 object represents the union of the mes1 and mes2 delegates.
        // Combining delegates means that all methods from the mes1 and mes2 delegates will be included in the mes3 delegate invocation list.
        // And when the mes3 delegate is called, all these methods will be called at the same time.

        
        //
        
        
        // !!!Delegate call!!!
            
        // In the examples above, the delegate was called as a normal method. If the delegate accepted parameters,
        // then when it was called for the parameters, the necessary values were passed:
        
        /*class Program
        {
            delegate int Operation(int x, int y);
            delegate void Message();
 
            static void Main(string[] args)
            {
                Message mes = Hello;
                mes();
                Operation op = Add;
                op(3, 4);
                Console.Read();
            }
            private static void Hello() { Console.WriteLine("Hello"); }
            private static int Add(int x, int y) { return x + y; }
        }*/
        
        // Another way to call the delegate is the Invoke() method:
        
        // 9!
        
        // If the delegate takes parameters, values for those parameters are passed to the Invoke method.

        // It should be borne in mind that if a delegate is empty, that is,
        // there are no references to any of the methods in its call list (that is, the delegate is Null),
        // then when such a delegate is called, we will receive an exception, as, for example, in the following case:
        
        // 10!
        
        /*
        Message mes = null; // mes (); //! Error: delegate is null
 
        Operation op = Add;
        op -= Add; // op delegate is empty
        op(3, 4); //! Error: delegate is null
        */
        
        // Therefore, when invoking a delegate, it is always better to check if it is not null.
        // Alternatively, you can use the Invoke method and the conditional null operator:
          
        // 11!
        
        /*
        Message mes = null;
        mes?.Invoke(); // no error, the delegate is simply not called
 
        Operation op = Add;
        op -= Add; // op delegate is empty
        op?.Invoke (3, 4); // no error, the delegate is simply not called
        */
        
        // If the delegate returns some value, then the value of the last method from the call list is returned (if there are several methods in the call list).
        // For example:
        
        // 12!
        
        private static int Subtract(int x, int y) { return x - y; }
        
        
        //
        
        
        // !!!Delegates as method parameters!!!
        
        // Also, delegates can be method parameters:
        
        // 13!

        /*class Program
        {
            delegate void GetMessage();
 
            static void Main(string[] args)
            {
                if (DateTime.Now.Hour < 12)
                {
                    Show_Message(GoodMorning);
                }
                else
                {
                    Show_Message(GoodEvening);
                }
                Console.ReadLine();
            }
            private static void Show_Message(GetMessage _del)
            {
                _del?.Invoke();
            }
            private static void GoodMorning()
            {
                Console.WriteLine("Good Morning");
            }
            private static void GoodEvening()
            {
                Console.WriteLine("Good Evening");
            }
        }*/
        
        private static void Show_Message(GetMessage _del)
        {
            _del?.Invoke();
        }
        
        
        //
        
        
        // !!!Generalized delegates!!!
        
        // Delegates can be generic, for example:
        
        // 14!
        
        /*delegate T Operation<T, K>(K val);
 
        class Program
        {
            static void Main(string[] args)
            {
                Operation<decimal, int> op = Square;
 
                Console.WriteLine(op(5));
                Console.Read();
            }
 
            static decimal Square(int n)
            {
                return n * n;
            }
        }*/

        private static decimal Square(int n)
        {
            return n * n;
        }
    }
}