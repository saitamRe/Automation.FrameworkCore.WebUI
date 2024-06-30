using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.FrameworkCore.WebUI.Abstractions
{
    public interface IAtWebElement
    {
        void Click();
        void SendKeys(string text);
    }
}
