using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Swd.Core.WebDriver;

namespace NsiTest.Pages.NoModalPage
{
    public class RequestViewPage : NoModalPageWithIR
    {
        [FindsBy(How = How.XPath, Using = @"id(""btnEditNSI"")")]
        private IWebElement enterNsiBtn { get; set; }

        [FindsBy(How = How.XPath, Using = @"id(""nsi_request_status"")")]
        private IWebElement requestStatus { get; set; }

        public RequestViewPage():base()
        {
            PageFactory.InitElements(SwdBrowser.Driver, this);
            Console.WriteLine("RequestViewPage");
            Console.WriteLine(Driver.Title);
            C_TITLE = "Заявка";
        }

        public void enterToNsi() {
            enterNsiBtn.ClickWait();
        }

        public bool IsEnterToRequest()
        {
            return requestStatus.Displayed;
        }
    }
}
