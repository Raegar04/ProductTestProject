using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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

            return services;
        }
    }
}
