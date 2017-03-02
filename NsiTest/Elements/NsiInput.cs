using System;
using OpenQA.Selenium;
using Swd.Core.WebDriver;

namespace NsiTest.Elements
{
    public class NsiInput : NsiElement
    {
        public NsiInput(IWebElement pElement) : base(pElement) { }

        public override void SetValue(String pValue)
        {
            Element.WaitUntilVisible(TimeSpan.FromSeconds(10));
            Element.Clear();
            Element.SendKeys(pValue);
        }
    }
}
