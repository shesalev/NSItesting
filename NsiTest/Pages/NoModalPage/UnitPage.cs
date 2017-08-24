using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Swd.Core.WebDriver;
using NsiTest.Pages.AddPageAction;

namespace NsiTest.Pages.NoModalPage
{
    internal class UnitPage: NoModalPage
    {
        [FindsBy(How = How.XPath, Using = @"id(""expand_all"")")]
        public IWebElement expandAll { get; set; }
        [FindsBy(How = How.XPath, Using = @"id(""addUnitBtn"")")]
        public IWebElement addUnitBtn { get; set; }

        public UnitPage()
        {
            C_TITLE = "Единицы измерения";
        }

        public void selectUnitInTree(string pEntityId)
        {
            //FindElementBy(By.Id("classesTree-id-111"));
            try
            {
                expandAll.ClickWait();
                var obj = ExecuteScript("$('#unitTree').fancytree('getTree').getNodeByKey('" + pEntityId + "').setActive();");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new NoSuchElementException("No found node with id = '" + pEntityId + "' in tree ");
            }
        }

        public void clkCreateUnit()
        {
            addUnitBtn.WaitUntilVisible(TimeSpan.FromSeconds(3));
            addUnitBtn.Click();
        }
    }
}