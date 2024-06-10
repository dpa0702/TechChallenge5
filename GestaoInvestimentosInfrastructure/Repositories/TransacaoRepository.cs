using GestaoInvestimentosCore.Entities;
using GestaoInvestimentosCore.Interfaces.Repository;
using GestaoInvestimentosInfrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GestaoInvestimentosInfrastructure.Repositories
{
    public class TransacaoRepository : BaseRepository, ITransacaoRepository
    {
        public TransacaoRepository(ApplicationDbContext context) : base(context) { }

        public void Delete(Transacao transacao)
        {
            _context.Transacoes.Remove(transacao);
            _context.SaveChanges();
        }

        public IEnumerable<Transacao> GetAllAsync()
        {
            return _context.Transacoes.AsNoTracking();
        }

        public Transacao GetById(int id)
        {
            return _context.Transacoes.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();
        }

        public void Insert(Transacao transacao)
        {
            _context.Transacoes.Add(transacao);
            _context.SaveChanges();
        }

        public void Update(Transacao transacao)
        {
            _context.Transacoes.Update(transacao);
            _context.SaveChanges();
        }
    }
}
