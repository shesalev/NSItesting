using System;
using NsiTest.Fields;
using NsiTest.Pages.NoModalPage;
using NsiTest.Exceptions;

namespace NsiTest.Tests
{
    public class RequestTest : EntityTest
    {
        public RequestTest(NsiEntity pEntity) : base(pEntity)
        {
        }

        protected override void ClkOpenCreateModal()
        {
        }

        // Enter to request
        public static bool EnterToRequest(String pRequestId)
        {
            // Search nsi request in IR on requests page
            var reqListPage = new RequestListPage();

            reqListPage.ContainsTitle();

            var ir = reqListPage.GetIntReport();

            ir.SearchText(pRequestId);

            ir.SelectRowByValue(pRequestId);

            // Enter into nsi
            var reqViewPage = new RequestViewPage();

            reqViewPage.ContainsTitle();

            reqViewPage.enterToNsi();

            return reqViewPage.IsEnterToRequest();
        }
    }
}
