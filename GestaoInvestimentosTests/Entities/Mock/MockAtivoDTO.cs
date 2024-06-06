using Bogus;
using GestaoInvestimentosCore.Enums;

namespace GestaoInvestimentosTests.Entities.Mock
{
    public class MockAtivoDTO
    {
        private readonly Faker _faker;

        public int Id { get; set; }
        public TipoAtivo TipoAtivo { get; set; }
        public string Nome { get; set; }
        public string Codigo { get; set; }

        public MockAtivoDTO()
        {
            _faker = new Faker();
            Id = 1;
            TipoAtivo = TipoAtivo.Acao;
            Nome = _faker.Random.String2(100);
            Codigo = _faker.Random.String2(100);
        }
    }
}
