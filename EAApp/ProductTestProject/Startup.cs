using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductTestProject.Helpers;
using ProductTestProject.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestFramework;
using TestFramework.Setup;

namespace ProductTestProject
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services) 
        {
            services.ConfigureTestProject();
        }
    }
}
