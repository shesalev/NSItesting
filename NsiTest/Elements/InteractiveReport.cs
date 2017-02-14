using System;
using System.Collections.Generic;
using System.Linq;
using Swd.Core.Pages;
using Swd.Core.WebDriver;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace NsiTest.Elements
{
    public class InteractiveReport : CorePage
    {
        [FindsBy(How = How.XPath, Using = @"id(""apexir_SEARCH"")")]
        [CacheLookup]
        private IWebElement searchInput { get; set; }

        [FindsBy(How = How.XPath, Using = @"id(""apexir_btn_SEARCH"")")]
        [CacheLookup]
        private IWebElement searchBtn { get; set; }

        public void SearchText(String pText)
        {
            searchInput.WaitUntilVisible().SendKeys(pText);

            searchBtn.WaitUntilVisible().Click();

            WaitLoading();
        }

        public void WaitLoading()
        {
            Wait.UntilNotVisible(By.Id("apexir_LOADER"), Driver, TimeSpan.FromSeconds(15));
        }

        public void SelectRowByValue(String pValue)
        {
            //IList<IWebElement> lRowsList = Driver.FindElements(By.XPath("//*[@value=\"" + pValue + "\"][last()]"));
            //IList<IWebElement> lRowsList = Driver.FindElements(By.XPath("//*[@value=\"" + pValue + "\"][last()]"));
            //IList<IWebElement> lRowsList = Driver.FindElements(By.XPath("//*[@class=\"apexir_WORKSHEET_DATA\"]"));
            IList<IWebElement> lRowsList = FindElements(By.XPath(".//table[@class='apexir_WORKSHEET_DATA']/tbody/tr/td/a[@value='" + pValue + "']"));
            //Console.WriteLine("Count rows:" + lRowsList.Count());

            var lSelectRow = lRowsList.Last();

            lSelectRow.ClickWait();

            //foreach (var lRow in lRowsList)
            //{
            //    Console.WriteLine("lRow");
            //    Console.WriteLine(lRow.GetAttribute("id"));
            //    Console.WriteLine(lRow.TagName);
            //    lSelectRow = lRow;
            //}


            //*[@id="106299875751339337"]/tbody/tr[]

            //lElem.Click();

            //IList<IWebElement> RequestLinkList =
            //    Driver.FindElements(By.CssSelector(".request_view"));

            //if (RequestLinkList.Count > 0)
            //{
            //    foreach (var RequestLink in RequestLinkList)
            //    {
            //        String Value = RequestLink.GetAttribute("value");

            //        // Select the checkbox it the value of the checkbox is same what you are looking for
            //        if (Value.Equals(pValue) && RequestLink.Displayed)
            //        {
            //            RequestLink.Click();
            //            // This will take the execution out of for loop
            //            break;
            //        }
            //    }
            //}
        }

    }
}
