using GestaoInvestimentosCore.DTO.Usuario;

namespace GestaoInvestimentosCore.Entities
{
    public class Usuario : EntityBase
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public virtual ICollection<Portfolio> Portfolios { get; } = new List<Portfolio>();

        public Usuario()
        {
            Portfolios = new HashSet<Portfolio>();
        }

        public Usuario(string nome, string email, string senha)
        {
            Nome = nome;
            Email = email;
            Senha = senha;

            ValidateEntity();
        }

        public Usuario(CreateUsuarioDTO createUsuarioDTO)
        {
            Nome = createUsuarioDTO.Nome;
            Email = createUsuarioDTO.Email;
            Senha = createUsuarioDTO.Senha;

            ValidateEntity();
        }

        public Usuario(UpdateUsuarioDTO updateUsuarioDTO)
        {
            Id = updateUsuarioDTO.Id;
            Nome = updateUsuarioDTO.Nome;
            Email = updateUsuarioDTO.Email;
            Senha = updateUsuarioDTO.Senha;

            ValidateEntity();
        }

        public void ValidateEntity()
        {
            AssertionValidations.AssertArgumentNullOrEmpty(Nome, "O nome não pode ser nulo nem vazio!");
            AssertionValidations.AssertArgumentNullOrEmpty(Email, "O email não pode ser nulo nem vazio!");
            AssertionValidations.AssertArgumentNullOrEmpty(Senha, "A senha não pode ser nulo nem vazio!");

            AssertionValidations.AssertArgumentLenght(Nome, 100, "O nome deve ter no máximo 100 caracteres!");
            AssertionValidations.AssertArgumentLenght(Email, 100, "O email deve ter no máximo 100 caracteres!");
            AssertionValidations.AssertArgumentLenght(Senha, 50, "A senha deve ter no máximo 50 caracteres!");
        }
    }
}
