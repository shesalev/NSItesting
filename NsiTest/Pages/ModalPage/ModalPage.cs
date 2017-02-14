using System;
using Swd.Core.Pages;
using Swd.Core.WebDriver;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using NsiTest.Elements;
using System.Collections.Generic;

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

        [FindsBy(How = How.CssSelector, Using = @"#messages .htmldbUlErr li")]
        protected IWebElement MessTextElem { get; private set; }

        //[FindsBy(How = How.CssSelector, Using = @"#messages img.uErrorIcon")]
        //protected IList<IWebElement> ErrorMess { get; private set; }

        [FindsBy(How = How.CssSelector, Using = ".cboxIframe")]
        protected IWebElement ModalWindow { get; private set; }


        public ModalPage()
        {
            Console.WriteLine("ModalPage");
            SwitchToModal(By.CssSelector(".cboxIframe"));
        }

        private void CheckError()
        {
            //var err = FastFindElement(By.CssSelector("#messages .htmldbUlErr li"));

            //if (/*err.Count > 0*/err.IsDisplayedSafe())
            var err = FastVisibleElement(By.CssSelector("#messages .htmldbUlErr li"));
            if (err)
            {
                throw new NsiTest.Exceptions.PageError(ErrorPageMessage.GetMessage(MessTextElem));
            }
        }

        private void CheckErrorAndSwitchDefault()
        {
            CheckError();
            SwitchToDefaultContent();
        }

        public void Cancel()
        {
            CancelBtn.ClickWait();
            SwitchToDefaultContent();
        }

        public void Add()
        {
            CreateBtn.ClickWait();
            CheckErrorAndSwitchDefault();
        }

        public void Edit()
        {
            SaveBtn.ClickWait();
            CheckErrorAndSwitchDefault();
        }

        public void Delete()
        {
            DeleteBtn.ClickWait();
            AcceptAlert();
            CheckErrorAndSwitchDefault();
        }

        public void Repair()
        {
            RepairBtn.ClickWait();
            CheckErrorAndSwitchDefault();
        }
    }

}
