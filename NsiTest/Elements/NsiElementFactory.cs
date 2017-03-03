using NsiTest.Fields;
using OpenQA.Selenium;
using Swd.Core.WebDriver;

namespace NsiTest.Elements
{
    public class NsiElementFactory
    {
        private NsiElement CreateNsiElement(string pId)
        {
            IWebElement lElement = SwdBrowser.Driver.FindElement(By.Id(pId)) ;

            // TODO: add other using types
            if (NsiElement.HasClass(lElement, "modal_window_input"))
            {
                return new NsiInput(lElement);
            }
            else if (NsiElement.HasClass(lElement, "modal_window_select"))
            {
                return new NsiSelectList(lElement);
            }
            else if (NsiElement.HasClass(lElement, "superlov-input"))
            {
                return new NsiSuperLov(lElement);
            }
            else if (NsiElement.HasClass(lElement, "modal_window_id_list"))
            {
                return new NsiIdList(lElement);
            }
            else if (NsiElement.HasClass(lElement, "modal_window_anl_per"))
            {
                return new NsiAnalitic(lElement);
            }
            else
            {
                return new NsiNullElement(lElement);
            }
        }

        public void SetValue(NsiElementField pField)
        {
            NsiElement nsiEl = CreateNsiElement(pField.FieldId);

            nsiEl.SetValue(pField.FieldValue);
        }
    }
}
