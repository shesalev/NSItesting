using System;
using System.Collections.Generic;

using NsiTest.Tests.Positions;
using NsiTest.Fields;
using NsiTest.Pages.NoModalPage;
using NsiTest.Pages.ModalPage;

namespace NsiTest.Tests
{
    public abstract class EntityTest
    {
        ////protected NoModalPage EntityPage;
        protected string EntityId;
        protected IList<NsiElementField> fieldsList;

        protected PositionPageAction positionPageAction;
        //protected PositionEntityAction positionEntityAction;

        public EntityTest(string pEntityId, IList<NsiElementField> pFieldsList)
        {
            this.EntityId = pEntityId;
            this.fieldsList = pFieldsList;
        }

        // Установка объекта позиции
        public void setPositionPageAction(PositionPageAction positionPageAction)
        {
            this.positionPageAction = positionPageAction;
        }

        //public void setPositionEntityAction(PositionEntityAction positionEntityAction)
        //{
        //    this.positionEntityAction = positionEntityAction;
        //}

        public void setPosition()
        {
            positionPageAction.set();
        }

        public abstract void setPosition(String p_entity_id);

        public abstract String Add(IList<NsiElementField> pFieldsList);

        public abstract void Edit(IList<NsiElementField> pFieldsList);

        public abstract void Delete();

        public abstract void Repair(IList<NsiElementField> pFieldsList);
    }
}
