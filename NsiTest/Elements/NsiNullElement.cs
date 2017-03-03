using OpenQA.Selenium;
using NsiTest.Fields;

namespace NsiTest.Elements
{
    public class NsiNullElement : NsiElement
    {
        public NsiNullElement(IWebElement pElement): base(pElement)
        {
        }
        override
        public void SetValue(NsiElementFieldValue pValue)
        {
        }
    }
}
