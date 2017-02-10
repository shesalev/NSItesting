﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace NsiTest.Elements
{
    public class ErrorPageMessage
    {
        public static String GetMessage(IWebElement pElem) {
            var mess = pElem.Text;
            var brPosition = mess.IndexOf("<br>");
            if (brPosition >= 0)
            {
                mess = mess.Substring(0, mess.IndexOf("<br>"));
            }
            Console.WriteLine(mess);
            return mess;
        }
    }
}
