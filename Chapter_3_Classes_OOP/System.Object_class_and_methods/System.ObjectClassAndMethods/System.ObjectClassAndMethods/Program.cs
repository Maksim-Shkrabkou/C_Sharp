using System;

namespace System.ObjectClassAndMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1!
            int i = 5;
            Console.WriteLine (i.ToString ()); // will print the number 5
 
            double d = 3.5;
            Console.WriteLine (d.ToString ()); // will print the number 3.5
            Console.WriteLine ('\n');
            
            // 2!
            Person person = new Person { Name = "Tom" };
            Console.WriteLine(person.ToString()); // will print the name of the Person class
 
            Clock clock = new Clock { Hours = 15, Minutes = 34, Seconds = 53 };
            Console.WriteLine(clock.ToString()); // will output 15:34:53
            Console.WriteLine ('\n');
            
            // 3!
            Person2 person2 = new Person2 { Name = "Tom" };
            Console.WriteLine(person2);
 
            Clock clock3 = new Clock { Hours = 15, Minutes = 34, Seconds = 53 };
            Console.WriteLine(clock); // output 15:34:53
            Console.WriteLine ('\n');
            
            // 4!
            var person3 = new Person3("Tom");
            Console.WriteLine(person3.GetHashCode());
            Console.WriteLine ('\n');

            // 5!
            Person person4 = new Person { Name = "Tom" };
            Console.WriteLine(person4.GetType()); // Person
            Console.WriteLine ('\n');
            
            // 6!
            object person5 = new Person {Name = "Tom"};
            if (person5.GetType () == typeof (Person)) 
                Console.WriteLine ("This is really a Person class");
            Console.WriteLine(typeof (Person));
            Console.WriteLine ('\n');
            
            // 7!
            Person4 person6 = new Person4 { Name = "Tom" };
            Person4 person7 = new Person4 { Name = "Bob" };
            Person4 person8 = new Person4 { Name = "Tom" };
            bool p1Ep2 = person6.Equals(person7);   // false
            bool p1Ep3 = person6.Equals(person8);   // true
            Console.WriteLine(p1Ep2);
            Console.WriteLine(p1Ep3);
        }
        
        // All other classes in .NET, even those we create ourselves, as well as base types such as System.Int32,
        // are implicitly derived from the Object class. Even if we do not specify the Object class as the base class,
        // by default, the Object class is implicitly at the top of the inheritance hierarchy. Therefore, all types
        // and classes can implement the methods that are defined in the System.Object class. Let's consider these methods.

        // !!!ToString!!!
        
        // The ToString method is used to get the string representation of this object.
        // For basic types, their string value will simply be displayed:
        
        // 1!
        
        // For classes, this method displays the full name of the class with an indication
        // of the namespace in which this class is defined. And we can override this method. Let's see an example:
        
        class Clock
        {
            public int Hours { get; set; }
            public int Minutes { get; set; }
            public int Seconds { get; set; }
            
            public override string ToString()
            {
                return $"{Hours}:{Minutes}:{Seconds}";
            }
        }
        
        class Person
        {
            public string Name { get; set; }
        }
        
        // 2!
        
        
        // The override keyword is used to override the ToString method in the Clock class,
        // which represents a clock (as with the usual overriding of virtual or abstract methods).
        // In this case, the ToString () method is the value of the Hours, Minutes, Seconds properties, combined into one string.

        // The Person class does not override the ToString method,
        // so the standard implementation of this method works for this class, which simply displays the name of the class.

        // By the way, in this case, we could use both implementations:
        
        class Person2
        {
            public string Name { get; set; }
            
            public override string ToString()
            {
                if (String.IsNullOrEmpty(Name))
                    return base.ToString();
                
                return Name;
            }
        }
        
        // That is, if the name - the Name property has no value, it represents an empty string,
        // then the base implementation is returned - the name of the class.
        // If the name is set, then the value of the Name property is returned.
        // The String.IsNullOrEmpty () method is used to test a string for emptiness.

        // It is worth noting that various technologies on the .NET platform actively
        // use the ToString method for different purposes. In particular, the same Console.WriteLine () method
        // by default outputs exactly the string representation of the object.
        // Therefore, if we need to display the string representation of an object to the console,
        // then when passing the object to the Console.WriteLine method,
        // it is not necessary to use the ToString () method - it is called implicitly:

        
        // 3!
        
        
        //
        
        
        // !!!GetHashCode method!!!
        
        // The GetHashCode method allows you to return some numeric value that will correspond to the given object
        // or its hash code. By this number, for example, you can compare objects.
        // You can define a variety of algorithms for generating such a number, or take an implementation of the base type:
        
        class Person3
        {
            public string Name { get; set; }

            public Person3(string name)
            {
                Name = name;
            }

            public override int GetHashCode()
            {
                return Name.GetHashCode();
            }
        }
        
        
        // 4!
        
        // In this case, the GetHashCode method returns a hash code for the value of the Name property
        // . That is, two Person objects that have the same name will return the same hash code.
        // However, in reality, the algorithm can be very different.
        
        
        //
        
        
        // Getting the object type and the GetType method
        
        // The GetType method allows you to get the type of this object:
        
        // 5!
        
        //This method returns a Type object, that is, the type of the object.

        //With the typeof keyword we get the type of the class and compare it with the type of the object.
        //And if this object represents the Client type, then we perform certain actions.
        
        // 6!
        
        // Moreover, since the Object class is the base type for all classes,
        // we can assign an object of any type to a variable of the object type.
        // However, for this variable, the GetType method will still return the type that the variable refers to.
        // That is, in this case, an object of type Person.

        // Unlike the ToString, Equals, GetHashCode methods, the GetType method is not overridden.
        
        
        //
        
        
        
        // !!!Equals method!!!
        
        // The Equals method allows you to compare two objects for equality:
        
        class Person4
        {
            public string Name { get; set; }
            
            public override bool Equals(object obj)
            {
                if (obj.GetType() != this.GetType()) return false;
                
                Person4 person = (Person4)obj;
                
                return (this.Name == person.Name);
            }
        }
        
        // The Equals method takes an object of any type as a parameter,
        // which we then cast to the current one if they are objects of the same class.
        // Then we compare by name. If the names are equal, we return true, which will say that the objects are equal.
        // However, if necessary, the implementation of the method can be made more complex,
        // for example, it can be compared by several properties, if any.

        // Application of the method:
        
        // 7!
        
        // And if you need to compare two complex objects, as in this case,
        // then it is better to use the Equals method rather than the standard == operation.
    }
}