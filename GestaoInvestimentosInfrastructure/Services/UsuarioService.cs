using GestaoInvestimentosCore.DTO.Usuario;
using GestaoInvestimentosCore.Entities;
using GestaoInvestimentosCore.Interfaces.Repository;
using GestaoInvestimentosCore.Interfaces.Services;
using Microsoft.AspNet.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace GestaoInvestimentosInfrastructure.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly RandomNumberGenerator _rng;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public void AddUsuarioAsync(CreateUsuarioDTO createUsuarioDTO)
        {
            try
            {
                createUsuarioDTO.Senha = new PasswordHasher().HashPassword(createUsuarioDTO.Senha);
                _usuarioRepository.Insert(new Usuario(createUsuarioDTO));
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro na camada de serviço ao inserir Usuario. Mensagem de Erro: {ex.Message}", ex);
            }
        }

        public void DeleteUsuarioAsync(int id)
        {
            try
            {
                _usuarioRepository.Delete(_usuarioRepository.GetById(id));
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro na camada de serviço ao excluir Usuario. Mensagem de Erro: {ex.Message}", ex);
            }
        }

        public IEnumerable<Usuario> GetAllUsuariosAsync(int? id, string? nome, string? email, string? senha)
        {
            try
            {
                return _usuarioRepository.GetAllAsync(id, nome, email, senha);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro na camada de serviço ao consultar Usuario por id. Mensagem de Erro: {ex.Message}", ex);
            }
        }

        public Usuario GetUsuarioByIdAsync(int id)
        {
            try
            {
                return _usuarioRepository.GetById(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro na camada de serviço ao consultar Usuario por id. Mensagem de Erro: {ex.Message}", ex);
            }
        }

        public void UpdateUsuarioAsync(UpdateUsuarioDTO updateUsuarioDTO)
        {
            try
            {
                updateUsuarioDTO.Senha = new PasswordHasher().HashPassword(updateUsuarioDTO.Senha);
                _usuarioRepository.Update(new Usuario(updateUsuarioDTO));
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro na camada de serviço ao atualizar Usuario. Mensagem de Erro: {ex.Message}", ex);
            }
        }

        public LoginUsuarioDTO Login(LoginUsuarioDTO loginUsuarioDTO)
        {
            try
            {
                var usuario = _usuarioRepository.GetAllAsync(0, null, loginUsuarioDTO.Email, null).FirstOrDefault();
                if(usuario == null)
                {
                    throw new Exception($"Erro no Login:");
                }

                PasswordVerificationResult passwordVerificationResult = new PasswordHasher().VerifyHashedPassword(usuario.Senha, loginUsuarioDTO.Senha);

                if (passwordVerificationResult.Equals(PasswordVerificationResult.Success))
                    return GenerateToken(loginUsuarioDTO);
                else
                    throw new Exception($"Senha Incorreta");
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro na camada de serviço ao consultar Usuario por id. Mensagem de Erro: {ex.Message}", ex);
            }
        }

        public static LoginUsuarioDTO GenerateToken(LoginUsuarioDTO loginUsuarioDTO)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("fedaf7d8863b48e197b9287d492b708e");//(Settings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, loginUsuarioDTO.Email.ToString()),
                    new Claim(ClaimTypes.Role, loginUsuarioDTO.Senha.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            
            var token = tokenHandler.CreateToken(tokenDescriptor);
            loginUsuarioDTO.Token = tokenHandler.WriteToken(token);

            return loginUsuarioDTO;
        }
    }
}
