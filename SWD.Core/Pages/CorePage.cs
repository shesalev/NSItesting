using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Swd.Core.WebDriver;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace Swd.Core.Pages
{
    public abstract class CorePage
    {
        public IWebDriver Driver { get { return SwdBrowser.Driver; } }

        public CorePage()
        {
            Console.WriteLine("CorePage");
            Console.WriteLine(Driver.Title);

            PageFactory.InitElements(Driver, this);
        }

        public string GetTitle()
        {
            return Driver.Title;
        }

        public IWebElement FindElement(By pSelector)
        {
            return Driver.FindElement(pSelector);
        }

        public IWebElement FindElementBy(By pSelector)
        {
            return Driver.FindElementBy(pSelector);
        }

        public bool FastVisibleElement(By pSelector)
        {
            return Driver.FastVisibleElement(pSelector);
        }

        public ReadOnlyCollection<IWebElement> FindElements(By pSelector)
        {
            return Driver.FindElements(pSelector);
        }


        public IWebElement FindElementsFirstVisible(By pSelector)
        {
            return Driver.GetFirstVisible(pSelector);
            //return FindElements(pSelector).GetFirstVisible();
        }        

        public IWebDriver SwitchToModal(By pSelector)
        {
            IWebElement frameElem = Driver.GetFirstVisible(pSelector);
            return Driver.UntilFrameToBeAvailableAndSwitchToIt(frameElem.GetAttribute("name"));
        }

        public void SwitchToDefaultContent()
        {
            Driver.SwitchTo().DefaultContent();
        }

        public void AcceptAlert()
        {            
            IAlert lAlert = Driver.UntilAlert();;
            lAlert.Accept();
        }
    }
}
