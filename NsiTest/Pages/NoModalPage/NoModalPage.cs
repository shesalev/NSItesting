using System;
using System.Collections.Generic;
using System.Linq;
using Swd.Core.Pages;
using Swd.Core.WebDriver;
using OpenQA.Selenium;
using NsiTest.Elements;
using NsiTest.Exceptions;
using NsiTest.Pages.ModalPage;
using NsiTest.Fields;
using NsiTest.Tests.Positions;

namespace NsiTest.Pages.NoModalPage
{
    public abstract class NoModalPage : CorePage
    {
        protected String C_TITLE;

        protected MainTabElement mainTabElement = new MainTabElement();

        public bool ContainsTitle()
        {
            var lTitle = this.GetTitle();
            var res = lTitle.Contains(C_TITLE);
            if (!res)
            {
                throw new TitleError("Current title \"" + lTitle + "\" don`t contain template title \"" + C_TITLE + "\"");
            }
            return true;
        }

        public IWebElement GetEditViewEntityBtn(string pValue)
        {
            return FindElementsFirstVisible(By.XPath(PositionEntityFromFrameAction.GetEditViewBtnSelector(pValue)));
        }

        public void ClickEditViewModalByValue(String pValue)
        {
            IWebElement lSelectRow = GetEditViewEntityBtn(pValue);
            lSelectRow.Click();
        }

        public String GetLastAddEntityId()
        {
            IWebElement l_lastId = FindElement(By.Id("P0_ENTITY_ID_LAST_ADD"));

            return l_lastId.GetAttribute("value");
        }

        public void CheckSuccessMess()
        {
            Console.WriteLine("CheckSuccessMess");
            Console.WriteLine(GetTitle());
            FindElementBy(By.Id("uSuccessMessage")).WaitUntilVisible();
        }

        // Open modal search form on any no modal page
        public void SearchByIdGuid(String idGuid)
        {
            //IWebElement editBtn = GetEditViewEntityBtn(idGuid);

            if (!FastVisibleElement(By.XPath(PositionEntityFromFrameAction.GetEditViewBtnSelector(idGuid))))
            {
                try
                {
                    //IJavaScriptExecutor js = Driver as IJavaScriptExecutor;
                    //string title = (string)js.ExecuteScript("$.event.trigger('open_search'," + idGuid + ");");
                    SwdBrowser.ExecuteScript("$.event.trigger('open_search','" + idGuid + "');");
                }
                catch (Exception e)
                {
                    throw new GlobalSearchPageError("Open global search error: " + e.Message);
                }

                SearchModalPage searchModalPage = new SearchModalPage();

                searchModalPage.clkRedirectBtn();
            }
        }

        public void goToClasses()
        {
            mainTabElement.goToClasses();
        }

        public void goToSearch()
        {
            mainTabElement.goToSearch();
        }
        public void WaitLoading()
        {
            Wait.UntilNotVisible(By.Id("loadingIcon"), Driver, TimeSpan.FromSeconds(15));
        }
    }
}
