using System;
using OpenQA.Selenium;
using NsiTest.Fields;
using System.Xml.Linq;
using Swd.Core.WebDriver;
using OpenQA.Selenium.Support.UI;
using System.Linq;
using System.Collections.Generic;

namespace NsiTest.Elements
{
    public class NsiAnalitic : NsiElement
    {
        public NsiAnalitic(IWebElement pElement) : base(pElement) { }

        public override void SetValue(NsiElementFieldValue pValue)
        {
            var lElement = pValue.Element;

            var lNewList = pValue.GetNsiAnlPerValueList();

            NsiAnlPerElement lAnlPer = new NsiAnlPerElement();

            //var lOldList = Element.FindElements(By.XPath(".//option[string-length(@value) > 0 and @selected='selected']"));

            var lOldList = lAnlPer.AnlPerList;

            IEnumerable<NsiAnlPer> lAddList = lNewList.Except(lOldList, new NsiAnlPerComparer());

            Console.WriteLine("SetValue");
            Console.WriteLine(lAddList.Count());

            // Find all xml elements with tag "analitic"
            foreach (var analiticEl in lAddList /*lElement.Elements(ResourceXmlTags.XmlTagAnalitic)*/)
            {
                //var lAnlList = Element.FindElements(By.XPath(".//option[@value='" + analiticEl.Value + "']"));

                //foreach (IWebElement lAnl in lAnlList)
                //{
                //    SelectElement lSelectList = new SelectElement(lAnl.GetPatent());
                //    var lPeriod = lAnl.GetPatent().GetPatent().GetAttribute("headers");

                //    if (lPeriod.Equals(analiticEl.Period))
                //    {
                //        if (lSelectList.WrappedElement.IsDisplayedSafe())
                //        {
                //            lSelectList.SelectByValue(analiticEl.Value);
                //        }
                //    }
                //}
                lAnlPer.SetSelectValue(analiticEl);
            }

            IEnumerable<NsiAnlPer> lDelList = lOldList.Except(lNewList, new NsiAnlPerComparer());

            foreach (var analiticEl in lDelList /*lElement.Elements(ResourceXmlTags.XmlTagAnalitic)*/)
            {
                lAnlPer.SetSelectNullValue(analiticEl);
            }
        }
    }
}