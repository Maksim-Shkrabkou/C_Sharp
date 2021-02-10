using System;

namespace AnonymousMethods
{
    class Program
    {
        // 1!
        delegate void MessageHandler(string message);
        
        // 4!
        delegate int Operation(int x, int y);
        
        static void Main(string[] args)
        {
            // 1!
            MessageHandler handler = delegate(string mes)
            {
                Console.WriteLine(mes);
            };
            
            handler("hello world!");
            Console.WriteLine('\n');
            
            // 2!
            ShowMessage("hello!", delegate(string mes)
            {
                Console.WriteLine(mes);
            });
            Console.WriteLine('\n');
            
            // 3!
            MessageHandler handler2 = delegate
            {
                Console.WriteLine("anonymous method");
            };
            handler("hello world!"); // anonymous method
            Console.WriteLine('\n');
            
            // 4!
            Operation op = delegate(int x, int y)
            {
                return x + y;
            };
            var result = op(4, 5);
            Console.WriteLine("Result: " + result); // 9
            Console.WriteLine('\n');
            
            // 5!
            var z = 8;
            Operation operation2 = delegate (int x, int y)
            {
                return x + y + z;
            };
            var d = operation2(4, 5);
            Console.WriteLine("Result: " + d);       // 17
        }
        
        // Anonymous methods are closely related to delegates. Anonymous methods are used to instantiate delegates.

        // Anonymous methods begin with the delegate keyword,
        // followed by a parenthesized list of parameters and a method body in curly braces:
        
        /*
         delegate(parameters)
        {
            // instructions
        }
        */

        // For example:
        
        // 1!
        
        // An anonymous method cannot exist on its own, it is used to initialize a delegate instance,
        // as in this case the handler variable represents an anonymous method.
        // And through this delegate variable, you can call this anonymous method.

        // Another example of anonymous methods is passing as an argument for a parameter that the delegate represents:
        
        // 2!
        
        static void ShowMessage(string mes, MessageHandler handler)
        {
            handler(mes);
        }
        
        // If the anonymous method uses parameters, then they must match the parameters of the delegate.
        // If the anonymous method does not require parameters, then the parentheses with parameters are omitted.
        // Moreover, even if the delegate accepts several parameters,
        // the parameters can be omitted altogether in the anonymous method:
        
        // 3!
        
        // That is, if the anonymous method contains parameters, they must necessarily match the parameters of the delegate.
        // Or the anonymous method may not contain any parameters at all,
        // in which case it matches any delegate that has the same return type.

        // In this case, the parameters of the anonymous method cannot be omitted
        // if one or more parameters are defined with the 'out' modifier.

        // Just like regular methods, anonymous ones can return a result:
        
        // 4!
        
        // In this case, the anonymous method has access to all the variables defined in the external code:
        
        // 5!
        
        // In what situations are anonymous methods used?
        // When we need to define a one-time action that does not have many instructions and is not used anywhere else.
        // In particular, they can be used to handle events that will be discussed later.
    }
}