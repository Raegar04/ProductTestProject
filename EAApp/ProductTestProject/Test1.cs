using FluentAssertions;
using ProductAPI.Data;
using ProductTestProject.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProductTestProject
{
    public class Test1
    {
        private readonly IHomePage _homePage;

        private readonly IProductPage _productPage;

        private readonly IProductDetailsPage _productDetailsPage;

        private readonly ICreateProductPage _createProductPage;

        public Test1(IHomePage homePage, IProductDetailsPage productDetailsPage, IProductPage productPage, ICreateProductPage createProductPage)
        {
            _createProductPage = createProductPage;
            _homePage = homePage;
            _productPage = productPage;
            _productDetailsPage = productDetailsPage;
        }

        [Fact]
        public void Test() 
        {
            var name = Guid.NewGuid().ToString();
            var testProduct = new Product() 
            {
                Name = name,
                Description = "Test",
                Price = 10,
                ProductType = ProductType.CPU
            };

            _homePage.GoToProductPage();
            _productPage.GoToCreatePage();
            _createProductPage.CreateProduct(testProduct);

            _productPage.PerformOperation(TestFramework.Helpers.OperationType.Details, "Name", name);
            var actualProduct = _productDetailsPage.GetProduct();

            Assert.NotNull(actualProduct);
            actualProduct.Should().BeEquivalentTo(testProduct, cds=>cds.IncludingAllDeclaredProperties());
        }
    }
}
