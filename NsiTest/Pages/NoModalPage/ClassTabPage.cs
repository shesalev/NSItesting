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

        [FindsBy(How = How.XPath, Using = @"id(""addClassBtn"")")]
        public IWebElement EditViewBtn { get; set; }

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
            addClassBtn.WaitUntilVisible(TimeSpan.FromSeconds(2));
            addClassBtn.Click();
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
