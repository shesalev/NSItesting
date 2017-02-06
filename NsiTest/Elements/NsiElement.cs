using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

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
        public static bool hasClass(IWebElement pInput, String pClassName)
        {
            String lClass = pInput.GetAttribute("class").ToUpper();
            return lClass.Contains(pClassName.ToUpper());
        }

        abstract public void setValue(String pValue);
    }

}
