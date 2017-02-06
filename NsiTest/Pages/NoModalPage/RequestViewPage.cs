using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace NsiTest.Pages.NoModalPage
{
    public class RequestViewPage : NoModalPageWithIR
    {
        [FindsBy(How = How.XPath, Using = @"id(""btnEditNSI"")")]
        public IWebElement enterNsiBtn { get; private set; }

        [FindsBy(How = How.XPath, Using = @"id(""nsi_request_status"")")]
        public IWebElement requestStatus { get; private set; }

        public RequestViewPage()
        {
            C_TITLE = "Заявка";
        }

        public bool IsEnterToRequest()
        {
            return requestStatus.Displayed;
        }
    }
}
