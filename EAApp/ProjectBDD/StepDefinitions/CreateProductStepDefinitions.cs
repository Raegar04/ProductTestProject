using ProductAPI.Data;
using ProductTestProject.Pages;
using System.Xml.Linq;
using TechTalk.SpecFlow.Assist;

namespace ProjectBDD.StepDefinitions
{
    [Binding]
    public sealed class CreateProductStepDefinitions
    {
        private readonly IHomePage _homePage;

        private readonly IProductPage _productPage;

        private readonly IProductDetailsPage _productDetailsPage;

        private readonly ICreateProductPage _createProductPage;

        private Product testProduct;

        public CreateProductStepDefinitions(IHomePage homePage, IProductDetailsPage productDetailsPage, IProductPage productPage, ICreateProductPage createProductPage)
        {
            _createProductPage = createProductPage;
            _homePage = homePage;
            _productPage = productPage;
            _productDetailsPage = productDetailsPage;
        }

        [Given(@"I go to the product page")]
        public void GivenIGoToTheProductPage()
        {
            _homePage.GoToProductPage();
        }

        [Given(@"I go to create product page")]
        public void GivenIGoToCreateProductPage()
        {
            _productPage.GoToCreatePage();
        }

        [Given(@"I create product with details:")]
        public void GivenICreateProductWithDetails(Table table)
        {
            testProduct = table.CreateInstance<Product>();
            _createProductPage.CreateProduct(testProduct);
        }

        [When(@"I go to details of the newly created entity")]
        public void WhenIGoToDetailsOfTheNewlyCreatedEntity()
        {
            _productPage.PerformOperation(TestFramework.Helpers.OperationType.Details, "Name", testProduct.Name);
        }

        [Then(@"I check if actual product details are the same with created one")]
        public void ThenICheckIfActualProductDetailsAreTheSameWithCreatedOne()
        {
            var actualProduct = _productDetailsPage.GetProduct();

            Assert.NotNull(actualProduct);
            actualProduct.Should().BeEquivalentTo(testProduct, cds => cds.IncludingAllDeclaredProperties());
        }

    }
}