using GestaoInvestimentosCore.DTO.Transacao;
using GestaoInvestimentosCore.Entities;
using GestaoInvestimentosCore.Interfaces.Repository;
using GestaoInvestimentosCore.Interfaces.Services;
using GestaoInvestimentosInfrastructure.Repositories;

namespace GestaoInvestimentosInfrastructure.Services
{
    public class TransacaoService : ITransacaoService
    {

        private readonly ITransacaoRepository _transacaoRepository;

        public TransacaoService(ITransacaoRepository transacaoRepository)
        {
            _transacaoRepository = transacaoRepository;
        }

        public void AddTransacaoAsync(CreateTransacaoDTO createTransacaoDTO)
        {
            try
            {
                _transacaoRepository.Insert(new Transacao(createTransacaoDTO));
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro na camada de serviço ao inserir Transacao. Mensagem de Erro: {ex.Message}", ex);
            }
        }

        public void DeleteTransacaoAsync(int id)
        {
            try
            {
                _transacaoRepository.Delete(_transacaoRepository.GetById(id));
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro na camada de serviço ao excluir Transacao. Mensagem de Erro: {ex.Message}", ex);
            }
        }

        public IEnumerable<Transacao> GetAllTransacoesAsync(int? id, int? portfolioId, int? ativoId, int? tipoTransacao, int? quantidade, int? preco, string dataTransacao)
        {
            try
            {
                return _transacaoRepository.GetAllAsync(id, portfolioId, ativoId, tipoTransacao, quantidade, preco, dataTransacao);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro na camada de serviço ao consultar Transacao por id. Mensagem de Erro: {ex.Message}", ex);
            }
        }

        public Transacao GetTransacaoByIdAsync(int id)
        {
            try
            {
                return _transacaoRepository.GetById(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro na camada de serviço ao consultar Transacao por id. Mensagem de Erro: {ex.Message}", ex);
            }
        }

        public void UpdateTransacaoAsync(UpdateTransacaoDTO updateTransacaoDTO)
        {
            try
            {
                _transacaoRepository.Update(new Transacao(updateTransacaoDTO));
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro na camada de serviço ao atualizar Transacao. Mensagem de Erro: {ex.Message}", ex);
            }
        }
    }
}
