using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Swd.Core.WebDriver;
using NsiTest.Fields;

namespace NsiTest.Elements
{
    internal class NsiSelectList : NsiElement
    {
        public NsiSelectList(IWebElement pElement) : base(pElement) { }

        public override void SetValue(NsiElementFieldValue pValue)
        {
            Element.WaitUntilVisible(TimeSpan.FromSeconds(10));
            SelectElement selectList = new SelectElement(Element);
            selectList.SelectByValue(pValue.ToString());
        }
    }
}