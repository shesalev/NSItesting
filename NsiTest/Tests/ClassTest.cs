using System;
using System.Collections.Generic;
using NUnit.Framework;
using NsiTest.Pages.NoModalPage;
using NsiTest.Pages.ModalPage;
using NsiTest.Tests.Positions;
using NsiTest.Fields;

namespace NsiTest.Tests
{
    public class ClassTest : EntityTest
    {
        private ClassTabPage classTabPage;
        public ClassTest(/*string pEntityId, IList<NsiElementField> pFieldsList*/) : base(/*pEntityId, pFieldsList*/)
        {
            this.classTabPage = new ClassTabPage();
            base.setPositionPageAction(new PositionPageClass());
        }

        public override void setPosition(String p_entity_id)
        {
            this.EntityId = p_entity_id;
            PositionEntityAction.setPosition(p_entity_id);
        }

        override
        public String Add(IList<NsiElementField> pFieldsList)
        {
            String l_class_id = "";

            classTabPage.clkCreateClassModal();

            DefaultModalPage defaultModalPage = new DefaultModalPage();

            // Fill form
            defaultModalPage.FillForm(pFieldsList);
            defaultModalPage.Add();

            // Get last add id
            l_class_id = classTabPage.GetLastAddEntityId();

            this.EntityId = l_class_id;

            // Go to added class
            setPosition(l_class_id);

            //classPage.chkAddIcon(l_class_id);

            return l_class_id;

        }

        protected DefaultModalPage OpenAndFillModal(ClassTabPage pClassTabPage, string pEntity, IList<NsiElementField> pFieldsList)
        {
            pClassTabPage.WaitLoading();
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
