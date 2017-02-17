
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
        public AttributeClassTest(string pParentId) : base()
        {
            this.classTabPage = new ClassTabPage();
            this.EntityPatentId = pParentId/*"100061273"*/;
            base.setPositionPageAction(new PositionPageClass());
        }

        public override void setPosition(String p_entity_id)
        {
            Console.WriteLine("setPosition to Id: " + p_entity_id);
            this.EntityId = p_entity_id;
            PositionEntityAction.setPosition(p_entity_id);
        }

        public override string Add(IList<NsiElementField> pFieldsList)
        {
            String l_class_id = "";

            classTabPage.selectClassInTree(this.EntityPatentId);

            classTabPage.clkAttrClassTab();

            classTabPage.clkCreateAttributeClassModal();

            DefaultModalPage defaultModalPage = new DefaultModalPage();

            // Fill form
            defaultModalPage.FillForm(pFieldsList);
            defaultModalPage.Add();

            // Get last add id
            l_class_id = classTabPage.GetLastAddEntityId();

            this.EntityId = l_class_id;

            //classPage.chkAddIcon(l_class_id);

            return l_class_id;
        }

        protected DefaultModalPage OpenAndFillModal(ClassTabPage pClassTabPage, string pEntity, IList<NsiElementField> pFieldsList)
        {
            // Open modal form
            pClassTabPage.clkEditViewClassModal(pEntity);

            DefaultModalPage defaultModalPage = new DefaultModalPage();

            // Fill form
            defaultModalPage.FillForm(pFieldsList);

            return defaultModalPage;
        }

        public override void Edit(IList<NsiElementField> pFieldsList)
        {
            OpenAndFillModal(classTabPage, this.EntityId, pFieldsList).Edit();

            //classPage.CheckSuccessMess();
        }

        public override void Repair(IList<NsiElementField> pFieldsList)
        {
            OpenAndFillModal(classTabPage, this.EntityId, pFieldsList).Repair();
        }

        public override void Delete()
        {
            OpenAndFillModal(classTabPage, this.EntityId, new List<NsiElementField>()).Delete();

            // TODO: Edit page 30 by action "Delete class"
            //classPage.CheckSuccessMess();
        }

        public void View()
        {
            OpenAndFillModal(classTabPage, this.EntityId, new List<NsiElementField>()).Cancel();
        }
    }
}
