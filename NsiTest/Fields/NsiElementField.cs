using System;

namespace NsiTest.Fields
{
    public class NsiElementField
    {

        public NsiElementField(string pFieldId, NsiElementFieldValue pFieldValue)
        {
            this.FieldId = pFieldId;
            this.FieldValue = pFieldValue;
        }
        
        public string FieldId
        {
            get;
            private set;
        }

        public NsiElementFieldValue FieldValue
        {
            get;
            private set;
        }

        public string GetTextValue()
        {
            return FieldValue.GetStringValue();
        }

    }
}
