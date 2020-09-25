using CSharpCodeGenerator.Types;
using System;
using System.Collections.Generic;
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
    }
}
