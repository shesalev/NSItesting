using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Swd.Core.WebDriver;
using NsiTest.Pages.AddPageAction;

namespace NsiTest.Pages.NoModalPage
{
    class SettingsTabPage : NoModalPage
    {
        [FindsBy(How = How.XPath, Using = @"id(""tab_units"")")]
        public IWebElement goToUnitsBtn { get; set; }

        public void clkGoToUnits()
        {
            goToUnitsBtn.WaitUntilVisible(TimeSpan.FromSeconds(3));
            goToUnitsBtn.Click();
        }
    }
}
