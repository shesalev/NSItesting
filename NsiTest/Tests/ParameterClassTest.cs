using NsiTest.Fields;
using NsiTest.Pages.NoModalPage;
using NsiTest.Tests.Positions;
using NsiTest.Pages.AddPageAction;

namespace NsiTest.Tests
{
    public class ParameterClassTest : EntityTest
    {

        public ParameterClassTest(NsiEntity pEntity) : base(pEntity)
        {
            setPositionPageAction(new PositionPageClassParam/*PositionPageClassParamExt*/(NoModalPage.GetCurrentPage()));
            setPosition();
        }

        protected override void ClkOpenCreateModal()
        {
            AddParamClassPageAction AddParamClassPage = (AddParamClassPageAction)EntityPage;
            AddParamClassPage.clkCreateParameterClass();
        }
    }
}
