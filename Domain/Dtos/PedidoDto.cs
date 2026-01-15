using Domain.Entities;

namespace Domain.Dtos
{
    public class PedidoDto
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
        public decimal ValorTotal { get; set; }
        public string Status { get; set; }
        public string Tipo { get; set; }

        public PedidoDto(Pedido pedido)
        {
            Codigo = pedido.Codigo;
            DataHora = pedido.DataHora;
            ClienteId = pedido.ClienteId;
            ClienteNome = pedido.ClienteNome;
            RestauranteId = pedido.RestauranteId;
            RestauranteNome = pedido.RestauranteNome;
            Itens = pedido.Itens;
            TaxaEntrega = pedido.TaxaEntrega;
            CupomDescontoAplicado = pedido.CupomDescontoAplicado;
            ValorTotal = pedido.ValorTotal;
            Status = pedido.Status.ToString();
            Tipo = pedido.Tipo.ToString();
        }
    }
}