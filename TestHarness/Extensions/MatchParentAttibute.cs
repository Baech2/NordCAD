using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHarness.Extensions
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MatchParentAttibute : Attribute
    {
        public readonly string ParentPropertyName;
        public MatchParentAttibute(string parentPropertyName)
        {
            ParentPropertyName = parentPropertyName;
        }
    }
}
