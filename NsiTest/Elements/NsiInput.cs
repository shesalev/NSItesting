using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Swd.Core.WebDriver;

namespace NsiTest.Elements
{
    public class NsiInput : NsiElement
    {
        public NsiInput(IWebElement pElement): base(pElement){}

        override
        public void setValue(String pValue)
        {
            Element.Clear();
            Element.SendKeys(pValue);
        }
    }
}
