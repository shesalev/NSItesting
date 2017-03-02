using System.Collections;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;

namespace NsiTest.Elements
{
    /// <summary>
    /// NsiIdList set value for page element with list of id
    /// </summary>
    public class NsiIdList : NsiElement
    {
        /// <summary>
        /// Default separator for <see cref=" SetValue"/> methods
        /// </summary>
        private char C_SEPARATOR = ':';

        public NsiIdList(IWebElement pElement) : base(pElement) { }

        /// <summary>
        /// Add values to page element with list of id
        /// </summary>
        /// <param name="pTableIdList">List of Id for delete</param>
        /// <param name="pArr">List of Id for add</param>
        private void AddRowsByIdList(IWebElement pTableIdList, IList pArr)
        {
            foreach (string lId in pArr)
            {
                pTableIdList.FindElement(By.Id("btn_add_to_selected")).Click();

                InteractiveReport lIR = new InteractiveReport();

                lIR.ClearFilter();

                lIR.SearchText(lId);

                FindElementBy(By.ClassName("apply_btn")).Click();
            }
        }

        /// <summary>
        /// Delete values from page element with list of id
        /// </summary>
        /// <param name="pArr">List of Id for delete</param>
        private void DelRowsByIdList(IList pArr)
        {
            foreach (string lDelId in pArr)
            {
                FindElementsFirstVisible(By.XPath(".//a[@value='" + lDelId + "']")).Click();
            }
        }

        /// <summary>
        /// Set value for page element with list of id
        /// </summary>
        /// <param name="pValue">List of Id</param>
        public override void SetValue(string pValue)
        {
            List<string> lAddIdList = pValue.Split(C_SEPARATOR).ToList();
            List<string> lDelIdList = new List<string>();

            IWebElement lTableIdList = FindElementBy(By.ClassName("modal_window_id_list_region"));

            IList<IWebElement> lRowList = lTableIdList.FindElements(By.CssSelector("a.nsi-del-refclass"));

            foreach (IWebElement lRow in lRowList)
            {
                string lVal = lRow.GetAttribute("value");

                if (lAddIdList.IndexOf(lVal) >= 0)
                {
                    lAddIdList.Remove(lVal);
                }
                else
                {
                    lDelIdList.Add(lVal);
                }
            }

            DelRowsByIdList(lDelIdList);

            AddRowsByIdList(lTableIdList, lAddIdList);
        }
    }
}