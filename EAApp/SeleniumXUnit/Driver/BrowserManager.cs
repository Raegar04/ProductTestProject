using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace TestFramework.Driver;

public class BrowserManager : IBrowserManager
{
    public IWebDriver GetBrowserDriver(BrowserType browserType)
    {
        var driverManager = new DriverManager();
        switch (browserType)
        {
            case BrowserType.Chrome:
                driverManager.SetUpDriver(new ChromeConfig());
                return new ChromeDriver();
            default:
                driverManager.SetUpDriver(new FirefoxConfig());
                return new FirefoxDriver();
        }
    }
}

public enum BrowserType
{
    Chrome,
    Firefox
}
