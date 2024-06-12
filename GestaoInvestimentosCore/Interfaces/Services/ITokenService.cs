using GestaoInvestimentosCore.DTO.Usuario;
using GestaoInvestimentosCore.Entities;

namespace GestaoInvestimentosCore.Interfaces.Services
{
    public interface ITokenService
    {
        LoginUsuarioDTO GenerateToken(LoginUsuarioDTO loginUsuarioDTO);
    }
}
