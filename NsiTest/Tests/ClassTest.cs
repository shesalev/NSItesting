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
        private string ClassId;

        public ClassTest(string pEntityId, IList<NsiElementField> pFieldsList) : base(pEntityId, pFieldsList)
        {
            this.ClassId = pEntityId;
            
            base.setPositionPageAction(new PositionPageClass());
            base.setPositionEntityAction(new PositionEntityClass());
        }

        private ClassPage OpenModal()
        {
            ClassPage classPage = new ClassPage();
            classPage.clkOpenClassModal(ClassId);

            return classPage;
        }        

        override
        public String Add(IList<NsiElementField> pFieldsList)
        {
            String l_class_id = "";

            ClassPage classPage = new ClassPage();
            classPage.clkCreateClassModal();

            DefaultModalPage defaultModalPage = new DefaultModalPage();

            // Fill form

            defaultModalPage.FillForm(pFieldsList);
            defaultModalPage.Add();

            // TODO: Edit page 30 by action "Add class"
            //classPage.CheckSuccessMess();

            l_class_id = classPage.GetLastAddEntityId();

            Console.WriteLine(l_class_id);

            setPosition(l_class_id);

            //classPage.chkAddIcon(l_class_id);

            classPage.clkOpenClassModal(l_class_id);

            //this.ClassId = l_class_id;

            return l_class_id;
        }

        override
        public void Edit(IList<NsiElementField> pFieldsList)
        {
            ClassPage classPage = OpenModal();

            DefaultModalPage defaultModalPage = new DefaultModalPage();

            // Fill form
            defaultModalPage.FillForm(pFieldsList);

            defaultModalPage.Edit();

            classPage.CheckSuccessMess();
        }

        override
        public void Repair(IList<NsiElementField> pFieldsList)
        {
            ClassPage classPage = OpenModal();

            DefaultModalPage defaultModalPage = new DefaultModalPage();

            // Fill form
            defaultModalPage.FillForm(pFieldsList);

            defaultModalPage.Repair();
        }

        override
        public void Delete()
        {
            ClassPage classPage = OpenModal();

            DefaultModalPage defaultModalPage = new DefaultModalPage();

            defaultModalPage.Delete();

            // TODO: Edit page 30 by action "Delete class"
            //classPage.CheckSuccessMess();
        }

        public void View()
        {
            ClassPage classPage = OpenModal();

            DefaultModalPage defaultModalPage = new DefaultModalPage();

            defaultModalPage.Cancel();
        }
    }
}
