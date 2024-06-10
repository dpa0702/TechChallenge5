using GestaoInvestimentosCore.Entities;
using GestaoInvestimentosCore.Enums;
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

        public IEnumerable<Ativo> GetAllAsync(int? id, int? tipoAtivo, string nome, string codigo)
        {
            var ativo = _context.Ativos.AsNoTracking();

            if (id != null && id > 0)
                ativo = ativo.Where(x => x.Id == id);

            if (tipoAtivo != null)
                ativo = ativo.Where(x => x.TipoAtivo == (TipoAtivo)tipoAtivo.Value);

            if (!string.IsNullOrEmpty(nome))
                ativo = ativo.Where(x => x.Nome == nome);

            if (!string.IsNullOrEmpty(codigo))
                ativo = ativo.Where(x => x.Codigo == codigo);

            return ativo?.ToList() ?? new List<Ativo>();
        }

        public void Insert(Ativo ativo)
        {
            _context.Ativos.Add(ativo);
            _context.SaveChanges();
        }

        public void Update(Ativo ativo)
        {
            _context.Ativos.Update(ativo);
            _context.SaveChanges();
        }

        public void Delete(Ativo ativo)
        {
            _context.Ativos.Remove(ativo);
            _context.SaveChanges();
        }
    }
}
