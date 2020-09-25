using CSharpCodeGenerator.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpCodeGenerator.Elements
{
    public abstract class Member
    {
        public Member(AccessModifier accessModifier, string type, string name)
        {
            AccessModifier = accessModifier;
            Type = type;
            Name = name;
        }

        public Member() { }

        public AccessModifier AccessModifier { get; protected set; }
        public virtual string Type { get; protected set; }
        public virtual string Name { get; protected set; }
    }
}
