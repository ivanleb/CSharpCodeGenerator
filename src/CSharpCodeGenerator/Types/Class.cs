using CSharpCodeGenerator.Builders;
using CSharpCodeGenerator.Elements;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpCodeGenerator.Types
{
    public class Class 
    {
        public Class(string name)
        {
            Name = name;
        }

        public AccessModifier AccessModifier { get; } = AccessModifier.Public;
        public bool IsStatic { get; }
        public string Name { get; }
        public string AncestorType { get; } = "";
        public HashSet<Interface> ImplementedInterfaces { get; } = new HashSet<Interface>();
        public HashSet<Field> Fields { get; } = new HashSet<Field>();
        public HashSet<Method> Methods { get; } = new HashSet<Method>();
        public HashSet<Property> Properties { get; } = new HashSet<Property>();
        public HashSet<Constructor> Constructors { get; } = new HashSet<Constructor>();

        public override string ToString()
        {
            string isStatic = IsStatic ? "static" : "";
            string inheritence = new string[] { AncestorType }.Concat(ImplementedInterfaces.Select(i => i.Name)).Aggregate((acc, arg) => acc + ", " + arg);
            inheritence = inheritence.Any() ? ": " + inheritence : inheritence;

            StringBuilder fieldSb = new StringBuilder().AppendJoin('\n', Fields.Select(f => f.ToString()).ToArray());

            StringBuilder constructorSb = new StringBuilder().AppendJoin('\n', Constructors.Select(f => f.ToString()).ToArray());

            StringBuilder propertiesSb = new StringBuilder().AppendJoin('\n', Properties.Select(f => f.ToString()).ToArray());

            StringBuilder methodsSb = new StringBuilder().AppendJoin('\n', Methods.Select(f => f.ToString()).ToArray());

            return $@"
        {AccessModifier} {isStatic} class {Name} {inheritence}
        {{
{fieldSb}
            {constructorSb}
            {propertiesSb}
            {methodsSb}
        }}
        ";
        }

        public static ClassBuilder Add(string name) => ClassBuilder.AddClass(name);
    }
}
