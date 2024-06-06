using GestaoInvestimentosCore.Entities;
using GestaoInvestimentosCore.Interfaces.Repository;
using GestaoInvestimentosInfrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GestaoInvestimentosInfrastructure.Repositories
{
    public class AtivoRepository : BaseRepository, IAtivoRepository
    {
        public AtivoRepository(ApplicationDbContext context) : base(context) { }

        public Ativo GetById(int id)
        {
            return _context.Ativos.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Ativo> GetAllAsync()
        {
            return _context.Ativos.AsNoTracking();
        }

        public void Insert(Ativo ativo)
        {
            _context.Ativos.Add(ativo);
            _context.SaveChangesAsync();
        }

        public void Update(Ativo ativo)
        {
            _context.Ativos.Update(ativo);
            _context.SaveChangesAsync();
        }

        public void Delete(Ativo ativo)
        {
            _context.Ativos.Remove(ativo);
            _context.SaveChangesAsync();
        }
    }
}
