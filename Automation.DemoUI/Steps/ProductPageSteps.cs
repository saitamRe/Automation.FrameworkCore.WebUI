using Automation.DemoUI.WebAbstractions.ISteps;
using TechTalk.SpecFlow;

namespace Automation.DemoUI.Steps
{
    [Binding]
    public class ProductPageSteps
    {
        IProductPage _productPage;

        public ProductPageSteps(IProductPage productPage)
        {
            _productPage = productPage;
        }


        [Then(@"User verifies all the products")]
        public void ThenUserVerifiesAllTheProducts(Table table)
        {
            _productPage.VerifyProductItems(table);
        }


        [When(@"User cart items from product list to cart")]
        public void WhenUserCartItemsFromProductListToCart(Table table)
        {
            _productPage.CartItems(table.Rows.Select(items => items["Items"].ToString()).ToList());
        }

        [Then(@"User checks count in cart of selected items")]
        public void ThenUserChecksCountInCartOfSelectedItems()
        {
            _productPage.MatchCartItems();
        }

        [When(@"User uncart items from product list")]
        public void WhenUserUncartItemsFromProductList(Table table)
        {
            _productPage.UncartItems(table.Rows.Select(items => items["Items"].ToString()).ToList());
        }

        [Then(@"user verifies no item in cart")]
        public void ThenUserVerifiesNoItemInCart()
        {
            _productPage.CartIsEmptyCheck();
        }

    }
}
