using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Automation.DemoUI.WebAbstractions.ISteps
{
    public interface IProductPage
    {
        void VerifyProductItems(Table table);
    }
}
