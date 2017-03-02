using NsiTest.Tests.Positions;
using NsiTest.Fields;
using NsiTest.Pages.ModalPage;
using NsiTest.Pages.NoModalPage;

namespace NsiTest.Tests
{
    public abstract class EntityTest
    {
        protected NoModalPage EntityPage;

        private NsiEntity Entity;

        private PositionPageAction positionPageAction;

        public EntityTest(NsiEntity pEntity)
        {
            this.Entity = pEntity;
        }

        // Установка объекта позиции
        public void setPositionPageAction(PositionPageAction positionPageAction)
        {
            this.positionPageAction = positionPageAction;
        }

        public void setPosition()
        {
            this.EntityPage = positionPageAction.set(Entity.Id, Entity.ParentId);
        }

        //public void setPosition(String p_entity_id)
        //{
        //    //Console.WriteLine("setPosition to Id: " + p_entity_id);
        //    this.EntityId = p_entity_id;
        //    PositionEntityFromFrameAction.setPosition(p_entity_id);
        //}                

        // Open entity add modal page 
        protected abstract void ClkOpenCreateModal();

        private DefaultModalPage FillDefaultModalPage()
        {
            DefaultModalPage defaultModalPage = new DefaultModalPage();
            // Fill form
            defaultModalPage.FillForm(Entity.Fields);

            return defaultModalPage;
        }

        // Add entity
        //public abstract string Add();
        public string Add()
        {
            //string l_class_id = "";

            ClkOpenCreateModal();

            FillDefaultModalPage().Add();

            // Get last add id
            //l_class_id = EntityPage.GetLastAddEntityId();

            return EntityPage.GetLastAddEntityId();

            //this.EntityId = l_class_id;

            //classPage.chkAddIcon(l_class_id);

            //return l_class_id;
        }

        private DefaultModalPage OpenAndFillModal()
        {
            // Waiting for page to load
            EntityPage.WaitLoading();

            // Open modal form
            EntityPage.ClickEditViewModalByValue(Entity.Id);

            // Fill modal form
            return FillDefaultModalPage();
        }

        // Edit entity
        public void Edit()
        {
            OpenAndFillModal().Edit();
        }

        // Repair entity
        public void Repair()
        {
            OpenAndFillModal().Repair();
        }

        // Delete entity
        public void Delete()
        {
            OpenAndFillModal().Delete();
        }

        // View entity
        public void View()
        {
            OpenAndFillModal().Cancel();
        }
    }
}
