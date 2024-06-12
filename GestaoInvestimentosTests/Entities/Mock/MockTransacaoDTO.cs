using Bogus;
using GestaoInvestimentosCore.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoInvestimentosTests.Entities.Mock
{
    public class MockTransacaoDTO
    {
        private readonly Faker _faker;

        public int Id { get; set; }
        public int PortfolioId { get; set; }
        public int AtivoId { get; set; }
        public TipoTransacao TipoTransacao { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }
        public DateTime DataTransacao { get; set; }

        public MockTransacaoDTO()
        {
            _faker = new Faker();
            Id = 1;
            PortfolioId = new Random().Next();
            AtivoId = new Random().Next();
            TipoTransacao = (TipoTransacao)Enum.ToObject(typeof(TipoTransacao), new Random().Next(1,3));
            Quantidade = new Random().Next();
            Preco = new Random().Next();
            DataTransacao = DateTime.Now.AddTicks(new Random().Next());
        }
    }
}
