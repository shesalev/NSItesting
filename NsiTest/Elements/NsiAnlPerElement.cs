using System;
using System.Collections.Generic;
using System.Linq;
using Swd.Core.Pages;
using Swd.Core.WebDriver;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using NsiTest.Fields;
using OpenQA.Selenium.Support.UI;

namespace NsiTest.Elements
{
    public class NsiAnlPerElement : CorePage
    {
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
