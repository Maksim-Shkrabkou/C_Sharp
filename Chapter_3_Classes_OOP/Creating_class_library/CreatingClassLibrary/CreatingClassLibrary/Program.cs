using System;
using MyLib; // include namespace from class library

namespace CreatingClassLibrary
{
    // Often, various classes and structures are designed as separate libraries,
    // which are compiled into dll files and then can be included in other projects.
    // Thanks to this, we can define the same functionality in the form of a class library
    // and connect it to different projects or transfer it to other developers for use.

    // Let's create and include a class library.

    // Take an existing .NET Core Console Application project such as the one created in the previous topics.
    // In the project structure, right-click on the name of the solution and then,
    // in the context menu that appears, select Add -> New Project ... (Add a new project):
    
    // Next, in the list of project templates, we will find the Class Library (.NET Core) item:
    
    // Then we give the new project some name -> MyLib:
    
    // After that, a new project will be added to the solution, in my case with the name MyLib:
    
    // By default, a new project has one empty class, Class1, in the Class1.cs file.
    // We can delete or rename this file as we like.

    // For example, rename the Class1.cs file to Person.cs and the class Class1 to Person.
    // Let's define the simplest code in the Person class:
    
    // Now let's compile the class library.
    // To do this, right-click on the class library project and select Rebuild from the context menu:
    
    // After compiling the class library in the project folder under the bin/Debug/net5.0 directory,
    // we can find the compiled dll file (MyLib.dll). Let's connect it to the main project.
    
    // To do this, in the main project, right-click on the Dependencies node and select Add Reference from the context menu:
    
    // Next, a window will open for us to add libraries. In this window, select the Solution item,
    // which allows you to see all the class libraries from the projects of the current solution,
    // check the box next to our library and click on the OK button:
    
    
    // If our library suddenly presents a dll file that is not associated with any project in our solution,
    // then using the Browse button we can find the location of the dll file and also connect it.

    // After successfully connecting the library in the main project,
    // let's change the Program class so that it uses the Person class from the class library:

    class Program
    {
        static void Main(string[] args)
        {
            Person tom = new Person { Name = "Tom", Age = 35 };
            Console.WriteLine(tom.Name);
        }
    }
}