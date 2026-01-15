namespace Domain.Enums
{
    public enum StatusPedido
    {
        Pendente = 0,
        Confirmado = 1,
        EmPreparo = 2,
        Pronto = 3,
        Entregue = 4,
        Cancelado = 5
    }

    public enum TipoPedido
    {
        Delivery = 0,
        Retirada = 1,
        Mesa = 2
    }
}
