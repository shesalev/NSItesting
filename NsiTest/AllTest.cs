using System;
using System.Collections.Generic;
using NUnit.Framework;
using NsiTest.Pages.NoModalPage;
using NsiTest.Tests;
using Swd.Core.WebDriver;
using Swd.Core.Configuration;

namespace NsiTest
{
    [TestFixture]
    public class AllTest
    {
        [SetUp]
        public void Initialize()
        {
            Login();
        }

        private void Login()
        {
            Console.WriteLine("Start Login");

            String С_SESSION_ID;

            try
            {
                С_SESSION_ID = @Config.applicationUserSessionId;
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

            Assert.True(reqListPage.ContainsTitle(), "No login into application");

            var ir = reqListPage.GetIntReport();

            ir.SearchText(pRequestId);

            ir.SelectRowByValue(pRequestId);

            // Enter into nsi
            var reqViewPage = new RequestViewPage();

            Assert.True(reqViewPage.ContainsTitle());

            reqViewPage.enterNsiBtn.Click();

            Assert.True(reqViewPage.IsEnterToRequest(), "No enter into nsi request");
        }

        [Test]
        public void ClassTestSuit()
        {
            Console.WriteLine("Start Class test");

            EnterToRequest("4248");

            var lFieldsList = LoadData.GetData("ClassData.xml");

            EntityTest entityTest = new ClassTest("lastId", lFieldsList);

            entityTest.setPosition();

            string lastId="";

            try
            {
                lastId = entityTest.Add(lFieldsList);
            }
            catch (NsiTest.Exceptions.PageError e)
            {
                Console.WriteLine(e.StackTrace);
                Assert.That(false, e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                Assert.That(false, e.Message);
            }

            //if (lastId.Length > 0)
            //{
            entityTest =new ClassTest(lastId, lFieldsList);
            entityTest.setPosition(lastId);

                entityTest.Delete();
            //}

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
