using GestaoInvestimentosCore.DTO.Portfolio;
using GestaoInvestimentosCore.Entities;
using GestaoInvestimentosCore.Interfaces.Repository;
using GestaoInvestimentosCore.Interfaces.Services;
using GestaoInvestimentosInfrastructure.Repositories;

namespace GestaoInvestimentosInfrastructure.Services
{
    public class PortfolioService : IPortfolioService
    {
        private readonly IPortfolioRepository _portfolioRepository;

        public PortfolioService(IPortfolioRepository portfolioRepository)
        {
            _portfolioRepository = portfolioRepository;
        }

        public void AddPortfolioAsync(CreatePortfolioDTO createPortfolioDTO)
        {
            try
            {
                _portfolioRepository.Insert(new Portfolio(createPortfolioDTO));
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro na camada de serviço ao inserir Portfolio. Mensagem de Erro: {ex.Message}", ex);
            }
        }

        public void DeletePortfolioAsync(int id)
        {
            try
            {
                _portfolioRepository.Delete(_portfolioRepository.GetById(id));
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro na camada de serviço ao excluir Portfolio. Mensagem de Erro: {ex.Message}", ex);
            }
        }

        public IEnumerable<Portfolio> GetAllPortfoliosAsync(int? id, int? usuarioId, string? nome, string? descricao)
        {
            try
            {
                return _portfolioRepository.GetAllAsync(id, usuarioId, nome, descricao);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro na camada de serviço ao consultar Portfolio por id. Mensagem de Erro: {ex.Message}", ex);
            }
        }

        public Portfolio GetPortfolioByIdAsync(int id)
        {
            try
            {
                return _portfolioRepository.GetById(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro na camada de serviço ao consultar Portfolio por id. Mensagem de Erro: {ex.Message}", ex);
            }
        }

        public void UpdatePortfolioAsync(UpdatePortfolioDTO updatePortfolioDTO)
        {
            try
            {
                _portfolioRepository.Update(new Portfolio(updatePortfolioDTO));
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro na camada de serviço ao atualizar Portfolio. Mensagem de Erro: {ex.Message}", ex);
            }
        }
    }
}
