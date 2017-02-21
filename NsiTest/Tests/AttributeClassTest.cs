
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NsiTest.Fields;
using NsiTest.Pages.NoModalPage;
using NsiTest.Pages.ModalPage;
using NsiTest.Tests.Positions;

namespace NsiTest.Tests
{
    public class AttributeClassTest : EntityTest
    {
        private ClassTabPage classTabPage;

        public AttributeClassTest(NsiEntity pEntity) : base(pEntity)
        {
            this.classTabPage = new ClassTabPage();
            this.EntityPage = this.classTabPage;
            this.setPositionPageAction(new /*PositionPageClassAttr*/PositionPageClassAttrExt(this.EntityPage));
            this.setPosition();
        }

        public override string Add()
        {
            String l_class_id = "";

            classTabPage.selectClassInTree(this.EntityPatentId);

            classTabPage.clkAttrClassTab();

            classTabPage.clkCreateAttributeClass();

            DefaultModalPage defaultModalPage = new DefaultModalPage();

            // Fill form
            defaultModalPage.FillForm(this.FieldsList);
            defaultModalPage.Add();

            // Get last add id
            l_class_id = EntityPage.GetLastAddEntityId();

            this.EntityId = l_class_id;

            //classPage.chkAddIcon(l_class_id);

            return l_class_id;
        }
    }
}
