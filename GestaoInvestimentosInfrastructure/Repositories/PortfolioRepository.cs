using GestaoInvestimentosCore.Entities;
using GestaoInvestimentosCore.Enums;
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

        public IEnumerable<Portfolio> GetAllAsync(int? id, int? usuarioId, string? nome, string? dedescricao)
        {
            //return _context.Portfolios.AsNoTracking();
            var portfolios = _context.Portfolios.AsNoTracking();

            if (id != null && id > 0)
                portfolios = portfolios.Where(x => x.Id == id);

            if (usuarioId != null)
                portfolios = portfolios.Where(x => x.UsuarioId == usuarioId);

            if (!string.IsNullOrEmpty(nome))
                portfolios = portfolios.Where(x => x.Nome == nome);

            if (!string.IsNullOrEmpty(dedescricao))
                portfolios = portfolios.Where(x => x.Descricao == dedescricao);

            return portfolios?.ToList() ?? new List<Portfolio>();
        }

        public void Insert(Portfolio portfolio)
        {
            _context.Portfolios.Add(portfolio);
            _context.SaveChanges();
        }

        public void Update(Portfolio portfolio)
        {
            _context.Portfolios.Update(portfolio);
            _context.SaveChanges();
        }

        public void Delete(Portfolio portfolio)
        {
            _context.Portfolios.Remove(portfolio);
            _context.SaveChanges();
        }
    }
}
