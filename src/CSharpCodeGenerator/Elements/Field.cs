using CSharpCodeGenerator.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpCodeGenerator.Elements
{
    public class Field : Member
    {
        public static Field CreateField(string name) 
            => new Field(AccessModifier.Private, "object", name, false);

        public override string ToString()
        {
            return $"{AccessModifier} {Type} {Name};";
        }

        public Field(AccessModifier accessModifier, string type, string name, bool isReadonly)
            :base(accessModifier, type, name)
        {
            IsReadonly = isReadonly;
        }

        public bool IsReadonly { get; }
    }
}
