using GestaoInvestimentosCore.Entities;

namespace GestaoInvestimentosCore.Interfaces.Repository
{
    public interface IPortfolioRepository : IRepository<Portfolio>
    {
        IEnumerable<Portfolio> GetAllAsync(int? id, int? usuarioId, string? nome, string? descricao);
    }
}
