using Automation.DemoUI.WebAbstractions.ISteps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

    }
}
