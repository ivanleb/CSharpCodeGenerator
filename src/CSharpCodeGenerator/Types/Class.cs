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
        public Class AncestorType { get; } 
        public HashSet<Interface> ImplementedInterfaces { get; } = new HashSet<Interface>();
        public HashSet<Field> Fields { get; } = new HashSet<Field>();
        public HashSet<Method> Methods { get; } = new HashSet<Method>();
        public HashSet<Property> Properties { get; } = new HashSet<Property>();
        public HashSet<Constructor> Constructors { get; } = new HashSet<Constructor>();

        public override string ToString()
        {
            string isStatic = IsStatic ? "static" : "";
            StringBuilder sb = new StringBuilder();
            sb.AppendJoin(',', AncestorType?.Name, ImplementedInterfaces.Select(i => i.Name).ToArray());
            string inheritence = sb.Length != 0 ? ": " + sb.ToString().Remove(0,1) : "";

            StringBuilder fieldSb = new StringBuilder();
            fieldSb.AppendJoin('\n', Fields.Select(f => f.ToString()).ToArray());

            StringBuilder constructorSb = new StringBuilder();
            constructorSb.AppendJoin('\n', Constructors.Select(f => f.ToString()).ToArray());

            StringBuilder propertiesSb = new StringBuilder();
            propertiesSb.AppendJoin('\n', Properties.Select(f => f.ToString()).ToArray());

            StringBuilder methodsSb = new StringBuilder();
            methodsSb.AppendJoin('\n', Methods.Select(f => f.ToString()).ToArray());

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
    }
}
