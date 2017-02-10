using System;
using OpenQA.Selenium;

namespace NsiTest.Elements
{
    public class NsiNullElement : NsiElement
    {
        public NsiNullElement(IWebElement pElement): base(pElement)
        {
        }
        override
        public void setValue(String pValue)
        {
        }
    }
}
