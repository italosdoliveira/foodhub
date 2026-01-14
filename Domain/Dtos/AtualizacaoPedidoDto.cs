using Domain.Entities;
using Domain.Enums;

namespace Domain.Dtos
{
    public class AtualizacaoPedidoDto
    {
        public string ClienteId { get; set; }
        public string ClienteNome { get; set; }
        public string RestauranteId { get; set; }
        public string RestauranteNome { get; set; }
        public List<ItemPedido> Itens { get; set; } = new();
        public decimal TaxaEntrega { get; set; }
        public string CupomDescontoAplicado { get; set; }
        public decimal ValorTotal { get; set; }
        public StatusPedido Status { get; set; }
        public TipoPedido Tipo { get; set; }
    }
}
