using Domain.Enums;

namespace Domain.Entities
{
    public class Pedido
    {
        public string Codigo { get; set; }
        public DateTime DataHora { get; set; }
        public string ClienteId { get; set; }
        public string? ClienteNome { get; set; }
        public string RestauranteId { get; set; }
        public string? RestauranteNome { get; set; }
        public List<ItemPedido> Itens { get; private set; } = new();
        public decimal TaxaEntrega { get; private set; }
        public string? CupomDescontoAplicado { get; set; }
        public decimal ValorTotal { get; private set; }
        public StatusPedido Status { get; set; }
        public TipoPedido Tipo { get; set; }
        public bool Ativo { get; set; }

        private void AdicionarNovoItem(ItemPedido itemPedido)
        {
            Itens.Add(itemPedido);
        }

        private void AtualizarStatusPedido()
        {
            if (Status == StatusPedido.Cancelado)
                throw new Exception("O pedido já foi cancelado e não pode ter seu status alterado");
        }

        private void CalcularTotalPedido()
        {
            if (Itens.Count() == 0)
                throw new Exception("Não há nenhum item na lista");

            ValorTotal = Itens.Sum(x => x.ValorTotal) + TaxaEntrega;
        }
    }
}