using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace NsiTest.Elements
{
    internal class NsiSelectList : NsiElement
    {
        public NsiSelectList(IWebElement pElement) : base(pElement)
        {
        }

        public override void setValue(string pValue)
        {
            SelectElement selectList = new SelectElement(Element);
            selectList.SelectByValue(pValue);
        }
    }
}