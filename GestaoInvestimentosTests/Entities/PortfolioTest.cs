using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoInvestimentosTests.Entities
{
    [TestClass]
    public class PortfolioTest
    {
        private readonly Faker _faker;

        public PortfolioTest()
        {
            _faker = new Faker();
        }
    }
}
