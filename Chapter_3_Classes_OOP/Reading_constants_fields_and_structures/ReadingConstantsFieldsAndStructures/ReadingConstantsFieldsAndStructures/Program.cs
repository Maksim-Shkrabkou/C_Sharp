using System;

namespace ReadingConstantsFieldsAndStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1!
            //MathLib.E=3.8; // Error, constant value cannot be changed
            
            // 2!
            Console.WriteLine(MathLib.PI);
            Console.WriteLine('\n');
            
            // 3!
            var mathLib3 = new MathLib3(3.8);
            Console.WriteLine(mathLib3.K); // 3.8
            Console.WriteLine('\n');
            
            //mathLib3.K = 7.6; // read field cannot be set outside of its class
        }
        
        // Class fields are ordinary class-level variables.
        // We have already looked at variables - their declaration and initialization.
        // However, we have not yet touched on some points, for example, constants and read fields.

        
        //
         
        
        // !!!Constants!!!
        
        // Constants are characterized by the following features:

        // Constant must be initialized when defining

        // Once defined, the value of the constant cannot be changed

        // Constants are intended to describe values that should not be changed in the program.
        // The const keyword is used to define constants:
            
        const double PI = 3.14;
        const double E = 2.71;
            
        // When using constants, remember that we can declare them only once
        // and that they must be defined by the time of compilation.
        
        class MathLib
        {
            public const double PI=3.141;
            public const double E = 2.81;
            // public const double K;      // Error, constant not initialized
        }
        
        // 1!
        
        
        // Also note the syntax for calling a constant.
        // Since this is implicitly a static field, you must use the class name to refer to it.
        
        // But it should be borne in mind that we cannot declare a constant with the static modifier.
        // But this actually makes no sense.

        // A constant can be defined both at the class level and inside a method:
        
        class MathLib2
        {
            public double GetCircleArea(double radius)
            {
                const double PI = 3.141;
                
                return PI * radius * radius;
            }
        }
        
        
        //
        
        
        // !!!Reading fields!!!
        
        // Read fields can be initialized when declared, either at the class level,
        // or initialized and modified in the constructor.
        // You cannot initialize or change their value elsewhere, you can only read their value.

        // The read field is declared with the readonly keyword:
        
        class MathLib3
        {
            public readonly double K = 23;  // can be initialized like this
 
            public MathLib3(double _k)
            {
                K = _k; // the read field can be initialized or changed in the constructor after compilation
            }
            
            public void ChangeField()
            {
                // you can not do it this way
                // K = 34;
            }
        }
        
        // !!!Comparison of constants!!!
            
        // Constants must be defined at compile time, and readable fields can be defined at run time.
        // Accordingly, a constant can be initialized only when it is defined.
        // The read field can be initialized either when it is defined or in the class constructor.
        
        // Constants cannot use the static modifier, since they are already implicitly static.
        // Reading fields can be static or non-static.
        
        
        //
        
        
        // !!!Read structures!!!
        
        // In addition to readable fields, C # can define readable structures.
        // To do this, they are preceded by the readonly modifier:
        
        // readonly struct User { }
        
        // A feature of such structures is that all their fields must also be readable:
        
        readonly struct User
        {
            public readonly string Name;
            
            public User(string name)
            {
                this.Name = name;
            }
        }
        
        // The same goes for properties that should be read-only:
        
        readonly struct User2
        {
            public readonly string Name { get; } //read-only is optional
            public int Age { get; } // read-only property

            public User2(string name, int age)
            {
                this.Name = name;
                this.Age = age;
            }
        }
    }
}