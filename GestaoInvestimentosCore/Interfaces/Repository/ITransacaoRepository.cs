using GestaoInvestimentosCore.Entities;

namespace GestaoInvestimentosCore.Interfaces.Repository
{
    public interface ITransacaoRepository : IRepository<Transacao>
    {
        IEnumerable<Transacao> GetAllAsync();
    }
}
