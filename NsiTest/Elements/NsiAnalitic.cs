using NsiTest.Fields;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace NsiTest.Elements
{
    /// <summary>
    /// Set value analitic/period table
    /// </summary>
    public class NsiAnalitic : NsiElement
    {
        public NsiAnalitic(IWebElement pElement) : base(pElement)
        {
        }

        public override void SetValue(NsiElementFieldValue pValue)
        {
            var lNewList = pValue.GetNsiAnlPerValueList();

            NsiAnlPerElement lAnlPer = new NsiAnlPerElement();

            // Create array to unset
            IEnumerable<NsiAnlPer> lDelList = lAnlPer.AnlPerList.Except(lNewList, new NsiAnlPerComparer());

            // Unset analitic values
            foreach (var analiticEl in lDelList)
            {
                lAnlPer.SetSelectNullValue(analiticEl);
            }

            // Set analitic values
            foreach (var analiticEl in lNewList/*lAddList*/)
            {
                lAnlPer.SetSelectValue(analiticEl);
            }
        }
    }
}