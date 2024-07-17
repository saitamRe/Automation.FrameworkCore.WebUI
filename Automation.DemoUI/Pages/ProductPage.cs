using Automation.DemoUI.DataTables;
using Automation.DemoUI.WebAbstraction;
using Automation.DemoUI.WebAbstractions.ISteps;
using Automation.FrameworkCore.WebUI.Abstractions;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Automation.DemoUI.Pages
{
    public class ProductPage : IProductPage
    {
        readonly IDrivers _drivers;
        readonly IAtConfig _config;
        readonly ILogging _logger;
        ScenarioContext _scenarioContext;

        By ProductsListLocator = By.XPath("//div[@class='inventory_list']/div");
        By ProductTitleLocator(int index) => By.XPath($"//div[@class='inventory_list']/div[{index}]//div[@class='inventory_item_name ']");
        By ProductPriceLocator(int index) => By.XPath($"//div[@class='inventory_list']/div[{index}]//div[@class='inventory_item_price']");
        By AddCartBtnLocator(int index) => By.XPath($"//div[@class='inventory_list']/div[{index}]/div[@class='inventory_item_description']//button");

        By ShoppingCartBadgeLocator = By.XPath("//div[@id='shopping_cart_container']//span");

        By CartContainerLocator = By.XPath("//div[@id='shopping_cart_container']//a[@class='shopping_cart_link']");


        IAtWebElement ProductList => _drivers.FindElement(ProductsListLocator);
        IAtWebElement ProductTitle(int index) => _drivers.FindElement(ProductTitleLocator(index));
        IAtWebElement ProductPrice(int index) => _drivers.FindElement(ProductPriceLocator(index));
        IAtWebElement AddCartBtn(int index) => _drivers.FindElement(AddCartBtnLocator(index));
        IAtWebElement ShoppingCartBadge => _drivers.FindElement(ShoppingCartBadgeLocator);
        IAtWebElement CartContainer => _drivers.FindElement(CartContainerLocator);

        public ProductPage(IAtConfig atConfig, IDrivers idrivers, ILogging logging, ScenarioContext sc)
        {
            _logger = logging;
            _config = atConfig;
            _drivers = idrivers;
            _scenarioContext = sc;
        }

        public void VerifyProductItems(Table table)
        {
            Table tableProducts = new Table(new string[] { "Item", "Price" });

            int productCount = ProductList.NumberOfElement;

            for (int i = 1; i <= productCount; i++)
            {
                tableProducts.AddRow(ProductTitle(i).GetText(), ProductPrice(i).GetText());
            }
            Assert.That(0, Is.EqualTo(tableProducts.ToProjection<ProductItem>().Except(table.ToProjection<ProductItem>()).Count()));

        }

        public void CartItems(IList<string> itemsTable)
        {
            CartUncartItems(itemsTable, "Remove");
            _scenarioContext["cartItems"] = itemsTable;
        }
        
        public void MatchCartItems()
        {
            IList<string> cartItems = (IList<string>)_scenarioContext["cartItems"];
            Assert.That(int.Parse(ShoppingCartBadge.GetText()), Is.EqualTo(cartItems.Count));  
        }

        public void UncartItems(IList<string> cartItems)
        {
            CartUncartItems(cartItems, "Add to cart");
        }

        public void CartIsEmptyCheck()
        {
            Assert.IsEmpty(CartContainer.GetText().Trim());
        }

        private void CartUncartItems(IList<string> itemsTable, string label)
        {
           
            for (int i = 1; i <= ProductList.NumberOfElement; i++)
            {
                if (itemsTable.Contains(ProductTitle(i).GetText().Trim()))
                {
                    AddCartBtn(i).Click();
                    Thread.Sleep(2000);
                    Assert.That(label, Is.EqualTo(AddCartBtn(i).GetText().Trim()));
                }
            }

            
        }

        //public void UncartItems(Table itemsTable)
        //{
        //    IList<string> itemsList = itemsTable.Rows.Select(row => row["Items"]).ToList();
        //    for (int i = 1; i <= ProductList.NumberOfElement; i++)
        //    {
        //        if (itemsList.Contains(ProductTitle(i).GetText().Trim()))
        //        {
        //            AddCartBtn(i).Click();
        //            Thread.Sleep(2000);
        //            Assert.That("Add to cart", Is.EqualTo(AddCartBtn(i).GetText().Trim()));
        //        }
        //    }
        //    _scenarioContext["cartItemsToRemove"] = itemsTable;
        //}

        //public void MatchRemovedCardItems()
        //{
        //    IList<string> items =(IList<string>)_scenarioContext["cartItemsToRemove"];
        //    Assert.That(int.Parse(ShoppingCartBadge.GetText()), Is.EqualTo(items.Count));
        //}

    }
}

