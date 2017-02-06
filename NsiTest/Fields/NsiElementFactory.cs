using OpenQA.Selenium;
using Swd.Core.WebDriver;
using NsiTest.Elements;

namespace NsiTest.Fields
{
    public class NsiElementFactory
    {
        public NsiElement CreateNsiElement(IWebElement pElement)
        {
            NsiElement nsiElement = null;

            IWebElement lInput = pElement.WaitUntilVisible();

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

            return nsiElement;
        }
    }
}
