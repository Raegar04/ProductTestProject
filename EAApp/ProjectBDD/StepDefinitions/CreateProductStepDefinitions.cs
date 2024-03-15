using ProductAPI.Data;
using ProductAPI.Repository;
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
        private readonly IProductRepository productRepository;
        private ScenarioContext _scenarioContext;

        public CreateProductStepDefinitions(IProductRepository productRepository,ScenarioContext scenarioContext, IHomePage homePage, IProductDetailsPage productDetailsPage, IProductPage productPage, ICreateProductPage createProductPage)
        {
            this.productRepository = productRepository;
            _scenarioContext = scenarioContext;
            _createProductPage = createProductPage;
            _homePage = homePage;
            _productPage = productPage;
            _productDetailsPage = productDetailsPage;
        }

        [Given(@"I go to the product page")]
        public void GivenIGoToTheProductPage()
        {
            var a = productRepository.GetAllProducts();
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
            var testProduct = table.CreateInstance<Product>();
            _createProductPage.CreateProduct(testProduct);
            _scenarioContext.Set(testProduct);
        }

        [When(@"I go to details of the newly created entity")]
        public void WhenIGoToDetailsOfTheNewlyCreatedEntity()
        {
            var testProduct = _scenarioContext.Get<Product>();
            _productPage.PerformOperation(TestFramework.Helpers.OperationType.Details, "Name", testProduct.Name);
        }

        [Then(@"I check if actual product details are the same with created one")]
        public void ThenICheckIfActualProductDetailsAreTheSameWithCreatedOne()
        {
            var actualProduct = _productDetailsPage.GetProduct();

            var testProduct = _scenarioContext.Get<Product>();
            Assert.NotNull(actualProduct);
            actualProduct.Should().BeEquivalentTo(testProduct, cds => cds.IncludingAllDeclaredProperties());
        }

    }
}