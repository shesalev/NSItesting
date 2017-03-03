using System;
using OpenQA.Selenium;
using Swd.Core.Pages;
using NsiTest.Fields;

namespace NsiTest.Elements
{
    public abstract class NsiElement : CorePage
    {
        protected IWebElement Element;

        public NsiElement(IWebElement pElement)
        {
            this.Element = pElement;
        }

        /// <summary>
        /// Check for the class of an element
        /// </summary>
        /// <param name="pInput">Value</param>
        /// <param name="pClassName">Value</param>
        public static bool HasClass(IWebElement pInput, string pClassName)
        {
            String lClass = pInput.GetAttribute(Resource1.ClassAttrbute).ToUpper();
            return lClass.Contains(pClassName.ToUpper());
        }

        /// <summary>
        /// Set value for page element
        /// </summary>
        /// <param name="pValue">Value</param>
        abstract public void SetValue(NsiElementFieldValue pValue);
    }

}
