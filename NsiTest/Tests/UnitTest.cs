using NsiTest.Pages.NoModalPage;
using NsiTest.Tests.Positions;
using NsiTest.Fields;
using NsiTest.Pages.AddPageAction;

namespace NsiTest.Tests
{
    public class UnitTest : EntityTest
    {
        public UnitTest(NsiEntity pEntity) : base(pEntity)
        {
            setPositionPageAction(new PositionPageUnit(NoModalPage.GetCurrentPage()));
            setPosition();
        }

        protected override void ClkOpenCreateModal()
        {
            UnitPage AddUnitAction = (UnitPage)EntityPage;
            AddUnitAction.clkCreateUnit();
        }
    }
}
