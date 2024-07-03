using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.FrameworkCore.WebUI.Abstractions
{
    public interface IAtWebElement
    {
        void Click(int timeOut = 3);
        void SendKeys(string text, int timeOut = 3);
        void Set(IWebDriver driver, By by);
        void ClearText(int timeOut = 3);
        string GetText(int timeOut = 3);
        string GetAttribute(string attributeName, int timeOut = 3);


    }
}
