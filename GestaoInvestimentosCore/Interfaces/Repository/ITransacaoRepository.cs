using GestaoInvestimentosCore.Entities;

namespace GestaoInvestimentosCore.Interfaces.Repository
{
    public interface ITransacaoRepository : IRepository<Transacao>
    {
        IEnumerable<Transacao> GetAllAsync(int? id, int? portfolioId, int? ativoId, int? tipoTransacao, int? quantidade, int? preco, string dataTransacao);
    }
}
