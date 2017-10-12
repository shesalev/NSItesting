﻿using NsiTest.Fields;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Swd.Core.Pages;
using Swd.Core.WebDriver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NsiTest.Elements
{
    /// <summary>
    /// For set values to analitic/period table
    /// </summary>
    public class NsiAnlPerElement : CorePage
    {
        /// <summary>
        /// Get current value list from analitic/period table
        /// </summary>
        public NsiAnlPer[] AnlPerList
        {
            get
            {
                List<NsiAnlPer> lAnlPer = new List<NsiAnlPer>();

                IList<IWebElement> selectedOptionWithValue = FindElements(By.XPath(".//option[string-length(@value) > 0 and @selected='selected']"));

                Console.WriteLine("AnlPerList selectedOptionWithValue");
                Console.WriteLine(selectedOptionWithValue.Count);

                foreach (IWebElement lSelectedOption in selectedOptionWithValue)
                {
                    SelectElement lSelectList = new SelectElement(lSelectedOption.GetPatent());
                    var lPeriod = lSelectedOption.GetPatent().GetPatent().GetAttribute("headers");

                    lAnlPer.Add(new NsiAnlPer { Period = lPeriod, Value = lSelectedOption.GetAttribute("value") });
                }

                Console.WriteLine("AnlPerList lAnlPer");
                Console.WriteLine(lAnlPer.Count);

                IEnumerable<NsiAnlPer> lDistinctAnlPer = lAnlPer.Distinct(new NsiAnlPerComparer());

                Console.WriteLine("AnlPerList lDistinctAnlPer");
                Console.WriteLine(lDistinctAnlPer.Count());

                return lDistinctAnlPer.ToArray();
            }
        }

        /// <summary>
        /// Set value to analitic/period select list
        /// </summary>
        /// <param name="analiticEl">analitic/period old value for find selectlist item</param>
        public void SetSelectValue(NsiAnlPer analiticEl)
        {
            var lAnlList = FindElements(By.XPath(".//option[@value='" + analiticEl.Value + "']"));

            foreach (IWebElement lAnl in lAnlList)
            {
                SelectElement lSelectList = new SelectElement(lAnl.GetPatent());
                var lPeriod = lAnl.GetPatent().GetPatent().GetAttribute("headers");

                if (lPeriod.Equals(analiticEl.Period))
                {
                    if (lSelectList.WrappedElement.IsDisplayedSafe())
                    {
                        lSelectList.SelectByValue(analiticEl.Value);
                    }
                }
            }
        }

        /// <summary>
        /// Set null value to analitic/period select list
        /// </summary>
        /// <param name="analiticEl">analitic/period old value for find selectlist item</param>
        public void SetSelectNullValue(NsiAnlPer analiticEl)
        {
            var lAnlList = FindElements(By.XPath(".//option[@value='" + analiticEl.Value + "']"));

            foreach (IWebElement lAnl in lAnlList)
            {
                SelectElement lSelectList = new SelectElement(lAnl.GetPatent());
                var lPeriod = lAnl.GetPatent().GetPatent().GetAttribute("headers");

                if (lPeriod.Equals(analiticEl.Period))
                {
                    if (lSelectList.WrappedElement.IsDisplayedSafe())
                    {
                        lSelectList.SelectByValue("");
                    }
                }
            }
        }
    }
}