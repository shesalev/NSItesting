using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NsiTest.Exceptions
{
    public class GlobalSearchPageError : Exception
    {
        public GlobalSearchPageError(string errorMessage) : base(errorMessage)
        {
        }
    }
}
