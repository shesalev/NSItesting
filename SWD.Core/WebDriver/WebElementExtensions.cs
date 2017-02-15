using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium.Support;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics;

namespace Swd.Core.WebDriver
{
    /// <summary>
    /// WebElementExtensions defines extension methods for IWebElement objects.
    /// Extend and simplify the functionality provided by WebDriver Core/Support libraries 
    /// </summary>
    public static class WebElementExtensions
    {
        /// <summary>
        /// Default timeout for <see cref=" WaitUntilVisible"/> methods
        /// </summary>
        public static int DefaultTimeOutMilliseconds = 8000;

        /// <summary>
        /// Waits until element is visible. Internally, uses element.Displayed with ignored WebDriver exceptions
        /// </summary>
        /// <returns></returns>
        public static IWebElement WaitUntilVisible(this IWebElement element, TimeSpan timeOut)
        {
            return Wait.UntilVisible(element, timeOut);
        }

        /// <summary>
        /// Waits until element is visible. Internally, uses element.Displayed with ignored WebDriver exceptions
        /// </summary>
        /// <returns></returns>
        public static IWebElement WaitUntilVisible(this IWebElement element, int timeOutMilliseconds)
        {
            return Wait.UntilVisible(element, TimeSpan.FromMilliseconds(timeOutMilliseconds));
        }

        /// <summary>
        /// Waits until element is visible. Internally, uses element.Displayed with ignored WebDriver exceptions
        /// </summary>
        /// <returns></returns>

        public static IWebElement WaitUntilVisible(this IWebElement element)
        {
            return Wait.UntilVisible(element, TimeSpan.FromMilliseconds(DefaultTimeOutMilliseconds));
        }

        /// <summary>
        /// Waits until frame is visible and switch to it
        /// </summary>
        public static IWebDriver UntilFrameToBeAvailableAndSwitchToIt(this IWebDriver driver, string name)
        {
            //IWebElement lFrame = driver.FindElements(name).First();
            return Wait.UntilFrameToBeAvailableAndSwitchToIt(name, driver, TimeSpan.FromMilliseconds(DefaultTimeOutMilliseconds));
            //return Wait.UntilFrameToBeAvailableAndSwitchToIt(by, driver, TimeSpan.FromMilliseconds(DefaultTimeOutMilliseconds));
        }

        /// <summary>
        /// Waits until frame is visible and switch to it
        /// </summary>
        public static IAlert UntilAlert(this IWebDriver driver)
        {
            return Wait.UntilAlert(driver, TimeSpan.FromMilliseconds(DefaultTimeOutMilliseconds));
        }

        /// <summary>
        /// Waits until frame is visible and switch to it
        /// </summary>
        public static bool FastVisibleElement(this IWebDriver driver, By by)
        {
            //driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMilliseconds(200));
            //IWebElement lElement = driver.FindElement(by);
            //driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMilliseconds(DefaultTimeOutMilliseconds));
            var res = true;
            try
            {
                Wait.UntilVisible(by, driver, TimeSpan.FromMilliseconds(200));
            }
            catch (/*OpenQA.Selenium.NoSuchElementException*/Exception e)
            {
                res = false;
            }
            return res;
            //return lElement;
            //return Wait.UntilFrameToBeAvailableAndSwitchToIt(by, driver, TimeSpan.FromMilliseconds(DefaultTimeOutMilliseconds));
        }

        public static IWebElement FindElementBy(this IWebDriver driver, By by, TimeSpan timeOut)
        {
            return Wait.UntilVisible(by, driver, timeOut);
        }

        public static IWebElement FindElementBy(this IWebDriver driver, By by)
        {
            return Wait.UntilVisible(by, driver, TimeSpan.FromSeconds(10));
        }

        /// <summary>
        /// Replaces WebDriver’s element.Text property. Gets value from 
        /// *input* and *select* tags rather than returning text inside those elements. 
        /// </summary>
        public static string GetElementText(this IWebElement element)
        {
            string result = "";
            string tag = element.TagName.ToLower();

            switch (tag)
            {
                case "input":
                    result = element.GetAttribute("value");
                    break;
                case "select":
                    result = new SelectElement(element).SelectedOption.Text;
                    break;
                default:
                    result = element.Text;
                    break;
            }
            return result;
        }

        /// <summary>
        /// Gets a value indicating whether or not this element is displayed.  
        /// This method  suppresses any WebDriver exceptions  
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static bool IsDisplayedSafe(this IWebElement element)
        {
            bool result = false;

            try
            {
                result = element.Displayed;
            }
            catch (Exception e)
            {

                // Empty; Ignored
            }
            return result;
        }

        /// <summary>
        /// Gets a value indicating whether or not this element is displayed.  
        /// This method  suppresses any WebDriver exceptions  
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static IWebElement GetFirstVisible(this IList<IWebElement> elements)
        {
            IWebElement result = null;

            foreach (IWebElement element in elements)
            {
                element.WaitUntilVisible(200);
                //element
                if (element.IsDisplayedSafe())
                {
                    return element;
                }
            }

            return result;
        }

        public static IList<IWebElement> GetVisibleElements(this IWebDriver driver, By by)
        {
            return Wait.UntilListVisible(by, driver, TimeSpan.FromSeconds(10));
        }

        public static IWebElement GetFirstVisible(this IWebDriver driver, By by)
        {
            try
            {
                IList<IWebElement> elements = driver.GetVisibleElements(by);

                foreach (IWebElement element in elements)
                {
                    element.WaitUntilVisible(200);
                    //element
                    if (element.IsDisplayedSafe())
                    {
                        return element;
                    }
                }
                return null;
            }
            catch (Exception e)
            {
                return null;
            }


        }

        /// <summary>
        /// Waits until element is visible and click it
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static IWebElement ClickWait(this IWebElement btn)
        {
            btn.WaitUntilVisible(TimeSpan.FromSeconds(10));

            btn.Click();
            return btn;
        }

        /// <summary>
        /// Waits until element is visible and click it
        /// </summary>
        /// <param name="btn"></param>
        /// <param name="timeOut"></param>
        /// <returns></returns>
        public static IWebElement ClickWait(this IWebElement btn, TimeSpan timeOut)
        {
            btn.WaitUntilVisible(timeOut);
            btn.Click();
            return btn;
        }

        /// <summary>
        /// Waits until element is visible and click it
        /// </summary>
        /// <param name="btn"></param>
        /// <param name="timeOut"></param>
        /// <returns></returns>
        public static IWebElement GetPatent(this IWebElement element)
        {
            return element.FindElement(By.XPath(".."));
        }

    }
}
