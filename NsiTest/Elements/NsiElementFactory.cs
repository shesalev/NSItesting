using NsiTest.Fields;
using OpenQA.Selenium;
using Swd.Core.WebDriver;

namespace NsiTest.Elements
{
    public class NsiElementFactory
    {
        private NsiElement CreateNsiElement(string pId)
        {
            IWebElement pElement = SwdBrowser.Driver.FindElement(By.Id(pId)) ;

            // TODO: add other using types
            if (NsiElement.HasClass(pElement, "modal_window_input"))
            {
                return new NsiInput(pElement);
            }
            else if (NsiElement.HasClass(pElement, "modal_window_select"))
            {
                return new NsiSelectList(pElement);
            }
            else if (NsiElement.HasClass(pElement, "superlov-input"))
            {
                return new NsiSuperLov(pElement);
            }
            else if (NsiElement.HasClass(pElement, "modal_window_id_list"))
            {
                return new NsiIdList(pElement);
            }
            else if (NsiElement.HasClass(pElement, "modal_window_anl_per"))
            {
                return new NsiAnalitic(pElement);
            }
            else
            {
                return new NsiNullElement(pElement);
            }
        }

        public void SetValue(NsiElementField pField)
        {
            NsiElement nsiEl = CreateNsiElement(pField.GetId());

            nsiEl.SetValue(pField.FieldValue);
        }
    }
}
