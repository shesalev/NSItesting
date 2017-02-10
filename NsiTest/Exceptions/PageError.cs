using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NsiTest.Exceptions
{
    public class PageError : Exception
    {
        public PageError(string errorMessage) : base(errorMessage)
        {
        }
    }
}
