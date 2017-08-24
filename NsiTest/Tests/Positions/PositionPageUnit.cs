using System;
using NsiTest.Pages.NoModalPage;

namespace NsiTest.Tests.Positions
{
    public class PositionPageUnit : PositionPageAction
    {
        public PositionPageUnit(NoModalPage pPage) : base(pPage)
        {
        }

        public override NoModalPage set(string pEntityId, string pParentId)
        {
            Console.WriteLine("PositionPageUnit");

            CurPage.goToSettings();

            SettingsTabPage settingsPage = new SettingsTabPage();

            settingsPage.clkGoToUnits();

            UnitPage page = new UnitPage();

            if (pEntityId.Length > 0)
            {
                page.selectUnitInTree(pEntityId);
            }
            else
            {
                page.selectUnitInTree(pParentId);
            }

            return page;
        }
    }
}
