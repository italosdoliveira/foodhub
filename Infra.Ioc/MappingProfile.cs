using AutoMapper;
using Domain.Dtos;
using Domain.Entities;

namespace Infra.IoC
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AtualizacaoPedidoDto, Pedido>();
        }
    }
}
