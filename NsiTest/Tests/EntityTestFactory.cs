using NsiTest.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NsiTest.Tests
{
    public class EntityTestFactory
    {
        private EntityTest CreateNsiElement(NsiEntity pEntity)
        {
            EntityTest entityTest = null;

            // TODO: add other using types
            if (pEntity.Type.Equals("class"))
            {
                entityTest = new ClassTest(/*lId, lEntity.Fields*/);
            }
            else if (pEntity.Type.Equals("attrclass"))
            {
                entityTest = new AttributeClassTest(pEntity.ParentId);
            }
            else
            {
            }

            return entityTest;
        }

        public string Test(NsiEntity pEntity, string pId)
        {
            // Get test entity
            EntityTest entityTest = CreateNsiElement(pEntity);

            Console.WriteLine("Test entity " + pEntity.ToString());

            // Do test action
            if (pEntity.Action.Equals("add"))
            {
                entityTest.setPosition();
                return entityTest.Add(pEntity.Fields);
            }
            else if (pEntity.Action.Equals("edit"))
            {
                entityTest.setPosition(pId);
                entityTest.Edit(pEntity.Fields);
            }
            else if (pEntity.Action.Equals("delete"))
            {
                entityTest.setPosition(pId);
                entityTest.Delete();
            }
            else if (pEntity.Action.Equals("repair"))
            {
                entityTest.setPosition(pId);
                entityTest.Repair(pEntity.Fields);
            }
            else
            { }

            return "";
        }
    }
}
