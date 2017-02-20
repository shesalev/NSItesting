using System.Collections.Generic;
using NsiTest.Tests.Positions;
using NsiTest.Fields;
using NsiTest.Pages.ModalPage;
using NsiTest.Pages.NoModalPage;

namespace NsiTest.Tests
{
    public abstract class EntityTest
    {
        //protected NoModalPage EntityPage;
        protected string EntityId;
        protected string EntityPatentId;
        protected IList<NsiElementField> fieldsList;

        protected PositionPageAction positionPageAction;

        public EntityTest(NsiEntity pEntity)
        {
            this.EntityId = pEntity.Id;
            this.EntityPatentId = pEntity.ParentId;
            //this.fieldsList = pFieldsList;
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

        //public void setPositionEntityAction(PositionEntityAction positionEntityAction)
        //{
        //    this.positionEntityAction = positionEntityAction;
        //}

        //public abstract void setPosition();

        //public abstract void setPosition(String p_entity_id);

        protected DefaultModalPage OpenAndFillModal(NoModalPage pPage, string pEntity, IList<NsiElementField> pFieldsList)
        {
            pPage.WaitLoading();

            // Open modal form
            pPage.ClickEditViewModalByValue(pEntity);

            DefaultModalPage defaultModalPage = new DefaultModalPage();

            // Fill form
            defaultModalPage.FillForm(pFieldsList);

            return defaultModalPage;
        }

        public abstract string Add(IList<NsiElementField> pFieldsList);

        public abstract void Edit(IList<NsiElementField> pFieldsList);

        public abstract void Delete();

        public abstract void Repair(IList<NsiElementField> pFieldsList);
    }
}
