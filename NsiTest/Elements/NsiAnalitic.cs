using System;
using OpenQA.Selenium;
using NsiTest.Fields;
using System.Xml.Linq;
using Swd.Core.WebDriver;

namespace NsiTest.Elements
{
    public class NsiAnalitic : NsiElement
    {
        public NsiAnalitic(IWebElement pElement) : base(pElement)
        {
        }

        public override void SetValue(NsiElementFieldValue pValue)
        {
            var lElement = pValue.Element;
            Console.WriteLine("NsiAnalitic: "+ lElement.HasElements);

            foreach (XElement analiticEl in lElement.Elements("analitic"))
            {
                var idEl = analiticEl.Element("id").Value;
                var periodEl = analiticEl.Element("period").Value;
                var valueEl = analiticEl.Element("value").Value;
                Console.WriteLine("id: " + idEl);
                Console.WriteLine("period: " + periodEl);
                Console.WriteLine("value: " + valueEl);
                Console.WriteLine("option: " + valueEl + "_" + idEl);

                //SwdBrowser.Driver.FindElement(By.Id(pId))
                //Console.WriteLine(Driver.FindElements(By.XPath(".//option[@value='"+valueEl + "_" + idEl+"']")).Count);
                var lAnlList = Element.FindElements(By.XPath(".//option[@value='" + valueEl + "_" + idEl + "']"));
                Console.WriteLine(lAnlList.Count);
                foreach (IWebElement lAnl in lAnlList)
                {
                    Console.WriteLine(lAnl.GetPatent().GetAttribute("id"));
                }
            }            
        }

    }
}