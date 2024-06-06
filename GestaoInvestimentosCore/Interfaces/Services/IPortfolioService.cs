using GestaoInvestimentosCore.DTO.Portfolio;
using GestaoInvestimentosCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
