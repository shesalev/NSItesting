using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NsiTest.Fields
{
    public class NsiEntity
    {
        public NsiEntity(string pType, string pAction, string pId,string pParentId, IList<NsiElementField> pFields)
        {
            Type = pType.ToLower();
            Action = pAction.ToLower();
            Id = pId.ToLower();
            ParentId = pParentId.ToLower();
            Fields = pFields;
        }

        public string Type { get; private set; }

        public string Action { get; private set; }

        public string Id { get; private set; }

        public string ParentId { get; private set; }

        public IList<NsiElementField> Fields { get; private set; }

        public override string ToString()
        {
            var txt = "Entity Type: " + this.Type + ", Action: " + this.Action + ", Id: " + this.Id + ", Fields count:" + this.Fields.Count;
            return txt;
        }
    }
}
