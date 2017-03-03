using System;
using OpenQA.Selenium;
using Swd.Core.WebDriver;
using NsiTest.Fields;

namespace NsiTest.Elements
{
    public class NsiInput : NsiElement
    {
        public NsiInput(IWebElement pElement) : base(pElement) { }

        public override void SetValue(NsiElementFieldValue pValue)
        {
            Element.WaitUntilVisible(TimeSpan.FromSeconds(10));
            Element.Clear();
            Element.SendKeys(pValue.ToString());
        }
    }
}
