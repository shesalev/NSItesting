using System;
using NsiTest.Pages.NoModalPage;
using NsiTest.Pages.ModalPage;

namespace NsiTest.Tests.Positions
{
    public class PositionEntityClass : PositionEntityAction
    {
        public void set(String p_entity_id)
        {
            Console.WriteLine("Go to class entity");

            ClassPage classPage = new ClassPage();

            classPage.globalOpenSearch(p_entity_id);

            SearchModalPage searchModalPage = new SearchModalPage();

            searchModalPage.clkRedirectBtn();
        }
    }
}
