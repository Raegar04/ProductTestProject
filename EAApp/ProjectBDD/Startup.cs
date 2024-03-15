using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductAPI.Data;
using ProductAPI.Repository;
using ProductTestProject.Helpers;
using ProductTestProject.Pages;
using SolidToken.SpecFlow.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestFramework;
using TestFramework.Setup;

namespace ProjectBDD
{
    public static class Startup
    {
        [ScenarioDependencies]
        public static IServiceCollection CreateServices()
        {
            var services = new ServiceCollection();

            services.ConfigureTestProject();
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            services.AddDbContext<ProductDbContext>(cfg=>cfg.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
