using OpenQA.Selenium;

namespace TestFramework.Driver
{
    public interface IWebDriverFixture : IDisposable
    {
        IWebDriver Driver { get; }
    }
}