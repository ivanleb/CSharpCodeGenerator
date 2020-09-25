using CSharpCodeGenerator.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpCodeGenerator.Elements
{
    public class Constructor : Member
    {
        private HashSet<Parameter> _parameters;
        public Constructor(AccessModifier accessModifier, string name, Parameter[] parameters) : base(accessModifier, "", name)
        {
            _parameters = new HashSet<Parameter>(parameters);
        }

        public void Parameter(Parameter parameter) => _parameters.Add(parameter);

        public override string ToString()
        {
            return $@"{AccessModifier} {Name}({ _parameters.Select(prop => prop.ToString()).Aggregate((acc, arg) => acc + "," + arg)}) 
                {{
                    
                }}";
        }
    }
}
