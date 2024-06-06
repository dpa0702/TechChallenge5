using GestaoInvestimentosCore.DTO.Transacao;
using GestaoInvestimentosCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
