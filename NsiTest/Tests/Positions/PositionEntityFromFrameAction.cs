﻿using System;
using OpenQA.Selenium;
using Swd.Core.WebDriver;
using NsiTest.Exceptions;
using NsiTest.Pages.ModalPage;

namespace NsiTest.Tests.Positions
{
    public static class PositionEntityFromFrameAction
    {
        public static string GetEditViewBtnSelector(string pValue)
        {
            return ".//a[@value='" + pValue + "' and contains(@class,'edit_view_modal')]";
        }
        public static void setPosition(string pEntityId) {
            //Console.WriteLine("find entity by id = " + pEntityId);
            //Console.WriteLine(SwdBrowser.Driver.FindElement(By.XPath(GetEditViewBtnSelector(pEntityId))).TagName);
            if (!SwdBrowser.Driver.FastVisibleElement(By.XPath(GetEditViewBtnSelector(pEntityId))))
            {
                try
                {
                    //IJavaScriptExecutor js = Driver as IJavaScriptExecutor;
                    //string title = (string)js.ExecuteScript("$.event.trigger('open_search'," + idGuid + ");");
                    SwdBrowser.ExecuteScript("$.event.trigger('open_search','" + pEntityId + "');");
                }
                catch (Exception e)
                {
                    throw new GlobalSearchPageError("Open global search error: " + e.Message);
                }

                SearchModalPage searchModalPage = new SearchModalPage();

                searchModalPage.WaitLoading();

                searchModalPage.clkRedirectBtn();
            }
        }
    }
}
