using Automation.DemoUI.DataTables;
using Automation.DemoUI.WebAbstraction;
using Automation.DemoUI.WebAbstractions.ISteps;
using Automation.FrameworkCore.WebUI.Abstractions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Automation.DemoUI.Pages
{
    public class ProductPage : IProductPage
    {
        readonly IDrivers _drivers;
        readonly IAtConfig _config;
        readonly ILogging _logger;

        By ProductsListLocator = By.XPath("//div[@class='inventory_list']/div");
        By ProductTitleLocator(int index) => By.XPath($"//div[@class='inventory_list']/div[{index}]//div[@class='inventory_item_name ']");
        By ProductPriceLocator(int index) => By.XPath($"//div[@class='inventory_list']/div[{index}]//div[@class='inventory_item_price']");

        IAtWebElement ProductList => _drivers.FindElement(ProductsListLocator);
        IAtWebElement ProductTitle(int index) => _drivers.FindElement(ProductTitleLocator(index));
        IAtWebElement ProductPrice(int index) => _drivers.FindElement(ProductPriceLocator(index));

        public ProductPage(IAtConfig atConfig, IDrivers idrivers, ILogging logging)
        {
            _logger = logging;
            _config = atConfig;
            _drivers = idrivers;
        }

        public void VerifyProductItems(Table table)
        {
            Table tableProducts = new Table(new string[] {"Item", "Price"});

            int productCount = ProductList.NumberOfElement;

            for(int i = 1 ; i <= productCount; i++)
            {
                tableProducts.AddRow(ProductTitle(i).GetText(), ProductPrice(i).GetText());
            }
            Assert.That(0, Is.EqualTo(tableProducts.ToProjection<ProductItem>().Except(table.ToProjection<ProductItem>()).Count()));
            
        }

    }
}

