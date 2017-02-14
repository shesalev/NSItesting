using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Xml.Linq;
using NsiTest.Fields;

namespace NsiTest.Tests
{
    public static class LoadData
    {
        public static IList<NsiEntityField> GetData(String pPathXMLFile)
        {
            IList<NsiEntityField> lEntity = new List<NsiEntityField>();
            try
            {
                string currDir = Environment.CurrentDirectory.ToString();

                XDocument lDoc = new XDocument(); //создаем класс XDocument

                lDoc = XDocument.Load(currDir + "\\DataTest\\" + pPathXMLFile);

                foreach (XElement suitEl in lDoc.Elements("suit"))
                {
                    var reqEl = suitEl.Element("request_id");
                    Console.WriteLine("{0}: {1}", reqEl.Name, reqEl.Value);

                    var entitysEl = suitEl.Element("entitys");

                    //выводим в цикле названия всех дочерних элементов и их значения
                    foreach (XElement entityEl in entitysEl.Elements("entity"))
                    {
                        var typeEl = entityEl.Element("type");
                        //Console.WriteLine("    {0}: {1}", typeEl.Name, typeEl.Value);

                        var idEl = entityEl.Element("id");
                        //Console.WriteLine("    {0}: {1}", idEl.Name, idEl.Value);

                        var actionEl = entityEl.Element("action");
                        //Console.WriteLine("    {0}: {1}", actionEl.Name, actionEl.Value);

                        var fieldsEl = entityEl.Element("fields");

                        IList<NsiElementField> lData = new List<NsiElementField>();

                        //выводим в цикле названия всех дочерних элементов и их значения
                        foreach (XElement fieldEl in fieldsEl.Elements("field"))
                        {
                            var nameEl = fieldEl.Element("name");
                            var valueEl = fieldEl.Element("value");
                            //Console.WriteLine("        {0}: {1}", nameEl.Name, nameEl.Value);
                            //Console.WriteLine("        {0}: {1}", valueEl.Name, valueEl.Value);
                            lData.Add(new NsiElementField(nameEl.Value, valueEl.Value));
                        }

                        lEntity.Add(new NsiEntityField(typeEl.Value, actionEl.Value, idEl.Value, lData));
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                Assert.True(false, "Error load data from xml");
            }
            return lEntity;
        }
    }

}
