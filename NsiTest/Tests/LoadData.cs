using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Xml.Linq;
using NsiTest.Fields;

namespace NsiTest.Tests
{
    public static class LoadData
    {
        public static string GetValueByTagName(XElement pEntityEl, string pTagName)
        {
            try
            {
                return pEntityEl.Element(pTagName).Value;
            }catch(System.NullReferenceException e)
            {
                return "";
            }
        }

        public static NsiSuite GetData(String pPathXMLFile)
        {
            XDocument lDoc = new XDocument(); //создаем класс XDocument

            string currDir = Environment.CurrentDirectory.ToString();

            lDoc = XDocument.Load(currDir + "\\DataTest\\" + pPathXMLFile);

            var lEntity = new List<NsiEntity>();
            var reqEl = "";

            foreach (XElement suiteEl in lDoc.Elements("suit"))
            {
                reqEl = GetValueByTagName(suiteEl,"request_id");
                var entitysEl = suiteEl.Element("entitys");

                //выводим в цикле названия всех дочерних элементов и их значения
                foreach (XElement entityEl in entitysEl.Elements("entity"))
                {
                    // Try get value from xml tags
                    var typeVal = GetValueByTagName(entityEl, "type");
                    var idVal = GetValueByTagName(entityEl, "id");
                    var parentIdVal = GetValueByTagName(entityEl, "patentid");
                    var actionVal = GetValueByTagName(entityEl, "action");

                    // Get fields
                    var fieldsEl = entityEl.Element("fields");

                    var lData = new List<NsiElementField>();

                    // Выводим в цикле названия всех дочерних элементов и их значения
                    foreach (XElement fieldEl in fieldsEl.Elements("field"))
                    {
                        var nameEl = GetValueByTagName(fieldEl,"name");
                        var valueEl = GetValueByTagName(fieldEl,"value");
                        lData.Add(new NsiElementField(nameEl, valueEl));
                    }

                    lEntity.Add(new NsiEntity(typeVal, actionVal, idVal, parentIdVal, lData));
                }
            }
            return new NsiSuite(reqEl, lEntity) ;
        }
    }

}
