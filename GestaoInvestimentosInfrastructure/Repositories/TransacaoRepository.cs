using GestaoInvestimentosCore.Entities;
using GestaoInvestimentosCore.Enums;
using GestaoInvestimentosCore.Interfaces.Repository;
using GestaoInvestimentosInfrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GestaoInvestimentosInfrastructure.Repositories
{
    public class TransacaoRepository : BaseRepository, ITransacaoRepository
    {
        public TransacaoRepository(ApplicationDbContext context) : base(context) { }

        public void Delete(Transacao transacao)
        {
            _context.Transacoes.Remove(transacao);
            _context.SaveChanges();
        }

        public IEnumerable<Transacao> GetAllAsync(int? id, int? portfolioId, int? ativoId, int? tipoTransacao, int? quantidade, int? preco, string dataTransacao)
        {
            //return _context.Transacoes.AsNoTracking();
            var transacao = _context.Transacoes.AsNoTracking();

            if (id != null && id > 0)
                transacao = transacao.Where(x => x.Id == id);

            if (portfolioId != null && portfolioId > 0)
                transacao = transacao.Where(x => x.PortfolioId == portfolioId);

            if (ativoId != null && ativoId > 0)
                transacao = transacao.Where(x => x.AtivoId == ativoId);

            if (tipoTransacao != null && tipoTransacao > 0)
                transacao = transacao.Where(x => x.TipoTransacao == (TipoTransacao)tipoTransacao.Value);

            if (quantidade != null && quantidade > 0)
                transacao = transacao.Where(x => x.Quantidade == quantidade);

            if (preco != null && preco > 0)
                transacao = transacao.Where(x => x.Preco == preco);

            if (!string.IsNullOrEmpty(dataTransacao))
                transacao = transacao.Where(x => x.DataTransacao.ToString() == dataTransacao.ToString());

            return transacao?.ToList() ?? new List<Transacao>();
        }

        public Transacao GetById(int id)
        {
            return _context.Transacoes.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();
        }

        public void Insert(Transacao transacao)
        {
            _context.Transacoes.Add(transacao);
            _context.SaveChanges();
        }

        public void Update(Transacao transacao)
        {
            _context.Transacoes.Update(transacao);
            _context.SaveChanges();
        }
    }
}
