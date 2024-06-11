using GestaoInvestimentosCore.DTO.Transacao;
using GestaoInvestimentosCore.Entities;

namespace GestaoInvestimentosCore.Interfaces.Services
{
    public interface ITransacaoService
    {
        Transacao GetTransacaoByIdAsync(int id);
        IEnumerable<Transacao> GetAlTransacoesAsync(int? id, int? portfolioId, int? ativoId, int? tipoTransacao, int? quantidade, int? preco, string dataTransacao);
        void AddTransacaoAsync(CreateTransacaoDTO createTransacaoDTO);
        void UpdateTransacaoAsync(UpdateTransacaoDTO updateTransacaoDTO);
        void DeleteTransacaoAsync(int id);
    }
}
