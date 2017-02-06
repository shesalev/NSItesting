using OpenQA.Selenium;
using Swd.Core.Pages;

namespace NsiTest.Elements
{
    public class MainTabElement : CorePage
    {
        public void goToRequests()
        {

            FindElement(By.Id("tab_Requests")).Click();
        }

        public void goToClasses()
        {
            FindElement(By.Id("tab_Classes")).Click();
        }

        public void goToObjects()
        {
            FindElement(By.Id("tab_Objects")).Click();
        }

        public void goToHier()
        {
            FindElement(By.Id("tab_Hier")).Click();
        }

        public void goToPipe()
        {
            FindElement(By.Id("tab_Pipe")).Click();
        }

        public void goToSearch()
        {
            FindElement(By.Id("tab_Search")).Click();
        }

        public void goToControl()
        {
            FindElement(By.Id("tab_Control")).Click();
        }

        public void goToSettings()
        {
            FindElement(By.Id("tab_Settings")).Click();
        }

        public void goToHelp()
        {
            FindElement(By.Id("tab_Help")).Click();
        }
    }

}
