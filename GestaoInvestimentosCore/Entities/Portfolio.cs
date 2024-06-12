using GestaoInvestimentosCore.DTO.Portfolio;

namespace GestaoInvestimentosCore.Entities
{
    public class Portfolio : EntityBase
    {
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<Transacao> Transacoes { get; set; } = new List<Transacao>();

        public Portfolio()
        {
            Transacoes = new HashSet<Transacao>();
        }

        public Portfolio(int usuarioId, string nome, string descricao)
        {
            UsuarioId = usuarioId;
            Nome = nome;
            Descricao = descricao;

            ValidateEntity();
        }
        public Portfolio(CreatePortfolioDTO createPortfolioDTO)
        {
            UsuarioId = createPortfolioDTO.UsuarioId;
            Nome = createPortfolioDTO.Nome;
            Descricao = createPortfolioDTO.Descricao;

            ValidateEntity();
        }

        public Portfolio(UpdatePortfolioDTO updatePortfolioDTO)
        {
            Id = updatePortfolioDTO.Id;
            UsuarioId = updatePortfolioDTO.UsuarioId;
            Nome = updatePortfolioDTO.Nome;
            Descricao = updatePortfolioDTO.Descricao;

            ValidateEntity();
        }

        public void ValidateEntity()
        {
            AssertionValidations.AssertArgumentNullOrEmpty(Nome, "O Nome não pode ser nulo nem vazio!");
            AssertionValidations.AssertArgumentNullOrEmpty(Descricao, "A Descricao não pode ser nulo nem vazio!");

            AssertionValidations.AssertArgumentLenght(Nome, 100, "O Nome deve ter no máximo 100 caracteres!");
            AssertionValidations.AssertArgumentLenght(Descricao, 100, "A Descricao deve ter no máximo 100 caracteres!");
        }        
    }
}
