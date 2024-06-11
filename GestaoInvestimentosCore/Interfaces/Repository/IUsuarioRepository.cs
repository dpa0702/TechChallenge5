using GestaoInvestimentosCore.Entities;

namespace GestaoInvestimentosCore.Interfaces.Repository
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        IEnumerable<Usuario> GetAllAsync(int? id, string nome, string? email, string senha);
    }
}
