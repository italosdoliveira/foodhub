namespace Tests.Entities
{
    public class TestePedido
    {
        [Fact]
        public void AdicionarNovoItem_AdicionaItemComSucesso()
        {
            var pedido = new Domain.Entities.Pedido();
            var itemPedido = new Domain.Entities.ItemPedido
            {
                ProdutoId = "produto123",
                ProdutoDescricao = "Produto Teste",
                Quantidade = 2,
                PrecoUnitario = 50.0m
            };
            pedido.AdicionarNovoItem(itemPedido);

            Assert.Single(pedido.Itens);
        }

        [Fact]
        public void AtualizarStatusPedido_AlteraStatusComSucesso()
        {
            var pedido = new Domain.Entities.Pedido
            {
                Status = Domain.Enums.StatusPedido.EmPreparo
            };
            pedido.AtualizarStatusPedido(Domain.Enums.StatusPedido.Entregue);
            Assert.Equal(Domain.Enums.StatusPedido.Entregue, pedido.Status);
        }

        [Fact]
        public void AtualizarStatusPedido_RetornaException()
        {
            var pedido = new Domain.Entities.Pedido
            {
                Status = Domain.Enums.StatusPedido.Cancelado
            };

            Assert.Throws<InvalidOperationException>(() =>
            {
                pedido.AtualizarStatusPedido(Domain.Enums.StatusPedido.Entregue);
            });
        }

        [Fact]
        public void CalcularTotalPedido_CalculaTotalComSucesso()
        {
            var pedido = new Domain.Entities.Pedido
            {
                TaxaEntrega = 10.0m
            };
            var itemPedido1 = new Domain.Entities.ItemPedido
            {
                ProdutoId = "produto123",
                ProdutoDescricao = "Produto Teste 1",
                Quantidade = 2,
                PrecoUnitario = 50.0m
            };
            var itemPedido2 = new Domain.Entities.ItemPedido
            {
                ProdutoId = "produto456",
                ProdutoDescricao = "Produto Teste 2",
                Quantidade = 1,
                PrecoUnitario = 30.0m
            };
            pedido.AdicionarNovoItem(itemPedido1);
            pedido.AdicionarNovoItem(itemPedido2);
            pedido.CalcularTotalPedido();
            Assert.Equal(140.0m, pedido.ValorTotal);
        }

        [Fact]
        public void CalcularTotalPedido_RetornaExcpetion()
        {
            var pedido = new Domain.Entities.Pedido
            {
                TaxaEntrega = 10.0m
            };
    
            Assert.Throws<Exception>(() =>
            {
                pedido.CalcularTotalPedido();
            });
        }
    }
}
