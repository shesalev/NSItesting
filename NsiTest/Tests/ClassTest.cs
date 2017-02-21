using System;
using System.Collections.Generic;
using NsiTest.Pages.NoModalPage;
using NsiTest.Pages.ModalPage;
using NsiTest.Tests.Positions;
using NsiTest.Fields;
using NsiTest.Pages.AddPageAction;

namespace NsiTest.Tests
{
    public class ClassTest : EntityTest
    {
        private AddClassPageAction AddClassAction;

        public ClassTest(NsiEntity pEntity) : base(pEntity)
        {
            ClassTabPage lClassTabPage = new ClassTabPage();
            this.EntityPage = lClassTabPage;
            this.AddClassAction = lClassTabPage;
            this.setPositionPageAction(new PositionPageClass(this.EntityPage));
            this.setPosition();
        }

        public override string Add()
        {
            String l_class_id = "";

            AddClassAction.clkCreateClass();

            DefaultModalPage defaultModalPage = new DefaultModalPage();

            // Fill form
            defaultModalPage.FillForm(this.FieldsList);
            defaultModalPage.Add();

            // Get last add id
            l_class_id = EntityPage.GetLastAddEntityId();

            //this.EntityId = l_class_id;

            // Go to added class
            //setPosition();

            //classPage.chkAddIcon(l_class_id);

            return l_class_id;

        }        
    }
}
