using GestaoInvestimentosCore.DTO.Usuario;
using GestaoInvestimentosCore.Entities;

namespace GestaoInvestimentosCore.Interfaces.Services
{
    public interface IUsuarioService
    {
        Usuario GetUsuarioByIdAsync(int id);
        IEnumerable<Usuario> GetAllUsuariosAsync();
        void AddUsuarioAsync(CreateUsuarioDTO createUsuarioDTO);
        void UpdateUsuarioAsync(UpdateUsuarioDTO updateUsuarioDTO);
        void DeleteUsuarioAsync(Usuario usuario);
    }
}
