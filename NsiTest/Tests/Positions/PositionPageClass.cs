using System;
using NsiTest.Pages.NoModalPage;

namespace NsiTest.Tests.Positions
{
    public class PositionPageClass : PositionPageAction
    {
        public PositionPageClass(NoModalPage pPage) : base(pPage)
        {
        }

        public override void set(string pEntityId, string pParentId)
        {
            Console.WriteLine("PositionPageClass");

            CurPage.goToClasses();

            ClassTabPage page = new ClassTabPage();

            if (pEntityId.Length > 0)
            {
                page.selectClassInTree(pEntityId);
            }
            else
            {
                page.selectClassInTree(ClassTabPage.C_CLASS_FOLDER_ID);
            }
        }
    }
}
