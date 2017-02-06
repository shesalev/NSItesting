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

        public String GetTitle()
        {
            return Driver.Title;
        }

        public bool ContainsTitle()
        {
            return Driver.Title.Contains(C_TITLE);
        }

        public void ClickEditViewModalByValue(String pValue)
        {
            IList<IWebElement> lRowsList = Driver.FindElements(By.XPath(".//a[@value='" + pValue + "' and contains(@class,'edit_view_modal')]"));

            Console.WriteLine("ClickEditViewModalByValue");
            Console.WriteLine("Count rows:" + lRowsList.Count());

            var lSelectRow = lRowsList[lRowsList.Count() - 1];

            lSelectRow.Click();
        }

        public String GetLastAddEntityId()
        {
            IWebElement l_lastId = Driver.FindElement(By.Id("P0_ENTITY_ID_LAST_ADD"));
            //        l_lastId.should(Condition.matchText(".*"));
            //        System.out.println("getLastAddEntityId");
            //        System.out.println("'" + l_lastId.val() + "'");
            //        System.out.println("getLastAddEntityId after print value");
            return l_lastId.GetAttribute("value");
        }

        public void CheckSuccessMess()
        {
            Driver.FindElement(By.Id("uSuccessMessage")).WaitUntilVisible();
        }

        // Open modal search form on any no modal page
        public void globalOpenSearch(String idGuid)
        {
            // actions().sendKeys(Keys.chord(Keys.SHIFT, Keys.CONTROL, "f"))
            // action.keyDown(Keys.CONTROL).sendKeys(String.valueOf('\u0066')).perform();
            // actions().keyDown(Keys.CONTROL).sendKeys(String.valueOf('\u0066')).perform();
            //executeJavaScript("$.event.trigger('open_search'," + idGuid + ");");
            IJavaScriptExecutor js = Driver as IJavaScriptExecutor;
            string title = (string)js.ExecuteScript("$.event.trigger('open_search'," + idGuid + ");");
        }

        public void goToClasses()
        {
            mainTabElement.goToClasses();
        }
    }
}
