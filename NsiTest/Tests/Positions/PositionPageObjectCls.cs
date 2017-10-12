using System;
using NsiTest.Fields;
using NsiTest.Pages.NoModalPage;
using NsiTest.Tests.Positions;
using NsiTest.Pages.AddPageAction;

namespace NsiTest.Tests.Positions
{
    public class PositionPageObjectCls : PositionPageAction
    {
        public PositionPageObjectCls(NoModalPage pPage) : base(pPage)
        {
        }

        public override NoModalPage set(string pEntityId, string pParentId)
        {
            Console.WriteLine("PositionPageClassParam");

            if (pParentId.Length > 0)
            {
                PositionPageClass ClassPos = new PositionPageClass(CurPage);
                ClassPos.set(pParentId, "");
                ClassTabPage page = new ClassTabPage();
                page.clkObjectTab();
                return page;
            }
            else
            {
                //throw new Exception("Null value in pParentId");
                CurPage.SearchByIdGuid(pEntityId);
                return new ClassTabPage();
            }


        }
    }
}
