using System;

namespace GenericTypeInheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1!
            Account<string> acc1 = new Account<string>("34");
            Account<int> acc3 = new UniversalAccount<int>(45);
            UniversalAccount<int> acc2 = new UniversalAccount<int>(33);
            Console.WriteLine(acc1.Id);
            Console.WriteLine(acc2.Id);
            Console.WriteLine(acc3.Id);
            Console.WriteLine('\n');
            
            // 2!
            StringAccount acc4 = new StringAccount("438767");
            Account<string> acc5 = new StringAccount("43875");
            // you can't write like that
            // Account <int> acc6 = new StringAccount ("45545");
            
            // 3!
            IntAccount<string> acc7 = new IntAccount<string>(5) { Code = "r4556" };
            Account<int> acc8 = new IntAccount<long>(7) { Code = 4587 };
            Console.WriteLine(acc7.Id);
            Console.WriteLine(acc8.Id);
            Console.WriteLine('\n');
            
            // 4!
            MixedAccount<string, int> acc9 = new MixedAccount<string, int>("456") { Code = 356 };
            Account<string> acc10 = new MixedAccount<string, int>("9867") { Code = 35678 };
            Console.WriteLine(acc9.Id);
            Console.WriteLine(acc10.Id);
            Console.WriteLine('\n');
        }
        
        // One generic class can be inherited from another generic.
        // In this case, you can use various options for inheritance.

        // Let's say we have the following base class Account:
        
        class Account<T>
        {
            public T Id { get; private set; }
            
            public Account(T _id)
            {
                Id = _id;
            }
        }
        
        // The first option is to create a derived class that is typed with the same type as the base one:
        
        class UniversalAccount<T> : Account<T>
        {
            public UniversalAccount(T id) : base(id)
            {
             
            }
        }
        
        // Class application:
        
        // 1!
        
        
        //
        
     
        // The second option is to create a regular non-generic inheritor class.
        // In this case, when inheriting from the base class, you must explicitly define the type to be used:
            
        class StringAccount: Account<string>
        {
            public StringAccount (string id): base (id)
            {
            }
        }
        
        // The derived class now uses string as its type. Class application:
        
        // 2!
        
        
        //
        
        
        // The third option represents typing the derived class with a parameter of
        // a completely different type than the generic parameter in the base class.
        // In this case, the type used for the base class must also be specified:
            
        class IntAccount <T>: Account <int>
        {
            public T Code {get; set; }
            
            public IntAccount (int id): base (id)
            {
            }
        }
     
        // Here, the IntAccount type is typed by another type, which may not be the same as the type used by the base class.
        // Class application:
        
        // 3!
        
        
        //
        
        
        // And also in inherited classes, you can combine the use of a generic parameter from the base class with the use of your parameters:
            
        class MixedAccount <T, K>: Account <T>
            where K: struct
        {
            public K Code {get; set; }
            
            public MixedAccount (T id): base (id)
            {
 
            }
        }
        
        // Here, in addition to the parameter T inherited from the base class, a new parameter K is added.
        // Also, if it is necessary to set restrictions, we can specify them after the name of the base class.
        // Class application:
        
        // 4!
        
        
        //
        
        
        // It should be borne in mind that if a restriction is set for a generic parameter at the base class level,
        // then a similar restriction must also be defined in derived classes that also use this parameter:
        
        class Account2<T> where T: class
        {
            public T Id {get; private set; }
            
            public Account2 (T id)
            {
                Id = id;
            }
        }
        
        class UniversalAccount2<T>: Account2<T>
            where T: class
        {
            public UniversalAccount2 (T id): base (id)
            {
             
            }
        }
        
        // That is, if class is specified as a constraint in the base class, that is, any class,
        // then in the derived class it is also necessary to specify class as a constraint, or some specific class.
    }
}