using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;

namespace TestFramework.Driver
{
    public interface IBrowserManager
    {
        IWebDriver GetBrowserDriver(BrowserType browserType);
    }
}
