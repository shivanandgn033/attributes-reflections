using System;
using System.Reflection;
using AttributesandReflections;

        Type myType = typeof(MyClass);

        // Get all Author attributes applied to MyClass
        object[] attributes = myType.GetCustomAttributes(typeof(AuthorAttribute), true);

        foreach (AuthorAttribute authorAttribute in attributes)
        {
            Console.WriteLine($"Author: {authorAttribute.Name}");
            if(authorAttribute.Version != null)
            {
                Console.WriteLine($"Version: {authorAttribute.Version}");
            }
        }

        //Example of getting attributes from a method.
        MethodInfo methodInfo = myType.GetMethod("MyMethod");
        object[] methodAttributes = methodInfo.GetCustomAttributes(typeof(AuthorAttribute), true);

        if (methodAttributes.Length > 0)
        {
            Console.WriteLine("\nMethod Attributes:");
            foreach (AuthorAttribute authorAttribute in methodAttributes)
            {
                Console.WriteLine($"Author: {authorAttribute.Name}");
                if (authorAttribute.Version != null)
                {
                    Console.WriteLine($"Version: {authorAttribute.Version}");
                }
            }
        }