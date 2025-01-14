﻿using GestaoInvestimentosCore.DTO.Ativo;
using GestaoInvestimentosCore.Entities;
using GestaoInvestimentosCore.Enums;
using GestaoInvestimentosCore.Interfaces.Repository;
using GestaoInvestimentosCore.Interfaces.Services;

namespace GestaoInvestimentosCore.Services
{
    public class AtivoService : IAtivoService
    {
        private readonly IAtivoRepository _ativoRepository;

        public AtivoService(IAtivoRepository ativoRepository)
        {
            _ativoRepository = ativoRepository;
        }

        public void AddAtivoAsync(CreateAtivoDTO createAtivoDTO)
        {
            try
            {
                _ativoRepository.Insert(new Ativo(createAtivoDTO));
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro na camada de serviço ao inserir Ativo. Mensagem de Erro: {ex.Message}", ex);
            }
        }

        public void DeleteAtivoAsync(int id)
        {
            try
            {
                _ativoRepository.Delete(_ativoRepository.GetById(id));
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro na camada de serviço ao excluir Ativo. Mensagem de Erro: {ex.Message}", ex);
            }
        }

        public IEnumerable<Ativo> GetAllAtivosAsync(int? id, int? tipoAtivo, string nome, string codigo)
        {
            try
            {
                return _ativoRepository.GetAllAsync(id, tipoAtivo, nome, codigo);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro na camada de serviço ao consultar Ativo por id. Mensagem de Erro: {ex.Message}", ex);
            }
        }

        public Ativo GetAtivoByIdAsync(int id)
        {
            try
            {
                return _ativoRepository.GetById(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro na camada de serviço ao consultar Ativo por id. Mensagem de Erro: {ex.Message}", ex);
            }
        }

        public void UpdateAtivoAsync(UpdateAtivoDTO updateAtivoDTO)
        {
            try
            {
                _ativoRepository.Update(new Ativo(updateAtivoDTO));
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro na camada de serviço ao atualizar Ativo. Mensagem de Erro: {ex.Message}", ex);
            }
        }

        public bool TipoAtivoIsValid(int? tipoAtivo)
        {
            if (tipoAtivo == null || tipoAtivo == 0)
                return true;
            else
                return Enum.IsDefined(typeof(TipoAtivo), tipoAtivo);
        }
    }
}
