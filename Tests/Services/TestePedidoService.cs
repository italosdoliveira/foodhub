using Application.Services;
using Domain.Dtos;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Moq;

namespace Tests.Services
{
    public class TestePedidoService
    {
        private readonly Mock<IPedidoRepository> _repository;
        private readonly IPedidoService _pedidoService;

        public TestePedidoService()
        {
            _repository = new Mock<IPedidoRepository>();
            _pedidoService = new PedidoService(_repository.Object);
        }

        [Fact]
        public async void AdicionarPedido_RetornaDtoPedidoAdicionadoComSucesso()
        {
            var pedido = new Pedido()
            {
                Codigo = "12345",
                DataHora = DateTime.Now,
                ClienteId = "1346",     
                ClienteNome = "Cliente Teste",
                RestauranteId = "1678",
                RestauranteNome = "Restaurante Teste",
                Itens = new List<ItemPedido>()
                {
                    new ItemPedido()
                    {
                        ProdutoId = "1",
                        ProdutoDescricao = "Produto Teste 1",
                        Quantidade = 2,
                        PrecoUnitario = 10.00m
                    },
                    new ItemPedido()
                    {
                        ProdutoId = "2",
                        ProdutoDescricao = "Produto Teste 2",
                        Quantidade = 1,
                        PrecoUnitario = 20.00m
                    }
                },
                Status = Domain.Enums.StatusPedido.Pendente,
                Tipo = Domain.Enums.TipoPedido.Delivery
            };
            pedido.CalcularTotalPedido();

            var pedidoDto = new PedidoDto(pedido);

            _repository.Setup(r => r.AdicionarPedido(pedido))
                       .ReturnsAsync(pedido);

            var resultado = await _pedidoService.AdicionarPedido(pedido);

            Assert.NotNull(resultado);
            Assert.IsType<PedidoDto>(resultado);
            Assert.Equal(pedidoDto.Codigo, resultado.Codigo);
        }

        [Fact]
        public async void AtualizarPedido_RetornaDtoPedidoAtualizadoComSucesso()
        {
            var pedidoOriginal = new Pedido()
            {
                Codigo = "12345",
                DataHora = DateTime.Now,
                ClienteId = "1346",
                ClienteNome = "Cliente Teste",
                RestauranteId = "1678",
                RestauranteNome = "Restaurante Teste",
                Itens = new List<ItemPedido>()
                {
                    new ItemPedido()
                    {
                        ProdutoId = "1",
                        ProdutoDescricao = "Produto Teste 1",
                        Quantidade = 2,
                        PrecoUnitario = 10.00m
                    },
                    new ItemPedido()
                    {
                        ProdutoId = "2",
                        ProdutoDescricao = "Produto Teste 2",
                        Quantidade = 1,
                        PrecoUnitario = 20.00m
                    }
                },
                Status = Domain.Enums.StatusPedido.Pendente,
                Tipo = Domain.Enums.TipoPedido.Delivery
            };
            pedidoOriginal.CalcularTotalPedido();

            var pedidoAtualizado = new Pedido()
            {
                Codigo = "12345",
                DataHora = DateTime.Now,
                ClienteId = "1348",
                ClienteNome = "Cliente Teste",
                RestauranteId = "1678",
                RestauranteNome = "Restaurante Teste",
                Itens = new List<ItemPedido>()
                {
                    new ItemPedido()
                    {
                        ProdutoId = "1",
                        ProdutoDescricao = "Produto Teste 1",
                        Quantidade = 2,
                        PrecoUnitario = 10.00m
                    },
                    new ItemPedido()
                    {
                        ProdutoId = "2",
                        ProdutoDescricao = "Produto Teste 2",
                        Quantidade = 1,
                        PrecoUnitario = 20.00m
                    }
                },
                Status = Domain.Enums.StatusPedido.Pendente,
                Tipo = Domain.Enums.TipoPedido.Delivery
            };

            var pedidoDto = new PedidoDto(pedidoAtualizado);

            _repository.Setup(r => r.AtualizarPedido(pedidoOriginal.Id, pedidoOriginal))
                       .ReturnsAsync(pedidoAtualizado);

            var resultado = await _pedidoService.AtualizarPedido(pedidoOriginal.Id, pedidoOriginal);

            Assert.NotNull(resultado);
            Assert.IsType<PedidoDto>(resultado);
            Assert.Equal(pedidoDto.ClienteId, resultado.ClienteId);
        }

        [Fact]
        public async void AtualizarStatusPedido_RetornaDtoPedidoAtualizadoComSucesso()
        {
            var pedidoOriginal = new Pedido()
            {
                Codigo = "12345",
                DataHora = DateTime.Now,
                ClienteId = "1346",
                ClienteNome = "Cliente Teste",
                RestauranteId = "1678",
                RestauranteNome = "Restaurante Teste",
                Itens = new List<ItemPedido>()
                {
                    new ItemPedido()
                    {
                        ProdutoId = "1",
                        ProdutoDescricao = "Produto Teste 1",
                        Quantidade = 2,
                        PrecoUnitario = 10.00m
                    },
                    new ItemPedido()
                    {
                        ProdutoId = "2",
                        ProdutoDescricao = "Produto Teste 2",
                        Quantidade = 1,
                        PrecoUnitario = 20.00m
                    }
                },
                Status = Domain.Enums.StatusPedido.Pendente,
                Tipo = Domain.Enums.TipoPedido.Delivery
            };
            pedidoOriginal.CalcularTotalPedido();

            var pedidoAtualizado = new Pedido()
            {
                Codigo = "12345",
                DataHora = DateTime.Now,
                ClienteId = "1348",
                ClienteNome = "Cliente Teste",
                RestauranteId = "1678",
                RestauranteNome = "Restaurante Teste",
                Itens = new List<ItemPedido>()
                {
                    new ItemPedido()
                    {
                        ProdutoId = "1",
                        ProdutoDescricao = "Produto Teste 1",
                        Quantidade = 2,
                        PrecoUnitario = 10.00m
                    },
                    new ItemPedido()
                    {
                        ProdutoId = "2",
                        ProdutoDescricao = "Produto Teste 2",
                        Quantidade = 1,
                        PrecoUnitario = 20.00m
                    }
                },
                Status = Domain.Enums.StatusPedido.Confirmado,
                Tipo = Domain.Enums.TipoPedido.Delivery
            };

            var pedidoDto = new PedidoDto(pedidoAtualizado);

            _repository.Setup(r => r.AtualizarStatusPedido(pedidoOriginal.Id, Domain.Enums.StatusPedido.Confirmado))
                       .ReturnsAsync(pedidoAtualizado);

            var resultado = await _pedidoService.AtualizarStatusPedido(pedidoOriginal.Id, Domain.Enums.StatusPedido.Confirmado);

            Assert.NotNull(resultado);
            Assert.IsType<PedidoDto>(resultado);
            Assert.Equal(pedidoDto.Status, resultado.Status);
        }

        [Fact]
        public async void BuscarPedidoPeloCodigo_RetornaPedidoComSucesso()
        {
            var pedido = new Pedido()
            {
                Codigo = "12345",
                DataHora = DateTime.Now,
                ClienteId = "1346",
                ClienteNome = "Cliente Teste",
                RestauranteId = "1678",
                RestauranteNome = "Restaurante Teste",
                Itens = new List<ItemPedido>()
                {
                    new ItemPedido()
                    {
                        ProdutoId = "1",
                        ProdutoDescricao = "Produto Teste 1",
                        Quantidade = 2,
                        PrecoUnitario = 10.00m
                    },
                    new ItemPedido()
                    {
                        ProdutoId = "2",
                        ProdutoDescricao = "Produto Teste 2",
                        Quantidade = 1,
                        PrecoUnitario = 20.00m
                    }
                },
                Status = Domain.Enums.StatusPedido.Pendente,
                Tipo = Domain.Enums.TipoPedido.Delivery
            };
            pedido.CalcularTotalPedido();

            var pedidoDto = new PedidoDto(pedido);

            _repository.Setup(r => r.BuscarPedidoPeloCodigo("12345"))
                       .ReturnsAsync(pedido);

            var resultado = await _pedidoService.BuscarPedidoPeloCodigo("12345");

            Assert.NotNull(resultado);
            Assert.IsType<PedidoDto>(resultado);
            Assert.Equal(pedidoDto.Codigo, resultado.Codigo);
        }

        [Fact]
        public async void DeletarPedido_RetornaVerdadeiroAoDeletarComSucesso()
        {
            var pedidoId = MongoDB.Bson.ObjectId.GenerateNewId();
            _repository.Setup(r => r.DeletarPedido(pedidoId))
                       .ReturnsAsync(true);
            var resultado = await _pedidoService.DeletarPedido(pedidoId);
            Assert.True(resultado);
        }

        [Fact]
        public async void ListarPedido_ListaPedidosComSucesso()
        {
            var pedido = new Pedido()
            {
                Codigo = "12345",
                DataHora = DateTime.Now,
                ClienteId = "1346",
                ClienteNome = "Cliente Teste",
                RestauranteId = "1678",
                RestauranteNome = "Restaurante Teste",
                Itens = new List<ItemPedido>()
                {
                    new ItemPedido()
                    {
                        ProdutoId = "1",
                        ProdutoDescricao = "Produto Teste 1",
                        Quantidade = 2,
                        PrecoUnitario = 10.00m
                    },
                    new ItemPedido()
                    {
                        ProdutoId = "2",
                        ProdutoDescricao = "Produto Teste 2",
                        Quantidade = 1,
                        PrecoUnitario = 20.00m
                    }
                },
                Status = Domain.Enums.StatusPedido.Pendente,
                Tipo = Domain.Enums.TipoPedido.Delivery
            };
            pedido.CalcularTotalPedido();

            var pedidoDto = new PedidoDto(pedido);
            var pedidos = new List<PedidoDto>() { pedidoDto };

            _repository.Setup(r => r.ListarPedido())
                     .ReturnsAsync(new List<Pedido>() { pedido}.AsEnumerable());

            var resultado = await _pedidoService.ListarPedido();

            Assert.NotNull(resultado);
            Assert.Equal(pedidos.Count, resultado.Count());
        }
    }
}
