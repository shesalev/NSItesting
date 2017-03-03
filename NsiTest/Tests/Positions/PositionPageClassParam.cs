using System;
using NsiTest.Pages.NoModalPage;

namespace NsiTest.Tests.Positions
{
    public class PositionPageClassParam : PositionPageAction
    {
        public PositionPageClassParam(NoModalPage pPage) : base(pPage)
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
                page.clkParamClassTab();
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
