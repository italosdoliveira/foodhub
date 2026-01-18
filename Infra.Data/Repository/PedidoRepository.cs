using Domain.Entities;
using Domain.Enums;
using Domain.Events;
using Domain.Interfaces.Repositories;
using Infra.Data.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;

namespace Infra.Data.Repository
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly IMediator _mediator;
        private readonly ApplicationMongoDbContext _dbContext;

        public PedidoRepository(IMediator mediator, ApplicationMongoDbContext dbContext)
        {
            _mediator = mediator;
            _dbContext = dbContext;
        }

        public async Task<Pedido> AdicionarPedido(Pedido pedido)
        {
            await _dbContext.Pedidos.AddAsync(pedido);
            pedido.AddDomainEvent(new PedidoCriadoEvent(pedido));
            await _dbContext.SaveChangesAsync();

            return pedido;
        }

        public async Task<Pedido> AtualizarPedido(ObjectId id, Pedido pedido)
        {
            var pedidoDb = await _dbContext.Pedidos.Where(p => p.Id == id).FirstOrDefaultAsync();

            if (pedidoDb is null)
                return null;

            pedidoDb.Codigo = pedido.Codigo;
            pedidoDb.DataHora = pedido.DataHora;
            pedidoDb.ClienteId = pedido.ClienteId;
            pedidoDb.ClienteNome = pedido.ClienteNome;
            pedidoDb.RestauranteId = pedido.RestauranteId;
            pedidoDb.RestauranteNome = pedido.RestauranteNome;
            pedidoDb.TaxaEntrega = pedido.TaxaEntrega;
            pedidoDb.CupomDescontoAplicado = pedido.CupomDescontoAplicado;
            pedidoDb.Status = pedido.Status;
            pedidoDb.Tipo = pedido.Tipo;

            if (pedidoDb.Itens.Any() && pedido.Itens.Any())
            {
                pedidoDb.Itens = pedido.Itens;
            }

            pedidoDb.CalcularTotalPedido();

            pedidoDb.AddDomainEvent(new PedidoAtualizadoEvent(pedido));

            await _dbContext.SaveChangesAsync();

            DispatchDomainEvents(pedido._domainEvents);

            return pedidoDb;
        }

        public async Task<Pedido> AtualizarStatusPedido(ObjectId id, StatusPedido novoStatusPedido)
        {
            try
            {
                var pedidoDb = await _dbContext.Pedidos.Where(p => p.Id == id).FirstOrDefaultAsync();

                if (pedidoDb is null)
                    return null;

                pedidoDb.AtualizarStatusPedido(novoStatusPedido);

                await _dbContext.SaveChangesAsync();

                DispatchDomainEvents(pedidoDb._domainEvents);

                return pedidoDb;
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        public async Task<Pedido> BuscarPedidoPeloCodigo(string codigo)
        {
            var pedido = await _dbContext.Pedidos.Where(p => p.Codigo == codigo).FirstOrDefaultAsync();

            return pedido;
        }

        public async Task<bool> DeletarPedido(ObjectId id)
        {
            var pedido = await _dbContext.Pedidos.Where(p => p.Id == id).FirstOrDefaultAsync();

            if (pedido is null)
                return false;

            _dbContext.Pedidos.Remove(pedido);
            await _dbContext.SaveChangesAsync();
            
            return true;
        }

        public async Task<IEnumerable<Pedido>> ListarPedido()
        {
            var pedidos = await _dbContext.Pedidos.ToListAsync();

            return pedidos.AsEnumerable();
        }

        private void DispatchDomainEvents(List<INotification> domainEvents)
        {
            if (domainEvents is null || !domainEvents.Any())
                return;

            foreach (var domainEvent in domainEvents)
            {
                _mediator.Publish(domainEvent);
            }
        }

    }
}
