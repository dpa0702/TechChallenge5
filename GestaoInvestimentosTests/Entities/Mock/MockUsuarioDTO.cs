using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoInvestimentosTests.Entities.Mock
{
    public class MockUsuarioDTO
    {
        private readonly Faker _faker;

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public MockUsuarioDTO()
        {
            _faker = new Faker();
            Id = 1;
            Nome = _faker.Random.String2(100);
            Email = _faker.Random.String2(100);
            Senha = _faker.Random.String2(150);
        }
    }
}
