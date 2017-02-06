using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NsiTest.Pages.NoModalPage;
using Swd.Core.WebDriver;
using OpenQA.Selenium.Support.PageObjects;

namespace NsiTest.Pages
{
    public static class Page
    {
        private static T GetPage<T>() where T : new()
        {
            var page = new T();
            PageFactory.InitElements(SwdBrowser.Driver, page);
            return page;
        }

        public static RequestViewPage RequestView
        {
            get { return GetPage<RequestViewPage>(); }
        }

        public static RequestListPage RequestList
        {
            get { return GetPage<RequestListPage>(); }
        }
    }
}
