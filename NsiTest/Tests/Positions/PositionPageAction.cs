using NsiTest.Pages.NoModalPage;

namespace NsiTest.Tests.Positions
{
    public abstract class PositionPageAction
    {
        protected NoModalPage CurPage;

        public PositionPageAction(NoModalPage pPage)
        {
            this.CurPage = pPage;
        }

        public abstract NoModalPage set(string pEntityId, string pParentId);
    }
}
