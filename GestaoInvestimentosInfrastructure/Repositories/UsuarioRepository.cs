using GestaoInvestimentosCore.Entities;
using GestaoInvestimentosCore.Interfaces.Repository;
using GestaoInvestimentosInfrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GestaoInvestimentosInfrastructure.Repositories
{
    public class UsuarioRepository : BaseRepository, IUsuarioRepository
    {
        public UsuarioRepository(ApplicationDbContext context) : base(context) { }

        public void Delete(Usuario usuario)
        {
            _context.Usuarios.Remove(usuario);
            _context.SaveChangesAsync();
        }

        public IEnumerable<Usuario> GetAllAsync()
        {
            return _context.Usuarios.AsNoTracking();
        }

        public Usuario GetById(int id)
        {
            return _context.Usuarios.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();
        }

        public void Insert(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChangesAsync();
        }

        public void Update(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            _context.SaveChangesAsync();
        }
    }
}
