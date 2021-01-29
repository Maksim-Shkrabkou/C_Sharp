using System;

namespace Properties
{
    class Program
    {
        static void Main(string[] args)
        {
            
            // 1!
            var p = new Person();
 
            // Set the property - the Set block is triggered
            // the value "Tom" is passed to the value property
            p.Name = "Tom";
    
            // Get the property value and assign it to a variable - the Get block is triggered
            var personName = p.Name; 
            
            // 2!
            
            var p5 = new Person5("Tom");
 
            // Error - set is declared with the private modifier
            // p5.Name = "John";
 
            Console.WriteLine(p5.Name);
            Console.WriteLine('\n');
            
            // 3!
            
            var person = new Person7();
            Console.WriteLine(person.Name); // Tom
            Console.WriteLine(person.Age);  // 23

        } 

        // In addition to regular methods, C # provides special accessor methods called properties.
        // They provide easy access to the fields of classes and structures, find out their meaning or set them.

        // The standard property description has the following syntax:
        
        // [access_modifier] return_type arbitrary_name
        // {
            // property code
        // }
        
        // For example:
        
        class Person
        {
            private string _name;
 
            public string Name
            {
                get
                {
                    return _name;
                }
 
                set
                {
                    _name = value;
                }
            }
        }
        
        // Here we have a private name field and a public property Name.
        // Although they have almost the same name except for the case,
        // but this is nothing more than a style, their names can be arbitrary and do not have to be the same.

        // Through this property, we can control access to the name variable.
        // The standard property definition contains get and set blocks.
        // In the get block we return the value of the field,
        // and in the set block we set. The value parameter represents the value to pass.

        // We can use this property as follows:
        
        // 1!
        
        // Perhaps the question may arise, why do we need properties,
        // if in this situation we can get by with ordinary class fields?
        //
        // But properties allow you to nest additional logic that may be necessary
        // , for example, when assigning a value to a class variable.
        //
        // For example, we need to set a check by age:
        
        class Person2
        {
            private int _age;
 
            public int Age
            {
                set
                {
                    if (value < 18)
                    {
                        Console.WriteLine("Возраст должен быть больше 17");
                    }
                    else
                    {
                        _age = value;
                    }
                }
                
                get { return _age; }
            }
        }
        
        
        // If the variable age were public, then we could pass it from outside any value, including negative.
        // The property allows you to hide these objects and mediate access to them.

        // The set and get blocks do not have to be present in the property at the same time.
        // If a property is defined only by a get block, then such a property is read-only - we can get its value,
        // but not set it. Conversely, if a property only has a set block,
        // then that property is write-only - you can only set a value, but cannot get:
        
        class Person3
        {
            private string _name;
            
            // read-only property
            public string Name
            {
                get
                {
                    return _name;
                }
            }
 
            private int age;
            
            // write-only property
            public int Age
            {
                set
                {
                    age = value;
                }
            }
        }
        
        // Although in the examples above, properties were defined in a class,
        // but in the same way we can define and use properties in structures.
        
        
        //
        
        
        // !!!Access modifiers!!!
        
        // We can apply access modifiers not only to the entire property,
        // but also to individual blocks - either get or set:
        
        class Person5
        {
            private string _name;
 
            public string Name
            {
                get
                {
                    return _name;
                }
 
                private set
                {
                    _name = value;
                }
            }
            
            public Person5(string name)
            {
                Name = name;
            }
        }
        
        // Now we can use the private set block only in this class
        // - in its methods, properties, constructor, but not in another class:
        
        // 2!

        
        // When using modifiers in properties, you should take into account a number of restrictions:

        // A modifier for a set or get block can be set if the property has both blocks (set and get)

        // Only one set or get block can have an access modifier, but not both.

        // The access modifier of a set or get block must be more restrictive than the access modifier of a property.
        // For example, if a property has a public modifier,
        // then a set / get block can only have the modifiers protected internal, internal, protected, private.
        
        
        //
        
        // !!!Automatic properties!!!
        // Properties control access to the fields of the class.
        // However, what if we have a dozen or more fields,
        // then it would be tedious to define each field and write a property of the same type for it.
        // Therefore, automatic properties have been added to the .NET framework. They have an abbreviated declaration:
        
        class Person6
        {
            public string Name { get; set; }
            public int Age { get; set; }
         
            public Person6(string name, int age)
            {
                Name = name;
                Age = age;
            }
        }
        
        // In fact, fields for properties are also created here,
        // only they are not created by the programmer in the code,
        // but the compiler automatically generates them during compilation.

        // What is the advantage of autoproperties,
        // if in essence they just refer to an automatically created variable,
        // why not directly access a variable without autoproperties? The fact is that at any moment in time,
        // if necessary, we can expand the auto-property into a regular property, add some specific logic to it.

        // Keep in mind that you cannot create an automatic write-only property, as is the case with standard properties.

        // Autoproperties can be assigned default values (initializing autoproperties):
        
        class Person7
        {
            public string Name { get; set; } = "Tom";
            public int Age { get; set; } = 23;
        }
        
        // 3!
        
        // And if we do not specify the values of the Name and Age properties for the Person object,
        // then the default values will apply.

        // It is worth noting that we cannot use auto-property initialization in structures.

        // Autoproperties can also have access modifiers:
        
        class Person8
        {
            public string Name { private set; get;}
            
            public Person8(string n)
            {
                Name = n;
            }
        }
        
        // We can remove the set block and make the auto property read-only.
        // In this case, to store the value of this property,
        // a field with the readonly modifier will be implicitly created for it,
        // so it should be borne in mind that such get-properties can be set either from the class constructor,
        // as in the example above, or when initializing the property:
        
        class Person9
        {
            public string Name { get; } = "Tom";
        }
        
        
        //
        
        
        // !!!Abbreviated notation of properties!!!
        // Just like methods, we can shorten properties. For example:
        
        class Person10
        {
            private string _name;
     
            // equivalent to public string Name { get { return _name; } }
            public string Name => _name;
        }
    }
}
