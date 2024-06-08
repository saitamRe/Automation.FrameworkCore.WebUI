using Automation.DemoUI.Tests.Params;
using Automation.FrameworkCore.WebUI.Abstractions;
using Automation.FrameworkCore.WebUI.DIConteiner;
using Automation.FrameworkCore.WebUI.Reports;
using Microsoft.Extensions.DependencyInjection;

namespace Automation.DemoUI.Tests
{
    public class Tests
    {
        
        [SetUp]
        public void Setup()
        {
            IServiceProvider serviceProvider = ContainerConfig.ConfiureServices();
            ILogging logging = serviceProvider.GetRequiredService<ILogging>();
            logging.Fatal("Oh holly shit!");
            GlobalProperties globalProperties = new GlobalProperties();
            globalProperties.Configure();
        }

        [Test]
        public void Test1()
        {

            Assert.AreEqual(1, 1);
        }
    }
}