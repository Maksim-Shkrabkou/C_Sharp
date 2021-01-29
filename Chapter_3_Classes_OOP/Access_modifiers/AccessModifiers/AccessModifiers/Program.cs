using System;

namespace AccessModifiers
{
    class Program
    {
        static void Main(string[] args)
        {
            var state1 = new State();
 
            // we won't be able to assign the value to the variable defaultVar,
            // since it has a private modifier and the Program class does not see it
            // And the environment will underline this line as incorrect
            //state1.defaultVar = 5; // Error, cannot be accessed
 
            // the same applies to the privateVar variable
            //state1.privateVar = 5; // Error, cannot be accessed
 
            // assigning the value to the protectedPrivateVar variable will fail,
            // since the Program class is not a subclass of the State class
            //state1.protectedPrivateVar =5; // Error, cannot be accessed
 
            // assigning a value to the protectedVar variable will also fail,
            // since the Program class is not a subclass of the State class
            //state1.protectedVar = 5; // Error, cannot be accessed
            
            
            // the internalVar variable with the internal modifier is accessible from anywhere in the current project
            // so safely assign a value to it
            state1.internalVar = 5;
 
            // the protectedInternalVar variable is also accessible from anywhere in the current project
            state1.protectedInternalVar = 5;
 
            // the publicVar variable is public
            state1.publicVar = 5;
            
            
            //state1.defaultMethod(); // Error, cannot be accessed
            
            // state1.privateMethod(); // Error, cannot be accessed
 
            // state1.protectedPrivateMethod(); // Error, cannot be accessed
 
            // state1.protectedMethod(); // Error, cannot be accessed
 
            state1.internalMethod();    // work
 
            state1.protectedInternalMethod();  // work
 
            state1.publicMethod();      // work
        }
    }
    
    // All class members - fields, methods, properties - they all have access modifiers.
    // Access modifiers allow you to set a set scope for class members.
    //
    // That is, access modifiers define the context in which a service variable or method can be used.
    // In the previous topics, we have already encountered
    // it when we declared it public (that is, with the public modifier).
    
    
    // The following access modifiers are used in C #:

    // public: public, public class, or class member.
    // Such a class member is accessible from anywhere in the code, as well as from other programs and assemblies.

    // private: private class or class member.
    // Represents the exact opposite of the public modifier.
    // Such a private class or class member is only accessible from code in the same class or context.

    // protected: Such a class member is accessible from anywhere in the current class or in derived classes.
    // However, derived classes can be located in other assemblies.

    // internal: a class and members of a class with a similar modifier are accessible
    // from anywhere in the code in the same assembly,
    // but it is not available to other programs and assemblies (as is the case with the public modifier).
    
    // protected internal: combines the functionality of two modifiers.
    // Classes and class members with this modifier are available from the current assembly and from derived classes.

    // private protected: Such a class member is accessible from anywhere in the current class
    // or in derived classes that are defined in the same assembly.
    
    
    // We can explicitly set the access modifier, for example:
    
    /*
     * private protected class State
     * {
     *      internal int a;
     *      protected void Print()
     *      { 
                Console.WriteLine($"a = {a}"); 
            }
        }
     */
    
    // Or we can not specify:
    
    /*
     * class State
     * {
            int a;
            void Print() 
            { 
                Console.WriteLine($"a = {a}"); 
            }
        }
     */
    
    // If no access modifier is defined for fields and methods, the !!!'private!!!' modifier is used by default.

    // Classes and structures declared without a modifier have !!!'internal'!!! access by default.

    // All classes and structures that are directly defined in namespaces and
    // that are not nested within other classes can only have public or internal modifiers.

    // Let's look at an example and create the following State class:
    
    public class State
    {
        
        // is the same as private int defaultVar;
        int defaultVar;
        // the field is only accessible from the current class
        private int privateVar;
        // accessible from the current class and derived classes that are defined in the same project
        protected private int protectedPrivateVar;
        // accessible from the current class and derived classes
        protected int protectedVar;
        // available anywhere in the current project
        internal int internalVar;
        // available anywhere in the current project and from derived classes in other projects
        protected internal int protectedInternalVar;
        // available anywhere in the program, as well as for other programs and assemblies
        public int publicVar;
 
        // has a private modifier by default
        void defaultMethod() => Console.WriteLine($"defaultVar = {defaultVar}");
 
        // the method is only accessible from the current class
        private void privateMethod() => Console.WriteLine($"privateVar = {privateVar}");
 
        // accessible from the current class and derived classes that are defined in the same project
        protected private void protectedPrivateMethod() => Console.WriteLine($"protectedPrivateVar = {protectedPrivateVar}");
 
        // accessible from the current class and derived classes
        protected void protectedMethod()=> Console.WriteLine($"protectedVar = {protectedVar}");
     
        // available anywhere in the current project
        internal void internalMethod() => Console.WriteLine($"internalVar = {internalVar}");
     
        // available anywhere in the current project and from inherited classes in other projects
        protected internal void protectedInternalMethod() => Console.WriteLine($"protectedInternalVar = {protectedInternalVar}");
     
        // available anywhere in the program, as well as for other programs and assemblies
        public void publicMethod() => Console.WriteLine($"publicVar = {publicVar}");
    }
    
    // Since the State class is declared with the public modifier,
    // it will be accessible from anywhere in the program, as well as from other programs and assemblies.
    // The State class has five fields for each access level.
    // Plus one variable without a modifier, which is private by default.

    // There are also six methods that will display the values of the class fields on the screen.
    // Please note that since all modifiers allow you to use class members inside this class,
    // then all class variables, including private ones, are available to all of its methods,
    // since all are in the context of the State class.
    
    // Now let's see how we can use the variables of our class in the program
    // (that is, in the Main method of the Program class) if the State and Program classes are in the same project:
    
    // Thus, we were able to set only the variables internalVar, protectedInternalVar and publicVar,
    // since their modifiers allow us to use them in this context.

    // The situation is similar with the methods:
    
    // Here, only three methods were available to us:
    // internalMethod, protectedInternalMethod, publicMethod, which have the internal, protected internal,
    // public modifiers, respectively.

    // Thanks to this system of access modifiers,
    // it is possible to hide some aspects of the class implementation from other parts of the program.

    // Despite the fact that the public and internal modifiers are similar in their action,
    // they have a big difference. Classes and members of a class with the public modifie
    // r will also be available to other programs
    // if the given class is placed in a dynamic library dll and then used in these programs.
}