using Application.Services;
using AutoMapper;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Infra.IoC;
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
    }
}
