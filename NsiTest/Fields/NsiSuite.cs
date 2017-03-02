using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NsiTest.Fields
{
    public class NsiSuite
    {
        public NsiSuite(string pRequestId, IList<NsiEntity> pEntityList)
        {
            this.RequestId = pRequestId;
            this.EntityList = pEntityList;
        }
        public string RequestId { get; private set; }

        public IList<NsiEntity> EntityList { get; private set; }
    }
}
