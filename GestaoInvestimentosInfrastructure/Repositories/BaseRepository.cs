using GestaoInvestimentosCore.Interfaces.Repository;
using GestaoInvestimentosInfrastructure.Data;

namespace GestaoInvestimentosInfrastructure.Repositories
{
    public abstract class BaseRepository : IBaseRepository
    {
        protected ApplicationDbContext _context;

        protected BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public virtual void SaveChanges()
        {
            _context.SaveChanges(true);
        }
    }
}
