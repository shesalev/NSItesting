using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using NsiTest.Pages.NoModalPage;
using NsiTest.Tests;
using Swd.Core.WebDriver;
using Swd.Core.Configuration;

namespace NsiTest
{
    [TestFixture]
    class AllTest
    {
        [SetUp]
        public void Initialize()
        {
            Login();
        }

        private void Login()
        {
            String С_SESSION_ID = @Config.applicationUserSessionId;
            
            try
            {
                SwdBrowser.Driver.Navigate().GoToUrl(@Config.applicationMainUrl + С_SESSION_ID);
                SwdBrowser.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));

            }
            catch (Exception e)
            {
                Console.WriteLine("Error:");
                Console.WriteLine(e.StackTrace);
                SwdBrowser.CloseDriver();
            }
        }

        private void EnterToRequest(String pRequestId)
        {            
            // Search nsi request in IR on requests page
            var reqListPage = new RequestListPage();

            Assert.True(reqListPage.ContainsTitle(),"No login into application");

            var ir = reqListPage.GetIntReport();

            ir.SearchText(pRequestId);

            ir.SelectRowByValue(pRequestId);

            // Enter into nsi
            var reqViewPage = new RequestViewPage();

            Assert.True(reqViewPage.ContainsTitle());

            reqViewPage.enterNsiBtn.Click();

            Assert.True(reqViewPage.IsEnterToRequest(),"No enter into nsi request");
        }

        [Test]
        public void ClassTestSuit()
        {
            Console.WriteLine("Start Class test");

            EnterToRequest("4248");

            ClassTest classTest = new ClassTest();

            classTest.setPosition();

            classTest.Add();
        }

        [TearDown]
        public void EndTest()
        {
            SwdBrowser.CloseDriver();
            //SwdBrowser.Driver.Close();
            //SwdBrowser.Driver.Quit();
        }
    }
}
