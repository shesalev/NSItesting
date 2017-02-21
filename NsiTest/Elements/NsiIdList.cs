using System;
using OpenQA.Selenium;

namespace NsiTest.Elements
{
    internal class NsiIdList : NsiElement
    {
        public NsiIdList(IWebElement pElement) : base(pElement)
        {
        }

        public override void setValue(string pValue)
        {
            var lIdList = pValue.Split(':');
            //"btn_add_to_selected"
            //"modal_window_id_list_region"
        }
    }
}