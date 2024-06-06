using GestaoInvestimentosCore.DTO.Transacao;
using GestaoInvestimentosCore.Entities;

namespace GestaoInvestimentosCore.Interfaces.Services
{
    public interface ITransacaoService
    {
        Transacao GetTransacaoByIdAsync(int id);
        IEnumerable<Transacao> GetAlTransacoesAsync();
        void AddTransacaoAsync(CreateTransacaoDTO createTransacaoDTO);
        void UpdateTransacaoAsync(UpdateTransacaoDTO updateTransacaoDTO);
        void DeleteTransacaoAsync(Transacao transacao);
    }
}
