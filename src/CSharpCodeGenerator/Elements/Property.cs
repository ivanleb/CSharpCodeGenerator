using CSharpCodeGenerator.Builders;
using CSharpCodeGenerator.Types;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace CSharpCodeGenerator.Elements
{
    public class Property : Member
    {
        private readonly bool _isAuto;
        private readonly Field _field;

        public static Property CreateAutoProperty(string type, string name) 
            => new Property(true, new Field(AccessModifier.Private, type, name, false));

        public static Property CreateFullProperty(string type, string name)
            => new Property(false, new Field(AccessModifier.Private, type, name, false));

        public Property(bool isAuto, Field field) 
            : base(field.AccessModifier, field.Type, field.Name)
        {
            _isAuto = isAuto;
            _field = field;
        }

        public override string Type => _field.Type;
        public override string Name => _field.Name;

        public static PropertyBuilder Add(string name) => PropertyBuilder.AddProperty(name);
    }
}
