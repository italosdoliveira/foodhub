namespace Domain.Entities
{
    public class ItemPedido
    {
        public string ProdutoId { get; set; }
        public string? ProdutoDescricao { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public string? Observacoes { get; set; }
        public decimal ValorAdicionais { get; set; }
        public decimal ValorTotal { get; set; }
    }
}