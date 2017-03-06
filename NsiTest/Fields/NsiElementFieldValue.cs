using NsiTest.Tests;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace NsiTest.Fields
{
    public class NsiElementFieldValue
    {
        public NsiElementFieldValue(XElement pElement)
        {
            Element = pElement;
        }

        public XElement Element { get; private set; }

        public string GetStringValue()
        {
            Console.WriteLine("NsiElementFieldValue ToString");
            Console.WriteLine(Element);
            Console.WriteLine(LoadData.GetValue(Element));
            return LoadData.GetValue(Element);
        }

        public NsiAnlPer[] GetNsiAnlPerValueList()
        {
            List<NsiAnlPer> lAnlPer = new List<NsiAnlPer>(); ;

            foreach (XElement analiticEl in Element.Elements(ResourceXmlTags.XmlTagAnalitic))
            {
                var periodEl = analiticEl.Element("period").Value;
                var optValue = analiticEl.Element("value").Value + "_" + analiticEl.Element("id").Value;
                lAnlPer.Add(new NsiAnlPer { Period = periodEl, Value = optValue });
            }

            return lAnlPer.ToArray();
        }
    }
}