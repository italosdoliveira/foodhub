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
        private readonly IMapper _mapper;
        private readonly Mock<IPedidoRepository> _repository;
        private readonly IPedidoService _pedidoService;

        public TestePedidoService()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>(); 
            }, null);

            config.AssertConfigurationIsValid();
            _mapper = config.CreateMapper();

            _repository = new Mock<IPedidoRepository>();
            _pedidoService = new PedidoService(_mapper, _repository.Object);
        }
    }
}
