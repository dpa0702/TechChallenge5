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

            var transacaoList = (from _transacao in transacao
                                 join portfolio in _context.Portfolios.AsNoTracking() on
                                    new { p = _transacao.PortfolioId } equals
                                    new { p = portfolio.Id }
                                 join ativo in _context.Ativos.AsNoTracking() on
                                     new { p = _transacao.AtivoId } equals
                                     new { p = ativo.Id }
                                 select new Transacao
                                 {
                                     Id = _transacao.Id,
                                     PortfolioId = _transacao.PortfolioId,
                                     AtivoId = _transacao.AtivoId,
                                     TipoTransacao = _transacao.TipoTransacao,
                                     Quantidade = _transacao.Quantidade,
                                     Preco = _transacao.Preco,
                                     DataTransacao = _transacao.DataTransacao,
                                     Portfolio = new Portfolio
                                     {
                                         Id = portfolio.Id,
                                         Nome = portfolio.Nome,
                                         Descricao = portfolio.Descricao,
                                     },
                                     Ativo = new Ativo
                                     {
                                         Id = ativo.Id,
                                         Nome = ativo.Nome,
                                         Codigo = ativo.Codigo,
                                     },
                                 }
                          ).ToList();

            return transacaoList ?? new List<Transacao>();
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
