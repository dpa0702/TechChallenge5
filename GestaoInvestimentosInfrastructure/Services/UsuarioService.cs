using GestaoInvestimentosCore.DTO.Ativo;
using GestaoInvestimentosCore.DTO.Usuario;
using GestaoInvestimentosCore.Entities;
using GestaoInvestimentosCore.Interfaces.Repository;
using GestaoInvestimentosCore.Interfaces.Services;
using GestaoInvestimentosInfrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoInvestimentosInfrastructure.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public void AddUsuarioAsync(CreateUsuarioDTO createUsuarioDTO)
        {
            try
            {
                _usuarioRepository.Insert(new Usuario(createUsuarioDTO));
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro na camada de serviço ao inserir Usuario. Mensagem de Erro: {ex.Message}", ex);
            }
        }

        public void DeleteUsuarioAsync(Usuario usuario)
        {
            try
            {
                _usuarioRepository.Delete(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro na camada de serviço ao inserir Usuario. Mensagem de Erro: {ex.Message}", ex);
            }
        }

        public IEnumerable<Usuario> GetAllUsuariosAsync()
        {
            try
            {
                return _usuarioRepository.GetAllAsync();
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
                _usuarioRepository.Delete(new Usuario(updateUsuarioDTO));
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro na camada de serviço ao atualizar Usuario. Mensagem de Erro: {ex.Message}", ex);
            }
        }
    }
}
