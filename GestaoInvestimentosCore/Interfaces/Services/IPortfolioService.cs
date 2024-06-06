using GestaoInvestimentosCore.DTO.Portfolio;
using GestaoInvestimentosCore.Entities;

namespace GestaoInvestimentosCore.Interfaces.Services
{
    public interface IPortfolioService
    {
        Portfolio GetPortfolioByIdAsync(int id);
        IEnumerable<Portfolio> GetAllPortfoliosAsync();
        void AddPortfolioAsync(CreatePortfolioDTO portfolio);
        void UpdatePortfolioAsync(UpdatePortfolioDTO updatePortfolioDTO);
        void DeletePortfolioAsync(Portfolio portfolio);
    }
}
