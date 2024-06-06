using GestaoInvestimentosCore.DTO.Usuario;
using GestaoInvestimentosCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
