using NsiTest.Fields;
using NsiTest.Pages.NoModalPage;
using NsiTest.Pages.ModalPage;
using NsiTest.Tests.Positions;
using NsiTest.Pages.AddPageAction;

namespace NsiTest.Tests
{
    public class AttributeClassTest : EntityTest
    {
        private AddAttrClassPageAction AddAttrClassPage;

        public AttributeClassTest(NsiEntity pEntity) : base(pEntity)
        {
            this.setPositionPageAction(new PositionPageClassAttr/*PositionPageClassAttrExt*/(NoModalPage.GetCurrentPage()));
            this.setPosition();
            this.AddAttrClassPage = (AddAttrClassPageAction)this.EntityPage;
        }        

        protected override void ClkOpenCreateModal()
        {
            AddAttrClassPage.clkCreateAttributeClass();
        }
    }
}
