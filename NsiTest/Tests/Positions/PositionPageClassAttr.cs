using System;
using NsiTest.Pages.NoModalPage;

namespace NsiTest.Tests.Positions
{
    public class PositionPageClassAttr : PositionPageAction
    {
        public PositionPageClassAttr(NoModalPage pPage) : base(pPage)
        {
        }

        public override void set(string pEntityId, string pParentId)
        {
            Console.WriteLine("PositionPageClassAttr");

            CurPage.goToClasses();

            ClassTabPage page = new ClassTabPage();

            if (pParentId.Length > 0)
            {
                page.selectClassInTree(pParentId);
                page.clkAttrClassTab();
            }
            else
            {
                //throw new Exception("Null value in pParentId");
                page.SearchByIdGuid(pEntityId);
            }
        }
    }
}
