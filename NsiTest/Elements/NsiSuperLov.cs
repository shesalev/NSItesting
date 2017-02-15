using OpenQA.Selenium;
using Swd.Core.WebDriver;
using System;

namespace NsiTest.Elements
{
    internal class NsiSuperLov : NsiElement
    {
        public NsiSuperLov(IWebElement pElement) : base(pElement)
        {
        }
        public override void setValue(string pValue)
        {
            // Open modal window with table of values
            var lOpenModalBtn = Element.GetPatent().GetPatent().FindElement(By.CssSelector(".superlov-modal-open"));
            lOpenModalBtn.Click();

            // Select value by pValue
            var lRow = SwdBrowser.Driver.FindElementBy(By.CssSelector("[data-return=\"" + pValue + "\"]"));
            lRow.Click();
        }
    }
}