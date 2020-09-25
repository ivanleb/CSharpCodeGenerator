using CSharpCodeGenerator.Builders;
using CSharpCodeGenerator.Elements;
using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var cls = ClassBuilder.AddClass("MyClass")
                .AddField(
                    FieldBuilder.AddField("myfield")
                                .Type("string")
                                .Access(AccessModifier.Public)
                         )
                .AddConstructor(
                    ConstructorBuilder.AddConstructor()
                                      .Parameter("string", "myfield")
                    )
                .Build().ToString();
        }
    }
}
