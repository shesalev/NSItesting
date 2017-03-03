using NsiTest.Tests;
using System;
using System.Xml.Linq;

namespace NsiTest.Fields
{
    public class NsiElementFieldValue
    {

        public NsiElementFieldValue(XElement pElement)
        {
            Element = pElement;
        }

        public XElement Element
        {
            get;
            private set;
        }        

        public override string ToString()
        {
            Console.WriteLine("NsiElementFieldValue ToString");
            Console.WriteLine(Element);
            Console.WriteLine(LoadData.GetValue(Element));
            return LoadData.GetValue(Element);
        }
    }
}