using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using Swd.Core.WebDriver;
using NsiTest.Fields;
using NsiTest.Elements;

namespace NsiTest.Pages.ModalPage
{
    public class DefaultModalPage : ModalPage
    {
        private NsiElementFactory nsiElementFactory;

        public DefaultModalPage()
        {
            nsiElementFactory = new NsiElementFactory();
        }

        // Fill all fields on modal form
        public void FillForm(IList<NsiElementField> pFieldsList)
        {
            foreach (NsiElementField lField in pFieldsList)
            {
                IWebElement pageInputEl = FindElement(By.Id(lField.getId())).WaitUntilVisible(TimeSpan.FromSeconds(10));
                //pageInputEl.;
               
                NsiElement nsiEl = nsiElementFactory.CreateNsiElement(pageInputEl);

                nsiEl.setValue(lField.getValue());
            }
        }
    }
}
