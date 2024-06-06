using GestaoInvestimentosCore.Entities;

namespace GestaoInvestimentosCore.Interfaces.Repository
{
    public interface IAtivoRepository : IRepository<Ativo>
    {
        IEnumerable<Ativo> GetAllAsync();
    }
}
