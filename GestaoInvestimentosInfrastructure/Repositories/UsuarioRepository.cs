using GestaoInvestimentosCore.Entities;
using GestaoInvestimentosCore.Enums;
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
            _context.SaveChanges();
        }

        public IEnumerable<Usuario> GetAllAsync(int? id, string? nome, string? email, string? senha)
        {
            var usuario = _context.Usuarios.AsNoTracking();

            if (id != null && id > 0)
                usuario = usuario.Where(x => x.Id == id);

            if (!string.IsNullOrEmpty(nome))
                usuario = usuario.Where(x => x.Nome == nome);

            if (!string.IsNullOrEmpty(email))
                usuario = usuario.Where(x => x.Email == email);

            if (!string.IsNullOrEmpty(senha))
                usuario = usuario.Where(x => x.Senha == senha);

            if (usuario == null) return new List<Usuario>();

            var usuarioList = (from _usuario in usuario
                                 select new Usuario
                                 {
                                     Id = _usuario.Id,
                                     Nome = _usuario.Nome,
                                     Email = _usuario.Email,
                                     Senha = _usuario.Senha,
                                     Portfolios = _context.Portfolios.Where(p => p.UsuarioId == _usuario.Id).ToList(),
                                 }
                          ).ToList();

            return usuarioList ?? new List<Usuario>();
        }

        public Usuario GetById(int id)
        {
            return _context.Usuarios.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();
        }

        public void Insert(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }

        public void Update(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            _context.SaveChanges();
        }
    }
}
