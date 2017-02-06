using NsiTest.Fields;

namespace NsiTest.Pages.ModalPage
{
    public class DefaultModalPage : ModalPage
    {
        private NsiElementFactory nsiElementFactory;

        public DefaultModalPage()
        {
            nsiElementFactory = new NsiElementFactory();
        }

        // Fill all fields on modal form
        public void FillForm(/*ArrayList<NsiElementField> pFieldList*/)
        {
            //for (NsiElementField lField : pFieldList)
            //{
            //    nsiElementFactory.createNsiElement(lField.getId()).setValue(lField.getValue());
            //}
        }
    }
}
