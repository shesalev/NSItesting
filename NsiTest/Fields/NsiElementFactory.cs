using OpenQA.Selenium;
using NsiTest.Elements;

namespace NsiTest.Fields
{
    public class NsiElementFactory
    {
        public NsiElement CreateNsiElement(IWebElement pElement)
        {
            NsiElement nsiElement = null;

            IWebElement lInput = pElement;

            // TODO: add other using types
            if (NsiElement.hasClass(lInput, "modal_window_input"))
            {
                nsiElement = new NsiInput(lInput);
            }
            //else if (NsiElement.hasClass(lInput, "modal_window_select"))
            //{
            //    nsiElement = new NsiSelectList(lInput);
            //}
            //else if (NsiElement.hasClass(lInput, "superlov-input"))
            //{
            //    nsiElement = new NsiSuperLov(lInput);
            //}
            else
            {
                nsiElement = new NsiNullElement(lInput);
            }

            return nsiElement;
        }
    }
}
