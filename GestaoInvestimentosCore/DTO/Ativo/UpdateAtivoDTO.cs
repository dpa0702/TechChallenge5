using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoInvestimentosCore.DTO.Ativo
{
    public class UpdateAtivoDTO
    {
        public int Id { get; set; }
        public string TipoAtivo { get; set; }
        public string Nome { get; set; }
        public string Codigo { get; set; }
    }
}
