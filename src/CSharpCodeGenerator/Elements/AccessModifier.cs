using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpCodeGenerator.Elements
{
    public class AccessModifier
    {
        enum Modifier 
        {
            none,
            @public, 
            @private, 
            @internal        
        }
        private readonly Modifier _modifier;

        private AccessModifier(Modifier modifier)
        {
            _modifier = modifier;
        }

        public static AccessModifier None => new AccessModifier(Modifier.none);
        public static AccessModifier Public => new AccessModifier(Modifier.@public);
        public static AccessModifier Private => new AccessModifier(Modifier.@private);
        public static AccessModifier Internal => new AccessModifier(Modifier.@internal);

        public override bool Equals(object obj)
        {
            return obj is AccessModifier accessModifier 
                && _modifier == accessModifier._modifier;
        }

        public override string ToString()
        {
            return _modifier.ToString();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
