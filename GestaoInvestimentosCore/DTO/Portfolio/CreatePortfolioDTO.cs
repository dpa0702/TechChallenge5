namespace GestaoInvestimentosCore.DTO.Portfolio
{
    public class CreatePortfolioDTO
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}
