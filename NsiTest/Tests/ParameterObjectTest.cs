using NsiTest.Fields;
using NsiTest.Pages.NoModalPage;
using NsiTest.Tests.Positions;
using NsiTest.Pages.AddPageAction;

namespace NsiTest.Tests
{
    public class ParameterObjectTest : EntityTest
    {

        public ParameterObjectTest(NsiEntity pEntity) : base(pEntity)
        {
            setPositionPageAction(new PositionPageClass(NoModalPage.GetCurrentPage()));
            setPosition();
        }

        protected override void ClkOpenCreateModal()
        {
            AddParamClassPageAction AddParamClassPage = (AddParamClassPageAction)EntityPage;
            AddParamClassPage.clkCreateParameterClass();
        }
    }
}
