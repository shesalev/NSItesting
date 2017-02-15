using System;
using System.Collections.Generic;
using NUnit.Framework;
using NsiTest.Pages.NoModalPage;
using NsiTest.Tests;
using Swd.Core.WebDriver;
using Swd.Core.Configuration;
using NsiTest.Exceptions;
using NsiTest.Fields;

namespace NsiTest
{
    [TestFixture]
    public class AllTest
    {
        [SetUp]
        public void Initialize()
        {
            //try
            //{
            Login();
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.StackTrace);
            //    Assert.Fail(e.Message);
            //}
        }

        private void Login()
        {
            Console.WriteLine("Start Login");

            String С_SESSION_ID;

            try
            {
                С_SESSION_ID = @Config.applicationUserSessionId;
                SwdBrowser.Driver.Manage().Window.Maximize();
                SwdBrowser.Driver.Navigate().GoToUrl(@Config.applicationMainUrl + С_SESSION_ID);

                SwdBrowser.Driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(30));
                SwdBrowser.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(2));

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

            reqListPage.ContainsTitle();


            var ir = reqListPage.GetIntReport();

            ir.SearchText(pRequestId);

            ir.SelectRowByValue(pRequestId);

            // Enter into nsi
            var reqViewPage = new RequestViewPage();


            reqViewPage.ContainsTitle();


            reqViewPage.enterToNsi();

            Assert.True(reqViewPage.IsEnterToRequest(), "No enter into nsi request");
        }

        [Test]
        public void ClassPositiveTestSuit()
        {
            Console.WriteLine("Start Class test");

            // Load test data
            var lEntityList = LoadData.GetData("ClassData.xml");


            if (lEntityList.Count > 0)
            {
                // Enter to request
                EnterToRequest("4248");

                string lastId = "";


                foreach (NsiEntityField lEntity in lEntityList)
                {
                    var lId = lEntity.Id;

                    if (lId.Equals("lastadd"))
                    {
                        if (lastId.Length == 0)
                        {
                            Console.WriteLine("Skip test " + lEntity.ToString());
                            continue;
                        }
                        lId = lastId;
                    }

                    // Get test entity
                    EntityTest entityTest = new ClassTest(/*lId, lEntity.Fields*/);

                    Console.WriteLine("Test entity " + lEntity.ToString());

                    // Do test action
                    if (lEntity.Action.Equals("add"))
                    {
                        entityTest.setPosition();
                        lastId = entityTest.Add(lEntity.Fields);
                    }
                    else if (lEntity.Action.Equals("edit"))
                    {
                        entityTest.setPosition(lId);
                        entityTest.Edit(lEntity.Fields);
                    }
                    else if (lEntity.Action.Equals("delete"))
                    {
                        entityTest.setPosition(lId);
                        entityTest.Delete();
                    }
                    else if (lEntity.Action.Equals("repair"))
                    {
                        entityTest.setPosition(lId);
                        entityTest.Repair(lEntity.Fields);
                    }
                    else
                    {

                    }

                    //}
                    //catch (PageError e)
                    //{
                    //    Console.WriteLine(e.StackTrace);
                    //    Assert.Fail(e.Message + "/n" + e.StackTrace);
                    //}
                    //catch (TitleError e)
                    //{
                    //    //Console.WriteLine("Error login into application:");
                    //    Console.WriteLine(e.StackTrace);
                    //    Assert.Fail(e.Message + "/n" + e.StackTrace);
                    //}
                    //catch (Exception e)
                    //{
                    //    Console.WriteLine(e.StackTrace);
                    //    Assert.Fail(e.Message + "/n" + e.StackTrace);
                    //}
                }
            }
            else
            {
                Assert.Fail("Пустой файл данных \"ClassData.xml\"");
            }

        }

        [TearDown]
        public void EndTest()
        {
            Console.WriteLine("Start EndTest");
            SwdBrowser.CloseDriver();
            //SwdBrowser.Driver.Close();
            //SwdBrowser.Driver.Quit();

            Console.WriteLine("End EndTest");

        }
    }
}
