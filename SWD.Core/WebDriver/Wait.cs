using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System.Diagnostics;

namespace Swd.Core.WebDriver
{
    public static class Wait
    {
//        public static IWebElement UntilVisible(By by, IWebDriver driver, TimeSpan timeOut)
//        {
//        try
//            {
//                IList<IWebElement> elements = driver.GetVisibleElements(by);

//                foreach (IWebElement element in elements)
//                {
//                    element.WaitUntilVisible(200);

//                    if (element.IsDisplayedSafe())
//                    {
//                        return element;
//                    }
//}
//                return null;
//            }
//            catch (Exception e)
//            {
//                // Empty; Ignored
//                return null;
//            }
//        }

        public static IWebElement UntilVisible(IWebElement element, TimeSpan timeOut)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            while (true)
            {
                Exception lastException = null;
                try
                {
                    if (element.Displayed)
                    {
                        return element;
                    }
                    System.Threading.Thread.Sleep(100);
                }
                catch (Exception e) { lastException = e; }

                if (sw.Elapsed > timeOut)
                {
                    string exceptionMessage = lastException == null ? "" : lastException.Message;
                    string errorMessage = string.Format("Wait.UntilVisible: Element was not displayed after {0} Milliseconds" +
                                                        "\r\n Error Message:\r\n{1}", timeOut.TotalMilliseconds, exceptionMessage);
                    throw new TimeoutException(errorMessage);
                }
            }
        }

        public static IWebElement UntilVisible(IWebElement element, int timeOutMilliseconds)
        {
            return UntilVisible(element, TimeSpan.FromMilliseconds(timeOutMilliseconds));
        }

        
        public static IWebElement UntilVisible(By by, IWebDriver driver, TimeSpan timeOut)
        {
            WebDriverWait wdWait = new WebDriverWait(driver, timeOut);
            wdWait.IgnoreExceptionTypes
            (
                typeof(ElementNotVisibleException),
                typeof(NoSuchElementException),
                typeof(StaleElementReferenceException)
            );

            return wdWait.Until(ExpectedConditions.ElementIsVisible(by));
        }

        public static IWebElement UntilVisible(By by, IWebDriver driver, int timeOutMilliseconds)
        {
            return UntilVisible(by, driver, TimeSpan.FromMilliseconds(timeOutMilliseconds));
        }

        public static IList<IWebElement> UntilListVisible(By by, IWebDriver driver, TimeSpan timeOut)
        {
            WebDriverWait wdWait = new WebDriverWait(driver, timeOut);
            wdWait.IgnoreExceptionTypes
            (
                typeof(ElementNotVisibleException),
                typeof(NoSuchElementException),
                typeof(StaleElementReferenceException)
            );

            return wdWait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(by));
        }

        public static bool UntilNotVisible(By by, IWebDriver driver, TimeSpan timeOut)
        {
            WebDriverWait wdWait = new WebDriverWait(driver, timeOut);
            wdWait.IgnoreExceptionTypes
            (
                typeof(ElementNotVisibleException),
                typeof(NoSuchElementException),
                typeof(StaleElementReferenceException)
            );

            return wdWait.Until(ExpectedConditions.InvisibilityOfElementLocated(by));
        }

        public static IWebDriver UntilFrameToBeAvailableAndSwitchToIt(By by, IWebDriver driver, TimeSpan timeOut)
        {
            WebDriverWait wdWait = new WebDriverWait(driver, timeOut);

            wdWait.IgnoreExceptionTypes
            (
                typeof(ElementNotVisibleException),
                typeof(NoSuchElementException),
                typeof(StaleElementReferenceException)
            );

            return wdWait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(by));
        }

        public static IWebDriver UntilFrameToBeAvailableAndSwitchToIt(string name, IWebDriver driver, TimeSpan timeOut)
        {
            WebDriverWait wdWait = new WebDriverWait(driver, timeOut);

            wdWait.IgnoreExceptionTypes
            (
                typeof(ElementNotVisibleException),
                typeof(NoSuchElementException),
                typeof(StaleElementReferenceException)
            );

            return wdWait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(name));
        }

        public static IAlert UntilAlert(IWebDriver driver, TimeSpan timeOut)
        {
            WebDriverWait wdWait = new WebDriverWait(driver, timeOut);

            wdWait.IgnoreExceptionTypes
            (
                typeof(ElementNotVisibleException),
                typeof(NoSuchElementException),
                typeof(StaleElementReferenceException)
            );

            return wdWait.Until(ExpectedConditions.AlertIsPresent());
        }
    }
}
