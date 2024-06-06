using GestaoInvestimentosCore.Enums;

namespace GestaoInvestimentosCore.DTO.Ativo
{
    public class UpdateAtivoDTO
    {
        public int Id { get; set; }
        public TipoAtivo TipoAtivo { get; set; }
        public string Nome { get; set; }
        public string Codigo { get; set; }
    }
}
