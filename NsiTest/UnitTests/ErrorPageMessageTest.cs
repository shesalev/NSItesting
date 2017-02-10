using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NsiTest.Elements;
using OpenQA.Selenium;
using System.Collections.ObjectModel;
using System.Drawing;

namespace NsiTest.UnitTests
{
    class NullWebElement : IWebElement
    {
        //public String Text;
        public NullWebElement(String pText)
        {
            this.Text = pText;
        }

        public bool Displayed
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool Enabled
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Point Location
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool Selected
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Size Size
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string TagName
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string Text
        {
            get;
            private set; 
        }        

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public void Click()
        {
            throw new NotImplementedException();
        }

        public IWebElement FindElement(By by)
        {
            throw new NotImplementedException();
        }

        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            throw new NotImplementedException();
        }

        public string GetAttribute(string attributeName)
        {
            throw new NotImplementedException();
        }

        public string GetCssValue(string propertyName)
        {
            throw new NotImplementedException();
        }

        public void SendKeys(string text)
        {
            throw new NotImplementedException();
        }

        public void Submit()
        {
            throw new NotImplementedException();
        }
    }

    [TestFixture]
    public class ErrorPageMessageTest
    {
        [Test]
        public void Test()
        {
            try
            {
               String mess;
                IWebElement elem = new NullWebElement("ывапр");
                
                mess = ErrorPageMessage.GetMessage(elem);

                Assert.True(mess.Equals("ывапр"));

                IWebElement elem2 = new NullWebElement("Класс с выбранным названием уже определен в системе<br><br>[Id класса =$CLASS_ID]<br>Рекомендации");
                mess = ErrorPageMessage.GetMessage(elem2);

                Assert.True(mess.Equals("Класс с выбранным названием уже определен в системе"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                Assert.That(false, e.Message);
            }
        }
    }
}
