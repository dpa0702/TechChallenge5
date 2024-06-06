using GestaoInvestimentosCore.DTO.Transacao;

namespace GestaoInvestimentosCore.Entities
{
    public class Transacao
    {
        public int Id { get; set; }
        public int PortfolioId { get; set; }
        public int AtivoId { get; set; }
        public string TipoTransacao { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }
        public DateTime DataTransacao { get; set; }

        public virtual Portfolio Portfolio { get; set; }
        public virtual Ativo Ativo { get; set; }

        public Transacao()
        {
            Portfolio = new Portfolio();
            Ativo = new Ativo();
        }

        public Transacao(int id, int portfolioId, int ativoId, string tipoTransacao, int quantidade, decimal preco, DateTime dataTransacao)
        {
            Id = id;
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
            Id = createTransacaoDTO.Id;
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
            AssertionValidations.AssertArgumentNullOrEmpty(TipoTransacao, "O tipoTransacao não pode ser nulo nem vazio!");

            AssertionValidations.AssertArgumentLenght(TipoTransacao, 100, "O tipoTransacao deve ter no máximo 100 caracteres!");
        }
    }
}
