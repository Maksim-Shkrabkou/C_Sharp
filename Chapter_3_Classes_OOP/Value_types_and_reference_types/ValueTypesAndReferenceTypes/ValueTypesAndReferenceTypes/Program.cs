using System;

namespace ValueTypesAndReferenceTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Earlier we considered the following elementary data types: int, byte, double, string, object.
            // There are also complex types: structures, enumerations, classes.
            // All of these data types can be divided into types,
            // also called value types, (value types) and reference types (reference types).
            // It is important to understand between the two.
            
            /*
             * Value types:
             * Integer types (byte, sbyte, short, ushort, int, uint, long, ulong)
             * Floating point types (float, double)
             * Decimal type
             * Bool type
             * Char type
             * Enum enums
             * Structures (struct)
             *
             *
             * Reference types:
             * Object type
             * String type
             * Classes
             * Interfaces
             * Delegates (delegate)
             */
            
            
            // What are the differences between them?
            // To do this, you need to understand the memory organization in .NET.
            // Here memory is divided into two types: the stack and the heap.
            // Method parameters and variables that represent value types place their value on the stack.
            // The stack is a data structure that grows from bottom to top:
            // each new item added is pushed on top of the previous one.
            // The lifetime of these types of variables is limited by their context.
            // Physically, a stack is a certain area of memory in the address space.
            
            Calculate(5);
            Console.WriteLine('\n');
            
            // When such a program is launched,
            // two frames will be defined on the stack
            // - for the Main method (since it is called when the program starts) and for the Calculate method:
            
            
            
            // When this Calculate method is called, the t, x, y, and z values
            // will be pushed onto its frame on the stack.
            // They are defined in the context of this method.
            // When the method finishes,
            // the memory area that was allocated for the stack can later be used by other methods.

            // Moreover, if a parameter or variable of a method represents a value type,
            // then the immediate value of this parameter or variable will be stored in the stack.
            
            // For example, in this case,
            // the variables and parameter of the Calculate method represent a significant type
            // - the int type, so their numeric values will be stored on the stack.
            
            // Reference types are stored on a heap or heap,
            // which can be thought of as an unordered collection of dissimilar objects.
            // Physically, this is the rest of the memory that is available to the process.

            // When an object of a reference type is created,
            // a reference to an address in the heap (heap) is placed on the stack.
            // When an object of a reference type is no longer used,
            // an automatic garbage collector comes into play:
            // it sees that there are no more references to an object in the heap,
            // conditionally deletes this object and cleans up memory
            // - in fact, it marks that this memory segment can be used to store other data.

            // So, in particular, if we change the Calculate method as follows:
            
            /*
             * static void Calculate(int t)
             * {
             *  object x = 6;
             *  int y = 7;
             *  int z = y + t;
             * }
             */
            
            // !!!Now the value of the variable x will be stored on the heap,!!!
            // since it represents the reference type object, and the stack will store a reference
            // to the object on the heap.
            
            
            //
            
            
            // !!!Composite types!!!
            
            //Now let's consider a situation where a value type
            //and a reference type represent composite types - structure and class:
            
            State state1 = new State ();       // State is a structure, its data is placed on the stack
            Country country1 = new Country (); // Country - class, a link to the address in the heap is placed on the stack
                                               // and the heap contains all the data of the country1 object
                                               
                                               
          // Here, in the Main method,
          // memory is allocated on the stack for the state1 object.
          // Further in the stack, a link is created for the object country1 (Country country1),
          // and by calling the constructor with the new keyword, a place in the heap is allocated (new Country ()).
          // The reference on the stack for the country1 object will represent
          // the address to the location in the heap where this object is located.
          
          // Thus, the stack will contain all the fields
          // of the state1 structure and a reference to the country1 object in the heap.

          // However, the State structure also defines a variable of the reference type Country.
          // Where will it store its value if it is defined in a value type?
          
          /*
           * private static void Main(string[] args)
           * {
           *   State state1 = new State();
           *   state1.country = new Country();
           *   Country country1 = new Country();
           * }
           */
          
          // The value of the state1.country variable will also be stored on the heap,
          // since this variable represents a reference type:
          
          
          //
          
          // !!!Copying values!!!
          
          // The data type must be considered when copying values.
          // When you assign data to an object of a value type, it receives a copy of the data.
          // When assigning data to an object of a reference type,
          // it does not receive a copy of the object, but a link to this object in a heap. For example:
          
          State state2 = new State(); // Structure State
          State state3 = new State();
          state3.x = 1;
          state3.y = 2;
          state2 = state3;
          state3.x = 5; // state3. x=1 still
          Console.WriteLine(state2.x); // 1
          Console.WriteLine(state3.x); // 5
          Console.WriteLine('\n');
 
          Country country2 = new Country(); // Class Country
          Country country3 = new Country();
          country3.x = 1;
          country3.y = 4;
          country2 = country3;
          country3.x = 7; // now country2.x = 7 as both links are country2 and country3
          // point to one object in a heap
          Console.WriteLine(country2.x); // 7
          Console.WriteLine(country3.x); // 7
          Console.WriteLine('\n');
          
          // Since state1 is a structure, when you assign state1 = state2,
          // it gets a copy of the state2 structure.
          // And an object of class country1 when assigning country1 = country2;
          // gets a reference to the same object pointed to by country2.
          // Therefore, when country2 changes, country1 will also change.
          
          
          //
          
          
          // !!!Reference types within value types!!!
          
          // Now let's look at a more sophisticated example,
          // when inside a structure we can have a variable of a reference type, for example, of some class:
          
          State state4 = new State(); 
          State state5 = new State();
         
          state5.country = new Country();
          state5.country.x = 5;
          state4 = state5;
          state5.country.x = 8; // now also state4.country.x = 8, as state4.country and state5.country
          // point to one object in a heap
          Console.WriteLine(state4.country.x); // 8
          Console.WriteLine(state5.country.x); // 8
          Console.WriteLine('\n');
          
          
          //
          
          
          // !!!Class Objects as Method Parameters!!!
          
          // The organization of objects in memory should be considered when passing parameters by value and by reference.
          // If method parameters represent class objects, then the use of parameters has some peculiarities.
          // For example, let's create a method that takes a Person object as a parameter:
          
          Person p = new Person { Name = "Tom", Age =23 };
          ChangePerson(p);  
 
          Console.WriteLine(p.Name); // Alice
          Console.WriteLine(p.Age); // 23
          Console.WriteLine('\n');
          
          // When passing a class object by value, a copy of the object reference is passed to the method.
          // This copy points to the same object as the original link,
          // so we can change individual fields and properties of the object,
          // but we cannot change the object itself.
          // Therefore, in the example above, only the line person.name = "Alice" will work.

          // And another line person = new Person {name = "Bill", age = 45} will create a new object in memory,
          // and person will now point to a new object in memory.
          // Even if we change it after that, it will not affect the p reference in the Main method in any way,
          // since the p reference still points to the old object in memory.
          
          // But when passing a parameter by reference (using the ref keyword),
          // the object reference in memory is passed to the method as an argument.
          // Therefore, you can change both the fields and properties of the object and the object itself:
          
          Person p2 = new Person { Name = "Tom", Age=23 };
          ChangePerson(ref p2);  
 
          Console.WriteLine(p2.Name); // Bill
          Console.WriteLine(p2.Age); // 45
          Console.WriteLine('\n');
          
          // The new operation will create a new object in memory,
          // and now the person reference (aka p from the Main method) will point to the new object in memory.
        }
        
        static void Calculate(int t)
        {
            int x = 6;
            int y = 7;
            int z = y + t;
        }
        
        struct State
        {
            public int x;
            public int y;
            public Country country;
        }
        class Country
        {
            public int x;
            public int y;
        }
        
        class Person
        {
            public string Name;
            public int Age;
        }
        
        static void ChangePerson(Person person)
        {
            // will work
            person.Name = "Alice";
            // will work only within this method
            person = new Person { Name = "Bill", Age = 45 };
            Console.WriteLine(person.Name); // Bill
        }
        
        static void ChangePerson(ref Person person)
        {
            // will work
            person.Name = "Alice";
            // will work
            person = new Person { Name = "Bill", Age = 45 };
        }
    }
}