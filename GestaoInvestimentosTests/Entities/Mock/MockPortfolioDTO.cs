using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoInvestimentosTests.Entities.Mock
{
    public class MockPortfolioDTO
    {
        private readonly Faker _faker;

        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public MockPortfolioDTO()
        {
            _faker = new Faker();
            Id = 1;
            UsuarioId = new Random().Next();
            Nome = _faker.Random.String2(100);
            Descricao = _faker.Random.String2(100);

        }
    }
}
