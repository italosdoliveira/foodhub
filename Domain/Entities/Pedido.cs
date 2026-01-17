using Domain.Enums;
using Domain.Events;

namespace Domain.Entities
{
    public class Pedido : Entity
    {
        public string Codigo { get; set; }
        public DateTime DataHora { get; set; }
        public string ClienteId { get; set; }
        public string? ClienteNome { get; set; }
        public string RestauranteId { get; set; }
        public string? RestauranteNome { get; set; }
        public List<ItemPedido> Itens { get; set; } = new();
        public decimal TaxaEntrega { get; set; }
        public string? CupomDescontoAplicado { get; set; }
        public decimal ValorTotal { get; private set; }
        public StatusPedido Status { get; set; }
        public TipoPedido Tipo { get; set; }

        public void AdicionarNovoItem(ItemPedido itemPedido)
        {
            Itens.Add(itemPedido);

            CalcularTotalPedido();
        }

        public void AtualizarStatusPedido(StatusPedido novoStatus)
        {
            if (Status == StatusPedido.Cancelado)
            {
                AddDomainEvent(new PedidoCanceladoEvent(this));
                throw new InvalidOperationException("O pedido já foi cancelado e não pode ter seu status alterado");
            }

            Status = novoStatus;
        }

        public void CalcularTotalPedido()
        {
            if (Itens.Count() == 0)
                throw new Exception("Não há nenhum item na lista de itens do pedido");

            ValorTotal = Itens.Sum(x => x.ValorTotal) + TaxaEntrega;
        }
    }

    public class ItemPedido
    {
        public string ProdutoId { get; set; }
        public string? ProdutoDescricao { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public string? Observacoes { get; set; }
        public decimal ValorAdicionais { get; set; }
        public decimal ValorTotal => (PrecoUnitario * Quantidade) + ValorAdicionais;
    }
}