using CSharpCodeGenerator.Builders;
using CSharpCodeGenerator.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpCodeGenerator.Elements
{
    public class Method : Member
    {
        private List<Parameter> _parameters = new List<Parameter>();
        public Method(AccessModifier accessModifier, string returnType, string name, params Parameter[] parameters) 
            : base(accessModifier, returnType, name)
        {
            _parameters.AddRange(parameters);
        }

        public static MethodBuilder Add(string name) => MethodBuilder.AddMethod(name);

        public override string ToString()
        {
            return $@"{AccessModifier} {Type} {Name}({ _parameters.Select(prop => prop.ToString()).Aggregate((acc, arg) => acc + "," + arg)}) 
            {{
                return default({Type});
            }}";
        }
    }
}
