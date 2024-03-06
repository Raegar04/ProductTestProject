using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestFramework.Driver;

namespace TestFramework.Setup
{
    public class TestSettings
    {
        public BrowserType BrowserType { get; set; }

        public string? PublicUri { get; set; }
    }
}
