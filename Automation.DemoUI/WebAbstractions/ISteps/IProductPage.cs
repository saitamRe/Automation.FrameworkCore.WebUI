using TechTalk.SpecFlow;

namespace Automation.DemoUI.WebAbstractions.ISteps
{
    public interface IProductPage
    {
        void VerifyProductItems(Table table);
        void CartItems(IList<string> itemsTable);
        void UncartItems(IList<string> cartItems);
        void MatchCartItems();
        void CartIsEmptyCheck();
    }
}
