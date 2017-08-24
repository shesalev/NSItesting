using NsiTest.Fields;
using NsiTest.Tests;
using NUnit.Framework;
using Swd.Core.Configuration;
using Swd.Core.WebDriver;
using System;

//// Explicit Waits
//WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
//IWebElement myDynamicElement = wait.Until<IWebElement>(d => d.FindElement(By.Id("someDynamicElement")));
//
//WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
//IWebElement element = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("someid")));

//IWebElement element = (IWebElement)((IJavaScriptExecutor)driver).ExecuteScript("return $('.cheese')[0]");

//IList<IWebElement> labels = driver.FindElements(By.TagName("label"));
//IList<IWebElement> inputs = (IList<IWebElement>)((IJavaScriptExecutor)driver).ExecuteScript(
//    "var labels = arguments[0], inputs = []; for (var i=0; i < labels.length; i++){" +
//    "inputs.push(document.getElementById(labels[i].getAttribute('for'))); } return inputs;", labels);

//// Alternatively, you can pass a “window handle” to the “switchTo().window()”
////method.Knowing this, it’s possible to iterate over every open window like so:
//foreach (string handle in driver.WindowHandles) {
//  driver.SwitchTo().Window(handle);
//}

//// The “navigate” interface also exposes the ability to move backwards and forwards in your browser’s history:
//driver.Navigate().Forward();
//driver.Navigate().Back();
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

        public void EntityTestByFile(string pFileName)
        {
            // Load test data
            var lNsiSuite = LoadData.GetData(pFileName);
            var lNsiEntityList = lNsiSuite.EntityList;

            if (lNsiEntityList.Count > 0)
            {
                // Enter to request
                Assert.True(RequestTest.EnterToRequest(lNsiSuite.RequestId), "No enter into nsi request");

                string lLastId = "";

                // Execute test for every entity from test file
                foreach (NsiEntity lEntity in lNsiEntityList)
                {
                    // If entity id is "lastadd" then assign lId from lastId
                    if (lEntity.IdIsLastAdd())
                    {
                        if (lLastId.Length == 0)
                        {
                            Console.WriteLine("Skip test " + lEntity.ToString());
                            continue;
                        }
                        lEntity.Id = lLastId;
                    }
                    // Declare entity
                    EntityTestFactory entityTestFactory = new EntityTestFactory();

                    // Execute test for entity
                    string lAddId = entityTestFactory.Test(lEntity);

                    // Assign last entity id
                    if (lAddId.Length > 0)
                    {
                        lLastId = lAddId;
                    }
                }
            }
            else
            {
                Assert.Fail("Пустой файл данных \"" + pFileName + "\"");
            }
        }

        [Test]
        // Unit test
        public void UnitPositiveTestSuit()
        {
            Console.WriteLine("Start Unit test");

            EntityTestByFile("UnitData.xml");
        }

        [Test]
        // Class test
        public void ClassPositiveTestSuit()
        {
            Console.WriteLine("Start Class test");

            EntityTestByFile("ClassData.xml");
        }

        [Test, Description("sinple class test")]
        // Class test
        public void SimpleClassPositiveTestSuit()
        {
            Console.WriteLine("Start Class test");
            EntityTestByFile("ClassData2.xml");
        }

        [Test]
        //[Ignore("Ignore a test")]
        // Attibute Class test
        public void AttibuteClassPositiveTestSuit()
        {
            Console.WriteLine("Start Attibute Class test");

            EntityTestByFile("AttrClassData.xml");
        }

        [Test]
        // Attibute Class test
        public void AttibuteClassRefClassPositiveTestSuit()
        {
            Console.WriteLine("Start Attibute Class test");

            EntityTestByFile("AttrClassData_RefClass.xml");
        }

        [Test]
        public void ParameterClassPositiveTestSuit()
        {
            Console.WriteLine("Start Parameter Class test");

            EntityTestByFile("ParamClassData.xml");
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