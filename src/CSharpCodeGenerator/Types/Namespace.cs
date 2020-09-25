using CSharpCodeGenerator.Builders;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpCodeGenerator.Types
{
    public class Namespace
    {
        private readonly HashSet<string> _usings = new HashSet<string>();
        private readonly HashSet<Class> _classes = new HashSet<Class>();
        public Namespace(string name, string[] usings, Class[] classes)
        {
            Name = name;
            _usings.UnionWith(usings);
            _classes.UnionWith(classes);
        }

        public string Name { get; }

        public override string ToString()
        {
            var usings = _usings.Aggregate((acc, arg) => acc + "\n    " + arg);
            var classes = _classes.Select(cls => cls.ToString()).Aggregate((acc, arg) => acc + '\n' + arg);
            return $@"
namespace {Name}
{{
    {usings}
    {classes}
}}
";
        }

        public static NamespaceBuilder Add(string name) => NamespaceBuilder.AddNamespace(name);
    }
}
