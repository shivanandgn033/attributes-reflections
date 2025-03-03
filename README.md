### C# Attributes and Reflection in Detail
C# attributes provide a powerful way to add metadata to your code. This metadata can be used by the compiler, runtime, or your own custom tools to perform various tasks. Reflection, on the other hand, allows you to inspect and manipulate types, methods, fields, and other code elements at runtime. Together, attributes and reflection enable you to create highly flexible and extensible applications.

#### Attributes:

Definition: Attributes are classes that inherit from System.Attribute. They act as markers that attach metadata to code elements like classes, methods, properties, etc.
Usage: You apply an attribute by placing it within square brackets [] before the code element.
Built-in Attributes: C# provides many built-in attributes, such as Obsolete, Conditional, Serializable, and DllImport.
Custom Attributes: You can create your own custom attributes to add specific metadata relevant to your application.

#### Reflection:

Definition: Reflection is the process of examining and manipulating the metadata of types, methods, fields, and other code elements at runtime.
Key Classes: The System.Reflection namespace provides classes like Type, MethodInfo, FieldInfo, and PropertyInfo for accessing and manipulating metadata.
Usage: Reflection allows you to dynamically discover and invoke methods, create instances of types, and access field and property values.
Example: Custom Attribute and Reflection

Let's create a simple example where we define a custom attribute AuthorAttribute to store information about the author of a class. We'll then use reflection to read and display this information at runtime.

#### 1. Define the Custom Attribute:

C#
```C#
using System;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)] // Allow multiple Author attributes
public class AuthorAttribute : Attribute
{
    public string Name { get; }
    public string Version { get; set; } //Optional version

    public AuthorAttribute(string name)
    {
        Name = name;
    }
}
```
[AttributeUsage(...)]: This attribute specifies where our custom attribute can be applied. In this case, it can be applied to classes and methods. AllowMultiple = true allows us to apply the attribute multiple times to the same element.

#### 2. Apply the Attribute to a Class:

C#

```C#
[Author("John Doe", Version = "1.0")]
[Author("Jane Smith")]
public class MyClass
{
    public void MyMethod()
    {
        Console.WriteLine("MyMethod executed.");
    }
}
```
We apply the AuthorAttribute to MyClass, providing the author's name and an optional version. We also use the Author attribute a second time to show multiple authors.

#### 3. Use Reflection to Read the Attribute:

C#

```C#
using System;
using System.Reflection;

public class Program
{
    public static void Main(string[] args)
    {
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
    }
}
```

1 We use typeof(MyClass) to get the Type object representing MyClass.

2 myType.GetCustomAttributes(typeof(AuthorAttribute), true) retrieves all AuthorAttribute instances applied to MyClass. The true parameter specifies that inherited attributes should also be included (if any).

3 We iterate through the retrieved attributes and display the author's name and version.

4 The code also demonstrates getting attributes from a method.

5 The MethodInfo class is used to get information about methods.

#### Output:

Author: John Doe
Version: 1.0
Author: Jane Smith


#### Key Takeaways:

1 Attributes provide a way to add metadata to your code.

2 Reflection allows you to access and manipulate this metadata at runtime.

3 Custom attributes can be used to add application-specific metadata.

4 Reflection is powerful but can impact performance, so use it judiciously.


This example demonstrates the basic principles of using attributes and reflection in C#. You can extend this concept to create more complex and powerful applications.
