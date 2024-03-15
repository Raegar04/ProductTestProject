using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBDD.StepDefinitions
{
    [Binding]
    public class ReusableSteps
    {
        private readonly ScenarioContext _scenarioContext;

        public ReusableSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }


    }
}
