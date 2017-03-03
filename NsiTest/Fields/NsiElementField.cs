using System;

namespace NsiTest.Fields
{
    public class NsiElementField
    {
        private string _fieldId;

        public NsiElementField(string pFieldId, NsiElementFieldValue pFieldValue)
        {
            this._fieldId = pFieldId;
            this.FieldValue = pFieldValue;
        }

        public string GetId()
        {
            return _fieldId;
        }

        public string GetTextValue()
        {
            return FieldValue.ToString();
        }

        public NsiElementFieldValue FieldValue
        {
            get;
            private set;
        }

    }
}
