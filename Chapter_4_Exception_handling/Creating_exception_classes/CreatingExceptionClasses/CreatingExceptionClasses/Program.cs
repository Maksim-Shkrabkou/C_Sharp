using System;

namespace CreatingExceptionClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1!
            try
            {
                var p = new Person { Name = "Tom", Age = 17 };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
            
            Console.WriteLine("\n");
            
            // 2!
            try
            {
                var p = new Person2 {Name = "Tom", Age = 13};
            }
            catch (PersonException ex)
            {
                Console.WriteLine ($"Error: {ex.Message}");
                Console.WriteLine ($"Invalid value: {ex.Value}");
            }
        }
        
        // If we are not satisfied with the built-in exception types, then we can create our own types.
        // The base class for all exceptions is the Exception class, so we can inherit this class to create our own types.

        // Let's say we have an age limit in our program:
        
        // 1!
        
        class Person
        {
            private int age;
            public string Name { get; set; }
            
            public int Age
            {
                get { return age; }
                set
                {
                    if (value < 18)
                    {
                        throw new Exception("Registration is prohibited for persons under 18");
                    }
                    else
                    {
                        age = value;
                    }
                }
            }
        }
        
        // In the Person class, when the age is set, a check occurs, and if the age is less than 18, an exception is thrown.
        // The Exception class takes a string as a parameter in its constructor, which is then passed to its Message property.

        // But sometimes it is more convenient to use your own exception classes.
        // For example, in some situation,
        // we want to handle in a certain way only those exceptions that belong to the Person class.
        // For these purposes, we can make a special PersonException class:

        /*class PersonException : Exception
        {
            public PersonException(string? message)
                : base(message)
            {
            }
        }*/
        
        // In fact, the class has nothing except an empty constructor, and then in the constructor
        // we simply refer to the constructor of the base Exception class, passing the message string to it.
        // But now we can change the Person class so that it throws an exception of this type and, accordingly,
        // handle this exception in the main program:

        // Each type of exception can define some of its properties. For example, in this case,
        // we can define a property in the class to store the set value:

       
        class PersonException: ArgumentException
        {
            public int Value {get;}
            
            public PersonException (string message, int val)
                : base (message)
            {
                Value = val;
            }
        }
        
        // In the constructor of the class, we set this property and when handling the exception, we can get it:
        
        // 2!
        
        class Person2
        {
            public string Name { get; set; }
            private int _age;
            
            public int Age
            {
                get => _age;
                set
                {
                    if (value < 18)
                        throw new PersonException("Registration is prohibited for persons under 18", value);
                    else
                        _age = value;
                }
            }
        }
    }
}