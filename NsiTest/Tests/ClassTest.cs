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
            this.setPositionPageAction(new PositionPageClass(NoModalPage.GetCurrentPage()));
            this.setPosition();             
            this.AddClassAction = (AddClassPageAction)this.EntityPage;
        }

        protected override void ClkOpenCreateModal()
        {
            AddClassAction.clkCreateClass();
        }
    }
}
