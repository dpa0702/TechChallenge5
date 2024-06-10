using GestaoInvestimentosCore.DTO.Portfolio;
using GestaoInvestimentosCore.Entities;

namespace GestaoInvestimentosCore.Interfaces.Services
{
    public interface IPortfolioService
    {
        Portfolio GetPortfolioByIdAsync(int id);
        IEnumerable<Portfolio> GetAllPortfoliosAsync(int? id, int? usuarioId, string? nome, string? dedescricao);
        void AddPortfolioAsync(CreatePortfolioDTO portfolio);
        void UpdatePortfolioAsync(UpdatePortfolioDTO updatePortfolioDTO);
        void DeletePortfolioAsync(int id);
    }
}
