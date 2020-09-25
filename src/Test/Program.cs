using CSharpCodeGenerator.Builders;
using CSharpCodeGenerator.Elements;
using CSharpCodeGenerator.Types;
using System;
using System.Diagnostics;
using System.IO;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var cls = Class.Add("MyClass")
                .AddFields(
                    Field.Add("myfield")
                         .Type("string")
                         .Access(AccessModifier.Public),
                    Field.Add("myfield2")
                         .Type("string")
                         .Access(AccessModifier.Public),
                    Field.Add("myfield3")
                         .Type("string")
                         .Access(AccessModifier.Public)
                )
                .AddConstructor(
                    Constructor.Add()
                               .Parameter("string", "myfield")
                )
                .AddMethod(
                    Method.Add("GetFields")
                          .ReturnedType("string")
                          .AddParameter("string", "request")
                          .Access(AccessModifier.Public)
                )
                .AddAncesor("");

            var nmsps = Namespace.Add("MyNamespace").Using("System").Class(cls).Build();

            Console.WriteLine(nmsps);

            string path = "code.cs";
            if (File.Exists(path))
                File.Delete(path);
            FileInfo fi = new FileInfo(path);
            using (var file = new StreamWriter(File.OpenWrite(path))) 
            {
                file.WriteLine(nmsps);
            }

            Process.Start(
                new ProcessStartInfo(
                @"C:\Windows\Microsoft.NET\Framework\v4.0.30319\csc.exe",
                $"-target:library {fi.FullName}"
                )
            );
        }
    }
}
