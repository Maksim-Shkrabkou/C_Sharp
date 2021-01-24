using System;

namespace ScopeOfVariables
{
    class Program // start of class context
    {
        static int a = 9; // class level variable
        
        static void Main(string[] args) // start of the Main method context
        {
            // Each variable is available within a specific context or scope. Outside of this context, the variable no longer exists.

            // There are various contexts:

            // Class context. Variables defined at the class level are available in any method of this class
            
            // Method context. Variables defined at the method level are local and available only within the given method.
            // They are not available in other methods.
            
            // Code block context. Variables defined at the level of a code block are also local
            // and are only available within that block. They are not available outside of their code block.
            
            // For example, suppose the Program class is defined as follows:
            
            var b = a - 1;  // method level variable
 
            { // start of the context of the code block
             
                var c = b - 1; // code block level variable
 
            }  // end of the context of the code block, the variable c is destroyed
 
            // this is not possible, the c variable is defined in the code block
            //Console.WriteLine(c);
 
            // this is not possible, the variable d is defined in another method
            //Console.WriteLine(d);

        }// end of context for Main method, variable b is destroyed
        
        void Display() // start of Display method context
        {
            // variable a is defined in the class context, so it is available
            var d = a + 1;
 
        } // end of context of Display method, variable d is destroyed
        
        
        
        // There are definitely four variables here: a, b, c, d. Each of them exists in its own context.
        //
        // The variable a exists in the context of the entire Program class
        // and is available anywhere and in a block of code in the Main and Display methods.

        // The b variable only exists within the Main method.
        // As well as the d variable exists within the Display method. In the Main method,
        // we cannot refer to the d variable, since it is in a different context.

        // The c variable only exists in a block of code that is bound by an opening and closing curly brace.
        // Outside its boundaries, the variable c does not exist and cannot be accessed.
        
        // Often times, the boundaries of various contexts can be associated with opening and closing curly braces,
        // as in this case, which define the boundaries of a code block, method, or class.

        // When working with variables, keep in mind that local variables defined in a method or in a block of
        // code hide class-level variables if their names are the same:
        
        /*
         * class Program
         * {
         *    static int a = 9; // class level variable
         *
         *    static void Main(string[] args)
         *   {
         *      int a = 5; // hides the variable a, which is declared at the class level
         *      Console.WriteLine(a); // 5
         *    }
         *  }
         */
        
        // When declaring variables, you should also take into account that
        // in the same context you cannot define several variables with the same name.
    }
}