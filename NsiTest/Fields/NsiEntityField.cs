using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NsiTest.Fields
{
    public class NsiEntityField
    {
        public NsiEntityField(string pType, string pAction, string pId, IList<NsiElementField> pFields)
        {
            Type = pType.ToLower();
            Action = pAction.ToLower();
            Id = pId.ToLower();
            Fields = pFields;
        }

        public string Type { get; private set; }

        public string Action { get; private set; }

        public string Id { get; private set; }

        public IList<NsiElementField> Fields { get; private set; }
    }
}
