using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Swd.Core.WebDriver;

namespace NsiTest.Pages.NoModalPage
{
    public class ClassTabPage : NoModalPageWithIR
    {
        [FindsBy(How = How.XPath, Using = @"id(""addClassBtn"")")]
        public IWebElement addClassBtn { get; set; }

        [FindsBy(How = How.XPath, Using = @"id(""addAttributeBtn"")")]
        public IWebElement addAttrClassBtn { get; set; }

        // class tabs
        [FindsBy(How = How.XPath, Using = @"id(""tab_01"")")]
        public IWebElement AttrClassTab { get; set; }


        //public boolean selectedClass(String class_id)
        //{
        //    return $(By.id("classesTree-id-" + class_id)).shouldBe(Condition.visible).exists();
        //}

        //public void selectClass(String class_id)
        //{
        //$(By.id("classesTree-id-" + class_id)).click();
        //}

        public void clkEditViewClassModal(string entityId)
        {
            ClickEditViewModalByValue(entityId);
        }

        public void clkCreateClassModal()
        {
            //$(By.id("classesTree-id-0")).shouldBe(Condition.visible).click();
            //    waitLoader();
            //$(By.id("addClassBtn")).shouldBe(Condition.visible).click();
            addClassBtn.WaitUntilVisible(TimeSpan.FromSeconds(3));
            addClassBtn.Click();
        }

        public void clkCreateAttributeClassModal()
        {
            //$(By.id("classesTree-id-0")).shouldBe(Condition.visible).click();
            //    waitLoader();
            //$(By.id("addClassBtn")).shouldBe(Condition.visible).click();
            addAttrClassBtn.WaitUntilVisible(TimeSpan.FromSeconds(3));
            addAttrClassBtn.Click();
        }

        public void selectClassInTree(string pId)
        {
            FindElementBy(By.Id("classesTree-id-111"));
            try
            {
                var obj = ExecuteScript("$('#classesTree').fancytree('getTree').getNodeByKey('" + pId + "').setActive();");
                Console.WriteLine(obj.ToString());
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
            }

            //SwdBrowser.HandleJavaScriptErrors();

            FindElementBy(By.Id("classesTree-id-" + pId));

            //FindElementBy(By.XPath(".//table[@class='apexir_WORKSHEET_DATA']/tbody/tr/td/a[@value='" + pValue + "']"));
        }

        public void clkAttrClassTab()
        {
            AttrClassTab.WaitUntilVisible(TimeSpan.FromSeconds(3));
            AttrClassTab.Click();
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
