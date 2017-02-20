using System.Collections.Generic;
using NsiTest.Tests.Positions;
using NsiTest.Fields;
using NsiTest.Pages.ModalPage;
using NsiTest.Pages.NoModalPage;

namespace NsiTest.Tests
{
    public abstract class EntityTest
    {
        protected NoModalPage EntityPage;
        protected string EntityId;
        protected string EntityPatentId;
        protected IList<NsiElementField> FieldsList;

        protected PositionPageAction positionPageAction;

        public EntityTest(NsiEntity pEntity)
        {
            this.EntityId = pEntity.Id;
            this.EntityPatentId = pEntity.ParentId;
            this.FieldsList = pEntity.Fields;
        }

        // Установка объекта позиции
        public void setPositionPageAction(PositionPageAction positionPageAction)
        {
            this.positionPageAction = positionPageAction;
        }

        public void setPosition()
        {
            positionPageAction.set(this.EntityId, this.EntityPatentId);
        }

        //public void setPosition(String p_entity_id)
        //{
        //    //Console.WriteLine("setPosition to Id: " + p_entity_id);
        //    this.EntityId = p_entity_id;
        //    PositionEntityFromFrameAction.setPosition(p_entity_id);
        //}        

        protected DefaultModalPage OpenAndFillModal()
        {

            EntityPage.WaitLoading();

            // Open modal form
            EntityPage.ClickEditViewModalByValue(this.EntityId);

            DefaultModalPage defaultModalPage = new DefaultModalPage();

            // Fill form
            defaultModalPage.FillForm(this.FieldsList);

            return defaultModalPage;
        }

        public abstract string Add();

        public void Edit()
        {
            OpenAndFillModal().Edit();
        }

        public void Repair()
        {
            OpenAndFillModal().Repair();
        }

        public void Delete()
        {
            OpenAndFillModal().Delete();
        }

        public void View()
        {
            OpenAndFillModal().Cancel();
        }
    }
}
