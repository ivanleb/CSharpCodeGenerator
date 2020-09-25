using CSharpCodeGenerator.Elements;

namespace CSharpCodeGenerator.Builders
{
    public class FieldBuilder
    {
        private string _type = null;
        private string _name = null;
        private AccessModifier _accessModifier;
        private bool _isReadonly;

        private FieldBuilder(string name)
        {
            _accessModifier = AccessModifier.Public;
            _name = name;
        }

        public static FieldBuilder AddField(string name)
        {
            return new FieldBuilder(name);
        }

        public FieldBuilder Access(AccessModifier accessModifier)
        {
            _accessModifier = accessModifier;
            return this;
        }

        public FieldBuilder Name(string name)
        {
            _name = name;
            return this;
        }

        public FieldBuilder Type(string type)
        {
            _type = type;
            return this;
        }

        public FieldBuilder Readonly(bool isReadonly)
        {
            _isReadonly = isReadonly;
            return this;
        }

        public Field Build() 
        {
            if (_type == null || _name == null)
            {
                throw new System.Exception();
            }
            return new Field(_accessModifier, _type, _name, _isReadonly);
        }
    }
}