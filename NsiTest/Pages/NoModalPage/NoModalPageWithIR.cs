using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NsiTest.Elements;
using OpenQA.Selenium;

namespace NsiTest.Pages.NoModalPage
{
    public abstract class NoModalPageWithIR : NoModalPage
    {
        private InteractiveReport intReport = new InteractiveReport();

        public InteractiveReport GetIntReport()
        {
            return intReport;
        }
    }
}
