using GestaoInvestimentosCore.DTO.Ativo;
using GestaoInvestimentosCore.Enums;

namespace GestaoInvestimentosCore.Entities
{
    public class Ativo : EntityBase
    {
        public TipoAtivo TipoAtivo { get; set; }
        public string Nome { get; set; }
        public string Codigo { get; set; }

        public virtual ICollection<Transacao> Transacoes { get; set; } = new List<Transacao>();

        public Ativo()
        {
            Transacoes = new HashSet<Transacao>();
        }

        public Ativo(TipoAtivo tipoAtivo, string nome, string codigo)
        {
            TipoAtivo = tipoAtivo;
            Nome = nome;
            Codigo = codigo;

            ValidateEntity();
        }

        public Ativo(CreateAtivoDTO createAtivoDTO)
        {
            TipoAtivo = createAtivoDTO.TipoAtivo;
            Nome = createAtivoDTO.Nome;
            Codigo = createAtivoDTO.Codigo;

            ValidateEntity();
        }

        public Ativo(UpdateAtivoDTO updateAtivoDTO)
        {
            Id = updateAtivoDTO.Id;
            TipoAtivo = updateAtivoDTO.TipoAtivo;
            Nome = updateAtivoDTO.Nome;
            Codigo = updateAtivoDTO.Codigo;

            ValidateEntity();
        }

        public void ValidateEntity()
        {
            AssertionValidations.AssertArgumentNullOrEmpty(Nome, "O Nome não pode ser nulo nem vazio!");
            AssertionValidations.AssertArgumentNullOrEmpty(Codigo, "O Codigo não pode ser nulo nem vazio!");

            AssertionValidations.AssertArgumentLenght(Nome, 100, "O Nome deve ter no máximo 100 caracteres!");
            AssertionValidations.AssertArgumentLenght(Codigo, 50, "O Codigo deve ter no máximo 50 caracteres!");

        }
    }
}
