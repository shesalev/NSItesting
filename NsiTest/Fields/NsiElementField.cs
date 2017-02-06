using System;

namespace NsiTest.Fields
{
    public class NsiElementField
    {
        private String fieldId;
        private String fieldValue;

        public NsiElementField(String pFieldId, String pFieldValue)
        {
            this.fieldId = pFieldId;
            this.fieldValue = pFieldValue;
        }

        public String getId()
        {
            return fieldId;
        }

        public String getValue()
        {
            return fieldValue;
        }
    }
}
