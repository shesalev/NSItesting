using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Swd.Core.WebDriver;
using NsiTest.Pages.AddPageAction;

namespace NsiTest.Pages.NoModalPage
{
    public class ArrtClassExtPage : NoModalPage, AddAttrClassPageAction
    {
        [FindsBy(How = How.XPath, Using = @"id(""addAttributeBtn"")")]
        public IWebElement addAttrClassBtn { get; set; }
        public void clkCreateAttributeClass()
        {
            addAttrClassBtn.WaitUntilVisible(TimeSpan.FromSeconds(3));
            addAttrClassBtn.Click();
        }
    }
}
