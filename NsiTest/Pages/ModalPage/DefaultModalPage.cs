using System.Collections.Generic;
using NsiTest.Fields;
using NsiTest.Elements;

namespace NsiTest.Pages.ModalPage
{
    public class DefaultModalPage : ModalPage
    {
        public DefaultModalPage() { }

        // Fill all fields on modal form
        public void FillForm(IList<NsiElementField> pFieldsList)
        {
            foreach (NsiElementField lField in pFieldsList)
            {
                NsiElementFactory nsiEl = new NsiElementFactory();

                nsiEl.SetValue(lField);
            }
        }
    }
}
