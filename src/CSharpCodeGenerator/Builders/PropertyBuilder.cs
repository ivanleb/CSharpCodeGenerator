using CSharpCodeGenerator.Elements;
using System;

namespace CSharpCodeGenerator.Builders
{
    public class PropertyBuilder
    {
        private string _type = null;
        private string _name = null;
        private AccessModifier _accessModifier;
        private bool _isAuto;

        public PropertyBuilder()
        {
            _accessModifier = AccessModifier.Public;
        }

        public PropertyBuilder Type(string type)
        {
            _type = type;
            return this;
        }

        public PropertyBuilder Access(AccessModifier accessModifier)
        {
            _accessModifier = accessModifier;
            return this;
        }

        public PropertyBuilder Name(string name)
        {
            _name = name;
            return this;
        }

        public PropertyBuilder Auto(bool auto)
        {
            _isAuto = auto;
            return this;
        }

        internal Property Build()
        {
            var field = new Field(_accessModifier, _type, _name, false);
            return new Property(_isAuto, field);
        }
    }
}