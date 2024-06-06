namespace GestaoInvestimentosCore.DTO.Transacao
{
    public class CreateTransacaoDTO
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
