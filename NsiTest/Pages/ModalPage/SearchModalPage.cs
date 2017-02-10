using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Swd.Core.WebDriver;

namespace NsiTest.Pages.ModalPage
{
    public class SearchModalPage : ModalPage
    {
        [FindsBy(How = How.XPath, Using = @"id(""P4_GUID"")")]
        private IWebElement GUIdInput { get; set; }

        [FindsBy(How = How.XPath, Using = @"id(""P4_GUID_SEARCH"")")]
        private IWebElement GUIdSearchBtn { get; set; }
        

        // Search entity by id or guid
        public void searchEntity(String pGuidId)
        {
            GUIdInput.WaitUntilVisible();
            GUIdInput.SendKeys(pGuidId);

            GUIdSearchBtn.Click();
        }

        public void clkRedirectBtn()
        {
            //IWebElement lBtn = Driver.FindElements(By.CssSelector(".redirectBTN"));

            IList<IWebElement> lBtns = FindElements(By.XPath(".//a[contains(@class,'redirectBTN')]"));
            //Console.WriteLine("Count rows:" + lRowsList.Count());

            Console.WriteLine("clkRedirectBtn");
            Console.WriteLine(lBtns.Count());

            var lBtn = lBtns.First();//[lBtns.Count() - 1];
            Console.WriteLine(lBtn);

            lBtn.ClickWait();
        }
    }
}
