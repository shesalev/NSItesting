using System;
using NsiTest.Pages.NoModalPage;

namespace NsiTest.Tests.Positions
{
    public class PositionPageClass : PositionPageAction
    {
        public void set()
        {
            Console.WriteLine("Go to class entity");

            ClassTabPage classPage = new ClassTabPage();

            classPage.goToClasses();

            //classPage.goToSearch();
        }
    }
}
