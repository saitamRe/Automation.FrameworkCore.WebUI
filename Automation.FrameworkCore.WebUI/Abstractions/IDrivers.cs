using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.FrameworkCore.WebUI.Abstractions
{
	public interface IDrivers
	{
		IWebDriver GetWebDriver();
		IWebElement FindElement(By by);
		void Dispose();
	}
}
