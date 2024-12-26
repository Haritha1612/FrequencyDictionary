using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrequencyDictionary
{
    public class NoElementsException : Exception
    {
        public NoElementsException(string message) : base(message) { }
    }
}
