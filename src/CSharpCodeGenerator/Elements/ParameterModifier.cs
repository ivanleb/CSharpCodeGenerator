using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpCodeGenerator.Elements
{
    public class ParameterModifier
    {
        enum Modifier
        {
            none, @params, @in, @ref, @out
        }
        private Modifier _modifier;

        private ParameterModifier(Modifier modifier)
        {
            _modifier = modifier;
        }

        public static ParameterModifier None => new ParameterModifier(Modifier.none);
        public static ParameterModifier Params => new ParameterModifier(Modifier.@params);
        public static ParameterModifier In => new ParameterModifier(Modifier.@in);
        public static ParameterModifier Ref => new ParameterModifier(Modifier.@ref);
        public static ParameterModifier Out => new ParameterModifier(Modifier.@out);

        public override bool Equals(object obj)
        {
            return obj is ParameterModifier parameterModifier && parameterModifier._modifier == _modifier;
        }

        public override int GetHashCode()
        {
            return _modifier.GetHashCode();
        }

        public override string ToString()
        {
            return _modifier.ToString();
        }
    }
}
