using System;
using NsiTest.Pages.NoModalPage;
using NsiTest.Pages.ModalPage;
using NsiTest.Tests.Positions;

namespace NsiTest.Tests
{
    public class ClassTest : EntityTest
    {
        private String ClassId = "1";

        private ClassPage OpenModal()
        {
            ClassPage classPage = new ClassPage();
            classPage.clkOpenClassModal(ClassId);

            return classPage;
        }

        public ClassTest()
        {
            base.setPositionPageAction(new PositionPageClass());
            base.setPositionEntityAction(new PositionEntityClass());
        }

        override
        public String Add(/*ArrayList<NsiElementField> pFieldsList*/)
        {
            ClassPage classPage = new ClassPage();
            classPage.clkCreateClassModal();

            DefaultModalPage defaultModalPage = new DefaultModalPage();

            // Fill form
            defaultModalPage.FillForm(/*pFieldsList*/);
            defaultModalPage.Add();

            classPage.CheckSuccessMess();

            String l_class_id = classPage.GetLastAddEntityId();

            Console.WriteLine(l_class_id);

            setPosition(l_class_id);

            //classPage.chkAddIcon(l_class_id);

            classPage.clkOpenClassModal(l_class_id);

            this.ClassId = l_class_id;

            return l_class_id;
        }

        override
        public void Edit(/*ArrayList<NsiElementField> pFieldsList*/)
        {
            ClassPage classPage = OpenModal();

            DefaultModalPage defaultModalPage = new DefaultModalPage();

            // Fill form
            defaultModalPage.FillForm(/*pFieldsList*/);

            defaultModalPage.Edit();

            classPage.CheckSuccessMess();
        }

        override
        public void Repair(/*ArrayList<NsiElementField> pFieldsList*/)
        {
            ClassPage classPage = OpenModal();

            DefaultModalPage defaultModalPage = new DefaultModalPage();

            // Fill form
            defaultModalPage.FillForm(/*pFieldsList*/);

            defaultModalPage.Repair();
        }

        override
        public void Delete()
        {
            ClassPage classPage = OpenModal();

            DefaultModalPage defaultModalPage = new DefaultModalPage();

            defaultModalPage.Delete();

            classPage.CheckSuccessMess();
        }

        public void View()
        {
            ClassPage classPage = OpenModal();

            DefaultModalPage defaultModalPage = new DefaultModalPage();

            defaultModalPage.Cancel();
        }
    }
}
