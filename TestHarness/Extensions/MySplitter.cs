using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHarness.Extensions
{
    public class MySplitter
    {
        public string NamedPartX { get; private set; }
        public string NamedPartY { get; private set; }

        public MySplitter(string split)
        {
            string[] results = split.Split(' ');
            NamedPartX = results[0];
            NamedPartY = results[1];
        }
    }
}

