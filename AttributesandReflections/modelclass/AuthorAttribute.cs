using System;
namespace AttributesandReflections;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)] // Allow multiple Author attributes
public class AuthorAttribute: Attribute
{
    public string Name { get; }
    public string Version { get; set; } //Optional version

    public AuthorAttribute(string name)
    {
        Name = name;
    }
}
