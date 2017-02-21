using System;
using OpenQA.Selenium;

namespace NsiTest.Elements
{
    public class NsiInput : NsiElement
    {
        public NsiInput(IWebElement pElement) : base(pElement) { }

        public override void setValue(String pValue)
        {
            Element.Clear();
            Element.SendKeys(pValue);
        }
    }
}
