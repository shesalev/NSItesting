using System;
using System.Collections.Generic;
using NsiTest.Pages.NoModalPage;
using NsiTest.Pages.ModalPage;
using NsiTest.Tests.Positions;
using NsiTest.Fields;

namespace NsiTest.Tests
{
    public class ClassTest : EntityTest
    {
        private ClassTabPage classTabPage;

        public ClassTest(NsiEntity pEntity) : base(pEntity)
        {
            this.classTabPage = new ClassTabPage();
            base.setPositionPageAction(new PositionPageClass(this.classTabPage));
        }

        public override string Add(IList<NsiElementField> pFieldsList)
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
            setPosition();

            //classPage.chkAddIcon(l_class_id);

            return l_class_id;

        }

        public override void Edit(IList<NsiElementField> pFieldsList)
        {
            OpenAndFillModal(classTabPage, this.EntityId, pFieldsList).Edit();
        }

        public override void Repair(IList<NsiElementField> pFieldsList)
        {
            OpenAndFillModal(classTabPage, this.EntityId, pFieldsList).Repair();
        }

        public override void Delete()
        {
            OpenAndFillModal(classTabPage, this.EntityId, new List<NsiElementField>()).Delete();
        }

        public void View()
        {
            OpenAndFillModal(classTabPage, this.EntityId, new List<NsiElementField>()).Cancel();
        }
    }
}
