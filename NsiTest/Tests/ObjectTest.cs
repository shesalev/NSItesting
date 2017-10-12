using NsiTest.Fields;
using NsiTest.Pages.NoModalPage;
using NsiTest.Tests.Positions;
using NsiTest.Pages.AddPageAction;

namespace NsiTest.Tests
{
    class ObjectTest : EntityTest
    {
        public ObjectTest(NsiEntity pEntity) : base(pEntity)
        {
            setPositionPageAction(new PositionPageObjectCls/*PositionPageClassParamExt*/(NoModalPage.GetCurrentPage()));
            setPosition();
        }

        protected override void ClkOpenCreateModal()
        {
            //AddClassPageAction AddClassAction = (AddClassPageAction)EntityPage;
            //AddClassAction.clkCreateClass();
        }
        
    }

    


}
