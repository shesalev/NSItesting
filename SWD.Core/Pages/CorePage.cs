using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Swd.Core.WebDriver;
using System.Collections.ObjectModel;

namespace Swd.Core.Pages
{
    public abstract class CorePage
    {
        public IWebDriver Driver { get { return SwdBrowser.Driver; } }

        public CorePage()
        {
            PageFactory.InitElements(Driver, this);
        }

        public IWebElement FindElement(By pSelector)
        {
            return Driver.FindElement(pSelector);
        }

        public ReadOnlyCollection<IWebElement> FindElements(By pSelector)
        {
            return Driver.FindElements(pSelector);
        }
    }
}
