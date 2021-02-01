using System;

namespace NullValue
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1!
            object x = null;
            object y = x ?? 100; // equals 100 since x is null
            Console.WriteLine(y);

            object z = 200;
            object t = z ?? 44; // equals 200 since z is not null
            Console.WriteLine(t);
            Console.WriteLine('\n');
            
            // 2!
            var user = new User();

            string companyName = user?.Phone?.Company?.Name; // null
            
            // 3!
            var user2 = new User();
            string companyName2 = user2?.Phone?.Company?.Name ?? "undefined";
            Console.WriteLine(companyName2);
        }

        // One of the differences between reference types
        // and value types is that variables of reference types can be null. For example:

        object o = null;
        string s = null;

        // If variables of reference type are not assigned a value, then they are given a default value of null.
        // In fact, it speaks of a lack of meaning as such.

        // But value types like int, decimal, double, etc. cannot be null.


        //


        // !!!Operator ?? !!!

        // Operator ?? called the null union operator.
        // It is used to set default values for types that are nullable.
        // Operator ?? returns the left-hand operand if that operand is not null.
        // Otherwise, the right-hand operand is returned.
        // In this case, the left operand must accept null. Let's see an example:

        // 1!

        // But we cannot write like this:

        /*
         * int x = 44;
         * int y = x ?? 100;
         */

        // Here variable x represents the value type int and cannot be null,
        // so as the left operand in the operation ?? it cannot be used.


        //


        // !!!Null-Conditional Operator!!!

        // Sometimes, when working with objects that accept null, we may encounter an error:
        // we are trying to access an object, and this object is null.
        // For example, suppose we have the following class system:

        class User
        {
            public Phone Phone { get; set; }
        }

        class Phone
        {
            public Company Company { get; set; }
        }

        class Company
        {
            public string Name { get; set; }
        }

        // The User object contains a link to the Phone object
        // , and the Phone object contains a link to the Company object,
        // so in theory we can get the company name from the User object, for example, like this:

        /*
         * User user = new User();
         * Console.WriteLine(user.Phone.Company.Name);
         */

        // In this case, the Phone property is not defined, it will default to null.
        // Therefore, we will face a NullReferenceException.
        // To avoid this error, we could use a conditional construct to check for null:


        /*User user = new User();
 
            if(user!=null)
        {
            if(user.Phone!=null)
            {
                if (user.Phone.Company != null)
                {
                    string companyName = user.Phone.Company.Name;
                    Console.WriteLine(companyName);
                }
            }
        }*/

        // It turns out a multi-storey structure, but in fact it can be shortened:
        
        /*if(user!=null && user.Phone!=null && user.Phone.Company!=null)
        {
            string companyName = user.Phone.Company.Name;
            Console.WriteLine(companyName);
        }*/
        
        
        // If user is not null, then the following expression user.Phone! = Null is checked, and so on.
        // The design is much simpler, but still quite large. And to simplify it,
        // in C # the Null-Conditional Operator:
        
        // 2!
        
        // Expression ?. and represents the conditional null operator.
        // It sequentially checks if the user object and the nested objects are null.
        // If, at some stage, one of the objects turns out to be null,
        // then companyName will have a default value, that is, null.

        // And in this case, we can go ahead and apply the operation ?? to set the default if no company name is set:
        // Expression?. and represents the conditional null operator.
        // It sequentially checks if the user object and the nested objects are null.
        // If, at some stage, one of the objects turns out to be null,
        // then companyName will have a default value, that is, null.

        // And in this case, we can go ahead and apply the operation ?? to set the default if no company name is set:
        
        // 3!
    }
}