using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support;
using NsiTest.Elements;

namespace NsiTest.Pages.NoModalPage
{
    public class RequestListPage : NoModalPageWithIR
    {
        [FindsBy(How = How.XPath, Using = @"id(""apexir_SEARCH"")")]
        public IWebElement searchInput { get; set; }

        public RequestListPage()
        {
            C_TITLE = "Заявки";
        }
    }
}
