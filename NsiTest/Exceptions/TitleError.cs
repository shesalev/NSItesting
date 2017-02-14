using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NsiTest.Exceptions
{
    class TitleError : Exception
    {
        public TitleError(string errorMessage) : base(errorMessage)
        {
        }
    }
}
