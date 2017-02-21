using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Swd.Core.WebDriver;
using NsiTest.Pages.AddPageAction;

namespace NsiTest.Pages.NoModalPage
{
    public class ClassTabPage : NoModalPageWithIR, AddClassPageAction, AddAttrClassPageAction
    {
        public static string C_CLASS_FOLDER_ID = "0";
        public static string C_CONNECTOR_FOLDER_ID = "2";
        public static string C_DICTIONARY_FOLDER_ID = "1";

        [FindsBy(How = How.XPath, Using = @"id(""addClassBtn"")")]
        public IWebElement addClassBtn { get; set; }

        [FindsBy(How = How.XPath, Using = @"id(""addAttributeBtn"")")]
        public IWebElement addAttrClassBtn { get; set; }

        [FindsBy(How = How.XPath, Using = @"id(""AttrClsExt"")")]
        public IWebElement AttrClsExtBtn { get; set; }
        

        // class tabs
        [FindsBy(How = How.XPath, Using = @"id(""tab_01"")")]
        public IWebElement AttrClassTab { get; set; }       

        public void clkCreateClass()
        {
            addClassBtn.WaitUntilVisible(TimeSpan.FromSeconds(3));
            addClassBtn.Click();
        }

        public void clkCreateAttributeClass()
        {
            addAttrClassBtn.WaitUntilVisible(TimeSpan.FromSeconds(3));
            addAttrClassBtn.Click();
        }

        public void selectClassInTree(string pId)
        {
            FindElementBy(By.Id("classesTree-id-111"));
            try
            {
                var obj = ExecuteScript("$('#classesTree').fancytree('getTree').getNodeByKey('" + pId + "').setActive();");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new NoSuchElementException("No found node with id = '" + pId + "' in tree ");
            }
            
            //FindElementBy(By.Id("classesTree-id-" + pId));
        }

        public void clkAttrClassTab()
        {
            AttrClassTab.WaitUntilVisible(TimeSpan.FromSeconds(3));
            AttrClassTab.Click();
        }

        public void clkAttrClsExtBtn()
        {
            AttrClsExtBtn.WaitUntilVisible(TimeSpan.FromSeconds(3));
            AttrClsExtBtn.Click();
        }

        //public void clkCreateConnectorModal()
        //{
        //$(By.id("classesTree-id-2")).shouldBe(Condition.visible).click();
        //    waitLoader();
        //$(By.id("addClassBtn")).shouldBe(Condition.visible).click();
        //}

        //public void clkCreateDirectoryModal()
        //{
        //$(By.id("classesTree-id-1")).shouldBe(Condition.visible).click();
        //    waitLoader();
        //$(By.id("addClassBtn")).shouldBe(Condition.visible).click();
        //}
    }
}
