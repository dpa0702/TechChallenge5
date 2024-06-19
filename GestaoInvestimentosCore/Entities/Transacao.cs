using GestaoInvestimentosCore.DTO.Transacao;
using GestaoInvestimentosCore.Enums;

namespace GestaoInvestimentosCore.Entities
{
    public class Transacao : EntityBase
    {
        public int PortfolioId { get; set; }
        public virtual Portfolio Portfolio { get; set; }
        public int AtivoId { get; set; }
        public virtual Ativo Ativo { get; set; }
        public TipoTransacao TipoTransacao { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }
        public DateTime DataTransacao { get; set; }


        public Transacao()
        {
            Portfolio = new Portfolio();
        }

        public Transacao(int portfolioId, int ativoId, TipoTransacao tipoTransacao, int quantidade, decimal preco, DateTime dataTransacao)
        {
            PortfolioId = portfolioId;
            AtivoId = ativoId;
            TipoTransacao = tipoTransacao;
            Quantidade = quantidade;
            Preco = preco;
            DataTransacao = dataTransacao;

            ValidateEntity();
        }

        public Transacao(CreateTransacaoDTO createTransacaoDTO)
        {
            PortfolioId = createTransacaoDTO.PortfolioId;
            AtivoId = createTransacaoDTO.AtivoId;
            TipoTransacao = createTransacaoDTO.TipoTransacao;
            Quantidade = createTransacaoDTO.Quantidade;
            Preco = createTransacaoDTO.Preco;
            DataTransacao = createTransacaoDTO.DataTransacao;

            ValidateEntity();
        }

        public Transacao(UpdateTransacaoDTO updateTransacaoDTO)
        {
            Id = updateTransacaoDTO.Id;
            PortfolioId = updateTransacaoDTO.PortfolioId;
            AtivoId = updateTransacaoDTO.AtivoId;
            TipoTransacao = updateTransacaoDTO.TipoTransacao;
            Quantidade = updateTransacaoDTO.Quantidade;
            Preco = updateTransacaoDTO.Preco;
            DataTransacao = updateTransacaoDTO.DataTransacao;

            ValidateEntity();
        }

        public void ValidateEntity()
        {

        }
    }
}
