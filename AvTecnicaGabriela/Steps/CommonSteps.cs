using AvTecnicaGabriela.Endpoints;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace AvTecnicaGabriela.Steps
{
    [Binding]
    public class CommonSteps
    {
        public Common common;

        public CommonSteps(Common common)
        {
            this.common = common;
        }

        [Given(@"the API is up")]
        public void GivenTheAPIIsUp()
        {
            Assert.IsTrue(common.CheckAPI(), "API is out!");
        }
    }
}
