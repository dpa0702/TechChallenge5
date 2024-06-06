using GestaoInvestimentosCore.Entities;
using GestaoInvestimentosCore.Interfaces.Repository;
using GestaoInvestimentosInfrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GestaoInvestimentosInfrastructure.Repositories
{
    public class PortfolioRepository : BaseRepository, IPortfolioRepository
    {
        public PortfolioRepository(ApplicationDbContext context) : base(context) { }

        public Portfolio GetById(int id)
        {
            return _context.Portfolios.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Portfolio> GetAllAsync()
        {
            return _context.Portfolios.AsNoTracking();
        }

        public void Insert(Portfolio portfolio)
        {
            _context.Portfolios.Add(portfolio);
            _context.SaveChangesAsync();
        }

        public void Update(Portfolio portfolio)
        {
            _context.Portfolios.Update(portfolio);
            _context.SaveChangesAsync();
        }

        public void Delete(Portfolio portfolio)
        {
            _context.Portfolios.Remove(portfolio);
            _context.SaveChangesAsync();
        }
    }
}
