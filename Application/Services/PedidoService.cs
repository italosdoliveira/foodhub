using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Application.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IMapper _mapper;
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoService(IMapper mapper, IPedidoRepository pedidoRepository)
        {
            _mapper = mapper;
            _pedidoRepository = pedidoRepository;
        }

        public async Task<PedidoDto> AdicionarPedido(Pedido pedido)
        {
            var pedidoAdicionado = await _pedidoRepository.AdicionarPedido(pedido);
            return new PedidoDto(pedidoAdicionado);
        }

        public async Task<PedidoDto> AtualizarPedido(string codigo, AtualizacaoPedidoDto pedido)
        {
            if (codigo is null) 
                throw new Exception("Codigo do pedido deve ser informado");

            var pedidoParaAtualizar = _mapper.Map<AtualizacaoPedidoDto, Pedido>(pedido);
            pedidoParaAtualizar.Codigo = codigo;
            var pedidoAtualizado = await _pedidoRepository.AtualizarPedido(pedidoParaAtualizar);

            return new PedidoDto(pedidoAtualizado);
        }

        public async Task<PedidoDto> BuscarPedidoPeloId(string codigo)
        {
            var pedido = await _pedidoRepository.BuscarPedidoPeloId(codigo);
            return new PedidoDto(pedido);
        }

        public async Task<bool> DeletarPedido(string id)
        {
            return await _pedidoRepository.DeletarPedido(id);
        }

        public async Task<IEnumerable<PedidoDto>> ListarPedido()
        {
            var pedidos = await _pedidoRepository.ListarPedido();
            return pedidos.Select(p => new PedidoDto(p)).AsEnumerable();
        }
    }
}
