using GestaoInvestimentosCore.Enums;

namespace GestaoInvestimentosCore.DTO.Transacao
{
    public class CreateTransacaoDTO
    {
        public int PortfolioId { get; set; }
        public int AtivoId { get; set; }
        public TipoTransacao TipoTransacao { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }
        public DateTime DataTransacao { get; set; }
    }
}
