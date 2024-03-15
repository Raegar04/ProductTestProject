using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductTestProject.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestFramework.Setup;
using TestFramework;

namespace ProductTestProject.Helpers
{
    public static class TestProjectConfiguration
    {
        public static void ConfigureTestProject(this IServiceCollection services)
        {
            services.AddTestFramework();

            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            services.Configure<TestSettings>(config.GetSection("TestSettings"));

            services.AddScoped<IHomePage, HomePage>();
            services.AddScoped<IProductDetailsPage, ProductDetailsPage>();
            services.AddScoped<IProductPage, ProductPage>();
            services.AddScoped<ICreateProductPage, CreateProductPage>();
        }
    }
}
