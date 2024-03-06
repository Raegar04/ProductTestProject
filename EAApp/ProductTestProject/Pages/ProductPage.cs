using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestFramework.Driver;
using TestFramework.Helpers;

namespace ProductTestProject.Pages
{
    public interface IProductPage
    {
        void GoToCreatePage();

        void PerformOperation(OperationType operationType, string columnName, string cellData);
    }

    public class ProductPage : IProductPage
    {
        private readonly IWebDriver _webDriver;

        public ProductPage(IWebDriverFixture webDriverFixture)
        {
            _webDriver = webDriverFixture.Driver;
        }

        private IWebElement _createLink => _webDriver.FindElement(By.LinkText("Create"));

        private IWebElement _table => _webDriver.FindElement(By.CssSelector("table"));

        public void GoToCreatePage()
        {
            _createLink.Click();
        }

        public void PerformOperation(OperationType operationType, string columnName, string cellData)
        {
            _table.PerformAction(operationType, columnName, cellData);
        }
    }
}
