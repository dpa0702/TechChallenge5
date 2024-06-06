using GestaoInvestimentosCore.DTO.Portfolio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GestaoInvestimentosCore.Entities
{
    public class Portfolio
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<Transacao> Transacoes { get; set; } = new List<Transacao>();

        public Portfolio()
        {
            Usuario = new Usuario();
            Transacoes = new HashSet<Transacao>();
        }

        public Portfolio(int id, int usuarioId, string nome, string descricao)
        {
            Id = id;
            UsuarioId = usuarioId;
            Nome = nome;
            Descricao = descricao;

            ValidateEntity();
        }
        public Portfolio(CreatePortfolioDTO createPortfolioDTO)
        {
            Id = createPortfolioDTO.Id;
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
            AssertionValidations.AssertArgumentNullOrEmpty(Nome, "O nome não pode ser nulo nem vazio!");
            AssertionValidations.AssertArgumentNullOrEmpty(Descricao, "A Descricao não pode ser nulo nem vazio!");

            AssertionValidations.AssertArgumentLenght(Nome, 100, "O nome deve ter no máximo 100 caracteres!");
            AssertionValidations.AssertArgumentLenght(Descricao, 100, "A Descricao deve ter no máximo 100 caracteres!");
        }        
    }
}
