using System;

namespace Indexers
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1!
            var people = new People();
            people[0] = new Person { Name = "Tom" };
            people[1] = new Person { Name = "Bob" };
 
            var tom = people[0];
            Console.WriteLine(tom?.Name);
            Console.WriteLine('\n');
            
            // 2!
            var tom2 = new User();
            tom2["name"] = "Tom";
            tom2["email"] = "tomekvilmovskiy@gmail.ru";
 
            Console.WriteLine(tom2["name"]); // Mr/Ms. Tom
            Console.WriteLine(tom2["email"]); // tomekvilmovskiy@gmail.ru
            Console.WriteLine('\n');
            
            // 3!
            var matrix = new Matrix();
            Console.WriteLine(matrix[0, 0]);
            matrix[0, 0] = 111;
            Console.WriteLine(matrix[0, 0]);
            Console.WriteLine('\n');
            
            // 4!
            var people2 = new People2();
            people2[0] = new Person { Name = "Tom" };
            people2[1] = new Person { Name = "Bob" };
             
            Console.WriteLine(people2[0].Name);      // Tom
            Console.WriteLine(people2["Bob"].Name);  // Bob
        }
        
        // Indexers index objects and access data by index. In fact, using indexers, we can work with objects as arrays.
        // By default, they resemble properties with building blocks that return and set, that return and assign a value.
        
        // Formal definition of an indexer:
        
        /*return_type this [Type parameter1, ...]
        {
            get {...}
            set {...}
        }*/
        
        // Unlike properties, the indexer has no name. Instead, the keyword this is specified,
        // followed by parameters in square brackets. The indexer must have at least one parameter.

        // Let's see an example.
        // Let's say we have a Person class that represents a person and a People class that represents a group of people.
        // Using indexers to define the People class:
        
        class Person
        {
            public string Name { get; set; }
        }

        class People
        {
            Person[] data;

            public People()
            {
                data = new Person[5];
            }

            // indexer
            public Person this[int index]
            {
                get { return data[index]; }
                set { data[index] = value; }
            }
        } 
        
        // The public Person construct is this [int index] and represents the indexer.Here we define, first, the type
        // of the returned or assignable object, that is, the type Person.Secondly, we define the way to access the
        // elements through the int index parameter.

        // Basically, all Person objects are stored in the class in the data array.
        // To get them by index, the get block is defined in the indexer:
        
        /*get
        {
            return data[index];
        }*/
        
        // The indexer has the type of a person,
        // then in the get block we need to return an object of this type using the return statement.
        // Here we can define a variety of logic. In this case, we simply return an object from the data array.

        // In the set block, we get the value of the passed Person object through the parameter
        // and save it to the array by index.
        
        /*set
        {
            data[index] = value;
        }*/
        
        // Then we can work with the People object as a collection of Person objects:
        
        // 1!
        
        // The indexer, as expected, receives a set of indexes as parameters.
        // However, indices do not have to be int.
        // For example, we can think of an object
        // as a property store and pass the name of the object's attribute as a string:
        
        class User
        {
            string _name;
            string _email;
            string _phone;
 
            public string this[string propname]
            {
                get
                {
                    return propname switch
                    {
                        "name" => "Mr/Ms. " + _name,
                        "email" => _email,
                        "phone" => _phone,
                        _ => null
                    };
                }
                set
                {
                    switch (propname)
                    {
                        case "name":
                            _name = value;
                            break;
                        case "email":
                            _email = value;
                            break;
                        case "phone":
                            _phone = value;
                            break;
                    }
                }
            }
        }
        
        // 2!
        
        
        //
        
        
        // !!!Applying multiple parameters!!!
        
        // Also, the indexer can take several parameters.
        // Let's say we have a class that is defined as a two-dimensional array or matrix:
        
        class Matrix
        {
            private readonly int[,] _numbers = { { 1, 2, 4}, { 2, 3, 6 }, { 3, 4, 8 } };
            
            public int this[int i, int j]
            {
                get => _numbers[i,j];
                set => _numbers[i, j] = value;
            }
        }
        
        // Now two indices are used to define the indexer - i and j. And in the program,
        // we must already refer to the object using two indices:
        
        // 3!
        
        // Note that the indexer cannot be static and only applies to an instance of the class.
        // But at the same time, indexers can be virtual and abstract and can be redefined in derived classes.
        
        
        //
        
        
        // !!!Get and set blocks!!!
        
        // As with properties, you can omit the get or set block in indexers if they are not needed.
        // For example, let's remove the set block and make the indexer read-only:
        
        class Matrix2
        {
            private readonly int[,] _numbers = { { 1, 2, 4}, { 2, 3, 6 }, { 3, 4, 8 } };
            
            public int this[int i, int j]
            {
                get
                {
                    return _numbers[i,j];
                }
            }
        }
        
        // We can also restrict access to get and set blocks using access modifiers.
        // For example, let's make the set block private:
        
        class Matrix3
        {
            private readonly int[,] _numbers = { { 1, 2, 4}, { 2, 3, 6 }, { 3, 4, 8 } };
            
            public int this[int i, int j]
            {
                get => _numbers[i,j];
                private set => _numbers[i, j] = value;
            }
        }
        
        
        //
        
        
        // Overloading indexers
        
        // Indexers can be overloaded like methods.
        // In this case, indexers should also differ in the number, type, or order of the parameters used. For example:
        
        class Person2
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
        
        class People2
        {
            Person[] data;
            
            public People2()
            {
                data = new Person[5];
            }
            
            public Person this[int index]
            {
                get
                {
                    return data[index];
                }
                set
                {
                    data[index] = value;
                }
            }
            
            public Person this[string name]
            {
                get
                {
                    Person person = null;
                    
                    foreach(var p in data)
                    {
                        if(p?.Name == name)
                        {
                            person = p;
                            break;
                        }
                    }
                    
                    return person;
                }
            }
        }
        
        // 4!
        
        // In this case, the People class contains two versions of the indexer.
        // The first version gets and sets a Person object by index,
        // while the second only gets a Person object by its name.
    }
}