using System.Collections.Generic;
using NsiTest.Fields;
using NsiTest.Elements;

namespace NsiTest.Pages.ModalPage
{
    public class DefaultModalPage : ModalPage
    {
        //private NsiElementFactory nsiElementFactory;

        public DefaultModalPage()
        {
            //nsiElementFactory = new NsiElementFactory();
        }

        // Fill all fields on modal form
        public void FillForm(IList<NsiElementField> pFieldsList)
        {
            foreach (NsiElementField lField in pFieldsList)
            {
                //NsiElement nsiEl = nsiElementFactory.CreateNsiElement(lField.getId());
                NsiElementFactory nsiEl = new NsiElementFactory();

                nsiEl.SetValue(lField);
            }
        }
    }
}
