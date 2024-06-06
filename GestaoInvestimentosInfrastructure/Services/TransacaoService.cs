using GestaoInvestimentosCore.DTO.Transacao;
using GestaoInvestimentosCore.Entities;
using GestaoInvestimentosCore.Interfaces.Repository;
using GestaoInvestimentosCore.Interfaces.Services;

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

        public void DeleteTransacaoAsync(Transacao transacao)
        {
            try
            {
                _transacaoRepository.Delete(transacao);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro na camada de serviço ao inserir Transacao. Mensagem de Erro: {ex.Message}", ex);
            }
        }

        public IEnumerable<Transacao> GetAlTransacoesAsync()
        {
            try
            {
                return _transacaoRepository.GetAllAsync();
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
                _transacaoRepository.Delete(new Transacao(updateTransacaoDTO));
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro na camada de serviço ao atualizar Transacao. Mensagem de Erro: {ex.Message}", ex);
            }
        }
    }
}
