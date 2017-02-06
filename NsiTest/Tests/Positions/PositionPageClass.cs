using System;
using NsiTest.Pages.NoModalPage;

namespace NsiTest.Tests.Positions
{
    public class PositionPageClass : PositionPageAction
    {
        public void set()
        {
            Console.WriteLine("Go to class entity");

            ClassPage classPage = new ClassPage();

            classPage.goToClasses();
        }
    }
}
