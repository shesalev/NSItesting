using System;
using NsiTest.Pages.NoModalPage;

namespace NsiTest.Tests.Positions
{
    public static class PositionEntityAction
    {
        public static void setPosition(NoModalPage pEntityPage,string pEntityId) {
            Console.WriteLine("Go to entity");

            pEntityPage.SearchByIdGuid(pEntityId);
        }
    }
}
