using System;
using OpenQA.Selenium;
using Swd.Core.WebDriver;

namespace NsiTest.Elements
{
    internal class NsiSuperLov : NsiElement
    {
        public NsiSuperLov(IWebElement pElement) : base(pElement) { }

        /// <summary>
        /// Set value for select list page element
        /// </summary>
        /// <param name="pValue">Value</param>
        public override void SetValue(string pValue)
        {
            // Check visible page element
            Element.WaitUntilVisible(TimeSpan.FromSeconds(10));

            // Open modal window with table of values
            var lOpenModalBtn = Element.GetPatent().GetPatent().FindElement(By.CssSelector(".superlov-modal-open"));
            lOpenModalBtn.Click();

            // Select value by pValue
            var lRow = SwdBrowser.Driver.FindElementBy(By.CssSelector("[data-return=\"" + pValue + "\"]"));
            lRow.Click();
        }
    }
}