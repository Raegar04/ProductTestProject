using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestFramework.Driver;

namespace ProductTestProject.Pages
{
    public interface IHomePage
    {
        void GoToProductPage();
    }

    public class HomePage : IHomePage
    {
        private readonly IWebDriver _webDriver;

        public HomePage(IWebDriverFixture webDriverFixture)
        {
            _webDriver = webDriverFixture.Driver;
        }

        private IWebElement _productLink => _webDriver.FindElement(By.LinkText("Product"));

        public void GoToProductPage()
        {
            _productLink.Click();
        }
    }
}
