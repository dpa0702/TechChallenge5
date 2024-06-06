using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoInvestimentosCore.DTO.Transacao
{
    public class UpdateTransacaoDTO
    {
        public int Id { get; set; }
        public int PortfolioId { get; set; }
        public int AtivoId { get; set; }
        public string TipoTransacao { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }
        public DateTime DataTransacao { get; set; }
    }
}
