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
            if (pEntity.Type.Equals("unit"))
            {
                entityTest = new UnitTest(pEntity);
            }
            if (pEntity.Type.Equals("class"))
            {
                entityTest = new ClassTest(pEntity);
            }
            else if (pEntity.Type.Equals("attrclass"))
            {
                entityTest = new AttributeClassTest(pEntity);
            }
            else if (pEntity.Type.Equals("paramclass"))
            {
                entityTest = new ParameterClassTest(pEntity);
            }
            else {}

            return entityTest;
        }

        public string Test(NsiEntity pEntity)
        {
            // Get test entity
            EntityTest entityTest = CreateNsiElement(pEntity);

            Console.WriteLine("Test entity " + pEntity.ToString());

            // Do test action
            if (pEntity.ActionEquals("add"))
            {
                // entityTest.setPosition();
                return entityTest.Add();
            }
            else if (pEntity.ActionEquals("edit"))
            {
                // entityTest.setPosition();
                entityTest.Edit();
            }
            else if (pEntity.ActionEquals("delete"))
            {
                // entityTest.setPosition();
                entityTest.Delete();
            }
            else if (pEntity.ActionEquals("repair"))
            {
                // entityTest.setPosition();
                entityTest.Repair();
            }
            else
            { }

            return "";
        }
    }
}
