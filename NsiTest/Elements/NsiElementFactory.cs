using OpenQA.Selenium;

namespace NsiTest.Elements
{
    public class NsiElementFactory
    {
        public NsiElement CreateNsiElement(IWebElement pElement)
        {
            // TODO: add other using types
            if (NsiElement.hasClass(pElement, "modal_window_input"))
            {
                return new NsiInput(pElement);
            }
            else if (NsiElement.hasClass(pElement, "modal_window_select"))
            {
                return new NsiSelectList(pElement);
            }
            else if (NsiElement.hasClass(pElement, "modal_window_id_list"))
            {
                return new NsiIdList(pElement);
            }
            else if (NsiElement.hasClass(pElement, "superlov-input"))
            {
                return new NsiSuperLov(pElement);
            }
            else
            {
                return new NsiNullElement(pElement);
            }
        }
    }
}
