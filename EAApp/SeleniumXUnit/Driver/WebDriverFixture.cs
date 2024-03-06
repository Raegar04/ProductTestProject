using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using TestFramework.Setup;
using Microsoft.Extensions.Options;

namespace TestFramework.Driver
{
    public class WebDriverFixture : IWebDriverFixture
    {
        public IWebDriver Driver { get; private set; }

        private readonly TestSettings _settings;

        public WebDriverFixture(IBrowserManager browserDriver, IOptions<TestSettings> options)
        {
            _settings = options.Value;
            Driver = browserDriver.GetBrowserDriver(_settings.BrowserType);
            Driver.Navigate().GoToUrl(_settings.PublicUri);
        }

        public void Dispose()
        {
            Driver.Quit();
        }
    }
}
