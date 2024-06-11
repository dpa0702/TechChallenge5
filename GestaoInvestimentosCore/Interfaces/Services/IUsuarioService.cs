using GestaoInvestimentosCore.DTO.Usuario;
using GestaoInvestimentosCore.Entities;

namespace GestaoInvestimentosCore.Interfaces.Services
{
    public interface IUsuarioService
    {
        Usuario GetUsuarioByIdAsync(int id);
        IEnumerable<Usuario> GetAllUsuariosAsync(int? id, string? nome, string? email, string? senha);
        void AddUsuarioAsync(CreateUsuarioDTO createUsuarioDTO);
        void UpdateUsuarioAsync(UpdateUsuarioDTO updateUsuarioDTO);
        void DeleteUsuarioAsync(int id);
        LoginUsuarioDTO Login(LoginUsuarioDTO loginUsuarioDTO);
    }
}
