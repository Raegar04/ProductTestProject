using OpenQA.Selenium;
using ProductAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestFramework.Driver;
using TestFramework.Helpers;

namespace ProductTestProject.Pages
{
    public interface ICreateProductPage
    {
        void CreateProduct(Product product);

        void GoBackToList();
    }

    public class CreateProductPage : ICreateProductPage
    {
        private readonly IWebDriver _webDriver;

        public CreateProductPage(IWebDriverFixture webDriverFixture)
        {
            _webDriver = webDriverFixture.Driver;
        }

        private IWebElement _nameInput => _webDriver.FindElement(By.Id("Name"));

        private IWebElement _descriptionInput => _webDriver.FindElement(By.Id("Description"));

        private IWebElement _priceInput => _webDriver.FindElement(By.Id("Price"));

        private IWebElement _typeInput => _webDriver.FindElement(By.Id("ProductType"));

        private IWebElement _submitButton => _webDriver.FindElement(By.Id("Create"));

        private IWebElement _backToListLink => _webDriver.FindElement(By.LinkText("Back to List"));

        public void CreateProduct(Product product)
        {
            _nameInput.SendKeys(product.Name);
            _descriptionInput.SendKeys(product.Description);
            _priceInput.SendKeys(product.Price.ToString());
            _typeInput.SelectDropDownByText(product.ProductType.ToString());
            _submitButton.Submit();
        }

        public void GoBackToList()
        {
            _backToListLink.Click();
        }
    }
}
