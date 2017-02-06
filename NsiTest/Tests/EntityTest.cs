using System;
using NsiTest.Tests.Positions;

namespace NsiTest.Tests
{
    public abstract class EntityTest
    {
        protected PositionPageAction positionPageAction;
        protected PositionEntityAction positionEntityAction;


        // Установка объекта позиции
        public void setPositionPageAction(PositionPageAction positionPageAction)
        {
            this.positionPageAction = positionPageAction;
        }

        public void setPositionEntityAction(PositionEntityAction positionEntityAction)
        {
            this.positionEntityAction = positionEntityAction;
        }

        public void setPosition()
        {
            positionPageAction.set();
        }

        public void setPosition(String p_entity_id)
        {
            positionEntityAction.set(p_entity_id);
        }


        public abstract String Add();

        public abstract void Edit();

        public abstract void Delete();

        public abstract void Repair();
    }
}
