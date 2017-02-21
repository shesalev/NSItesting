using System;
using NsiTest.Pages.NoModalPage;

namespace NsiTest.Tests.Positions
{
    public class PositionPageClassAttrExt : PositionPageAction
    {
        public PositionPageClassAttrExt(NoModalPage pPage) : base(pPage)
        {
        }

        public override void set(string pEntityId, string pParentId)
        {
            Console.WriteLine("PositionPageClassAttr");
            
            if (pParentId.Length > 0)
            {
                PositionPageClass ClassPos = new PositionPageClass(CurPage);
                ClassPos.set(pParentId, "");
                ClassTabPage page = new ClassTabPage();
                page.clkAttrClassTab();
                page.clkAttrClsExtBtn();
            }
            else
            {
                //throw new Exception("Null value in pParentId");
                CurPage.SearchByIdGuid(pEntityId);
            }
        }
    }
}
