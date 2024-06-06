using GestaoInvestimentosCore.DTO.Ativo;

namespace GestaoInvestimentosCore.Entities
{
    public class Ativo
    {
        public int Id { get; set; }
        public string TipoAtivo { get; set; }
        public string Nome { get; set; }
        public string Codigo { get; set; }

        public virtual ICollection<Transacao> Transacoes { get; set; } = new List<Transacao>();

        public Ativo()
        {
            Transacoes = new HashSet<Transacao>();
        }

        public Ativo(int id, string tipoAtivo, string nome, string codigo)
        {
            Id = id;
            TipoAtivo = tipoAtivo;
            Nome = nome;
            Codigo = codigo;

            ValidateEntity();
        }

        public Ativo(CreateAtivoDTO createAtivoDTO)
        {
            Id = createAtivoDTO.Id;
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
            AssertionValidations.AssertArgumentNullOrEmpty(TipoAtivo, "O TipoAtivo não pode ser nulo nem vazio!");
            AssertionValidations.AssertArgumentNullOrEmpty(Nome, "O Nome não pode ser nulo nem vazio!");
            AssertionValidations.AssertArgumentNullOrEmpty(Codigo, "O Codigo não pode ser nulo nem vazio!");

            AssertionValidations.AssertArgumentLenght(TipoAtivo, 50, "O TipoAtivo deve ter no máximo 50 caracteres!");
            AssertionValidations.AssertArgumentLenght(Nome, 100, "O Nome deve ter no máximo 100 caracteres!");
            AssertionValidations.AssertArgumentLenght(Codigo, 100, "O Codigo deve ter no máximo 100 caracteres!");

        }
    }
}
