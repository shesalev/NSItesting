using System;
using NsiTest.Pages.NoModalPage;

namespace NsiTest.Tests.Positions
{
    public class PositionPageClassAttrExt : PositionPageAction
    {
        public PositionPageClassAttrExt(NoModalPage pPage) : base(pPage)
        {
        }

        public override NoModalPage set(string pEntityId, string pParentId)
        {
            Console.WriteLine("PositionPageClassAttr");
            
            if (pParentId.Length > 0)
            {
                PositionPageClass ClassPos = new PositionPageClass(CurPage);
                ClassTabPage page = (ClassTabPage)ClassPos.set(pParentId, "");                 
                page.clkAttrClassTab();
                page.clkAttrClsExtBtn();
                ArrtClassExtPage attrClassExtPage = new ArrtClassExtPage();
                return attrClassExtPage;
            }
            else
            {
                //throw new Exception("Null value in pParentId");
                CurPage.SearchByIdGuid(pEntityId);
                ClassTabPage page = new ClassTabPage();
                return page;
            }
        }
    }
}
