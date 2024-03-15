using OpenQA.Selenium;
using ProductAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestFramework.Driver;

namespace ProductTestProject.Pages
{
    public interface IProductDetailsPage
    {
        Product GetProduct();
    }

    public class ProductDetailsPage : IProductDetailsPage
    {
        private readonly IWebDriver _webDriver;

        public ProductDetailsPage(IWebDriverFixture webDriverFixture)
        {
            _webDriver = webDriverFixture.Driver;
        }

        private IWebElement _nameField => _webDriver.FindElement(By.Id("Name"));

        private IWebElement _descriptionField => _webDriver.FindElement(By.Id("Description"));

        private IWebElement _priceField => _webDriver.FindElement(By.Id("Price"));

        private IWebElement _typeField => _webDriver.FindElement(By.Id("ProductType"));

        public Product GetProduct()
        {
            return new Product()
            {
                Name = _nameField.Text,
                Description = _descriptionField.Text,
                Price = int.Parse(_priceField.Text),
                ProductType = (ProductType)Enum.Parse(typeof(ProductType), _typeField.Text)
            };
        }
    }
}
