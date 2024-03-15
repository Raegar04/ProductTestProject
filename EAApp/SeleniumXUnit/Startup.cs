using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestFramework.Driver;

namespace TestFramework
{
    public static class Startup
    {
        public static void AddTestFramework(this IServiceCollection services)
        {
            services.AddScoped<IWebDriverFixture, WebDriverFixture>();
            services.AddScoped<IBrowserManager, BrowserManager>();
        }
    }
}
