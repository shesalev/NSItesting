using NsiTest.Pages.NoModalPage;
using NsiTest.Tests.Positions;
using NsiTest.Fields;
using NsiTest.Pages.AddPageAction;

namespace NsiTest.Tests
{
    public class ClassTest : EntityTest
    {
        public ClassTest(NsiEntity pEntity) : base(pEntity)
        {
            setPositionPageAction(new PositionPageClass(NoModalPage.GetCurrentPage()));
            setPosition();
        }

        protected override void ClkOpenCreateModal()
        {
            AddClassPageAction AddClassAction = (AddClassPageAction)EntityPage;
            AddClassAction.clkCreateClass();
        }
    }
}
