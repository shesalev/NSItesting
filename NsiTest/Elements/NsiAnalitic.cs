using System;
using OpenQA.Selenium;
using NsiTest.Fields;
using System.Xml.Linq;
using Swd.Core.WebDriver;
using OpenQA.Selenium.Support.UI;

namespace NsiTest.Elements
{
    public class NsiAnalitic : NsiElement
    {
        public NsiAnalitic(IWebElement pElement) : base(pElement) { }

        public override void SetValue(NsiElementFieldValue pValue)
        {
            var lElement = pValue.Element;

            foreach (XElement analiticEl in lElement.Elements("analitic"))
            {
                var periodEl = analiticEl.Element("period").Value;
                var optValue = analiticEl.Element("value").Value + "_" + analiticEl.Element("id").Value;

                var lAnlList = Element.FindElements(By.XPath(".//option[@value='" + optValue + "']"));

                foreach (IWebElement lAnl in lAnlList)
                {
                    SelectElement lSelectList = new SelectElement(lAnl.GetPatent());
                    var lPeriod = lAnl.GetPatent().GetPatent().GetAttribute("headers");

                    if (lPeriod.Equals(periodEl))
                    {
                        if (lSelectList.WrappedElement.IsDisplayedSafe())
                        {
                            lSelectList.SelectByValue(optValue);
                        }
                    }
                }
            }
        }

    }
}