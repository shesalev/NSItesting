using NsiTest.Fields;
using NsiTest.Pages.NoModalPage;
using NsiTest.Tests.Positions;
using NsiTest.Pages.AddPageAction;

namespace NsiTest.Tests
{
    public class AttributeClassTest : EntityTest
    {

        public AttributeClassTest(NsiEntity pEntity) : base(pEntity)
        {
            setPositionPageAction(new PositionPageClassAttr/*PositionPageClassAttrExt*/(NoModalPage.GetCurrentPage()));
            setPosition();
        }

        protected override void ClkOpenCreateModal()
        {
            AddAttrClassPageAction AddAttrClassPage = (AddAttrClassPageAction)EntityPage;
            AddAttrClassPage.clkCreateAttributeClass();
        }
    }
}
