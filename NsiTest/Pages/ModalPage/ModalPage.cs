using Swd.Core.Pages;
using Swd.Core.WebDriver;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;

namespace NsiTest.Pages.ModalPage
{
    public abstract class ModalPage : CorePage
    {
        [FindsBy(How = How.XPath, Using = @"id(""btnCancel"")")]
        protected IWebElement CancelBtn { get; private set; }

        [FindsBy(How = How.XPath, Using = @"id(""btnCreate"")")]
        protected IWebElement CreateBtn { get; private set; }

        [FindsBy(How = How.XPath, Using = @"id(""btnSave"")")]
        protected IWebElement SaveBtn { get; private set; }

        [FindsBy(How = How.XPath, Using = @"id(""btnDelete"")")]
        protected IWebElement DeleteBtn { get; private set; }

        [FindsBy(How = How.XPath, Using = @"id(""btnRepair"")")]
        protected IWebElement RepairBtn { get; private set; }

        [FindsBy(How = How.CssSelector, Using = @"#messages img.uErrorIcon")]
        protected IWebElement ErrorMess { get; private set; }

        [FindsBy(How = How.CssSelector, Using = ".cboxIframe")]
        protected IWebElement ModalWindow { get; private set; }


        public ModalPage()
        {
            //switchTo().frame($(By.className("cboxIframe")));
            //FindElement(By.ClassName("cboxIframe"))
            //ModalWindow.WaitUntilVisible();
            Driver.SwitchTo().Frame(0);
        }

        private void CheckError()
        {
            //ErrorMess.WaitUntilVisible(100);

            if (ErrorMess.IsDisplayedSafe())
            {
                throw new NotFoundException();
            }
        }

        private void CheckErrorAndSwitchDefault()
        {
            CheckError();
            Driver.SwitchTo().DefaultContent();
        }

        public void Cancel()
        {
            CancelBtn.WaitUntilVisible();
            CancelBtn.Click();
            Driver.SwitchTo().DefaultContent();
        }

        public void Add()
        {
            //$(By.id("btnCreate")).shouldBe(Condition.visible).click();
            CreateBtn.WaitUntilVisible();
            CreateBtn.Click();
            CheckErrorAndSwitchDefault();
        }

        public void Edit()
        {
            //$(By.id("btnSave")).shouldBe(Condition.enabled).click();
            SaveBtn.WaitUntilVisible();
            SaveBtn.Click();
            CheckErrorAndSwitchDefault();
        }

        public void Delete()
        {
            //$(By.id("btnDelete")).shouldBe(Condition.visible).click();
            IAlert lAlert = Driver.SwitchTo().Alert();
            lAlert.Accept();
            CheckErrorAndSwitchDefault();
        }

        public void Repair()
        {
            //$(By.id("btnRepair")).shouldBe(Condition.visible).click();
            RepairBtn.WaitUntilVisible();
            RepairBtn.Click();
            CheckErrorAndSwitchDefault();
        }
    }

}
