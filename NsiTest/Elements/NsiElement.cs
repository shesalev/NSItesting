using System;
using OpenQA.Selenium;

namespace NsiTest.Elements
{
    public abstract class NsiElement
    {
        protected IWebElement Element;

        public NsiElement(IWebElement pElement)
        {
            this.Element = pElement;
        }

        // Check for the class of an element
        public static bool hasClass(IWebElement pInput, string pClassName)
        {
            String lClass = pInput.GetAttribute("class").ToUpper();
            return lClass.Contains(pClassName.ToUpper());
        }

        abstract public void setValue(string pValue);
    }

}
