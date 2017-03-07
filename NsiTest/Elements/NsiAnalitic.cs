using OpenQA.Selenium;
using NsiTest.Fields;
using System.Linq;
using System.Collections.Generic;

namespace NsiTest.Elements
{
    public class NsiAnalitic : NsiElement
    {
        public NsiAnalitic(IWebElement pElement) : base(pElement) { }

        public override void SetValue(NsiElementFieldValue pValue)
        {
            var lNewList = pValue.GetNsiAnlPerValueList();

            NsiAnlPerElement lAnlPer = new NsiAnlPerElement();

            var lOldList = lAnlPer.AnlPerList;

            IEnumerable<NsiAnlPer> lDelList = lOldList.Except(lNewList, new NsiAnlPerComparer());

            // Set analitic values
            foreach (var analiticEl in lNewList/*lAddList*/)
            {
                lAnlPer.SetSelectValue(analiticEl);
            }

            // Unset analitic values
            foreach (var analiticEl in lDelList)
            {
                lAnlPer.SetSelectNullValue(analiticEl);
            }
        }
    }
}