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
            this.EntityPage = this.classTabPage;
            base.setPositionPageAction(new PositionPageClass(this.EntityPage));
        }

        public override string Add()
        {
            String l_class_id = "";

            classTabPage.clkCreateClassModal();

            DefaultModalPage defaultModalPage = new DefaultModalPage();

            // Fill form
            defaultModalPage.FillForm(this.FieldsList);
            defaultModalPage.Add();

            // Get last add id
            l_class_id = classTabPage.GetLastAddEntityId();

            this.EntityId = l_class_id;

            // Go to added class
            //setPosition();

            //classPage.chkAddIcon(l_class_id);

            return l_class_id;

        }        
    }
}
