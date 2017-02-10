using System;
using System.Collections.Generic;
using System.Linq;
using Swd.Core.Pages;
using Swd.Core.WebDriver;
using OpenQA.Selenium;
using NsiTest.Elements;

namespace NsiTest.Pages.NoModalPage
{
    public abstract class NoModalPage : CorePage
    {
        protected String C_TITLE;

        protected MainTabElement mainTabElement = new MainTabElement();

        public bool ContainsTitle()
        {
            return this.GetTitle().Contains(C_TITLE);
        }

        public void ClickEditViewModalByValue(String pValue)
        {
            //IList<IWebElement> lRowsList = Driver.FindElements(By.XPath(".//a[@value='" + pValue + "' and contains(@class,'edit_view_modal')]"));

            //Console.WriteLine("ClickEditViewModalByValue");
            //Console.WriteLine("Count rows:" + lRowsList.Count());

            IWebElement lSelectRow = FindElementsFirstVisible(By.XPath(".//a[@value='" + pValue + "' and contains(@class,'edit_view_modal')]"));

            //lRowsList.Last();

            //lSelectRow.WaitUntilVisible();

            lSelectRow.Click();
        }

        public String GetLastAddEntityId()
        {
            IWebElement l_lastId = FindElement(By.Id("P0_ENTITY_ID_LAST_ADD"));
            //l_lastId.WaitUntilVisible();
            return l_lastId.GetAttribute("value");
        }

        public void CheckSuccessMess()
        {
            Console.WriteLine("CheckSuccessMess");
            Console.WriteLine(GetTitle());
            FindElement(By.Id("uSuccessMessage")).WaitUntilVisible();
        }

        // Open modal search form on any no modal page
        public void globalOpenSearch(String idGuid)
        {
            IJavaScriptExecutor js = Driver as IJavaScriptExecutor;
            string title = (string)js.ExecuteScript("$.event.trigger('open_search'," + idGuid + ");");
        }

        public void goToClasses()
        {
            mainTabElement.goToClasses();
        }
    }
}
