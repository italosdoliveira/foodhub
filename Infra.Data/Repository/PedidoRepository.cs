using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;

namespace Infra.Data.Repository
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly ApplicationMongoDbContext _dbContext;

        public PedidoRepository(ApplicationMongoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Pedido> AdicionarPedido(Pedido pedido)
        {
            await _dbContext.Pedidos.AddAsync(pedido);
            await _dbContext.SaveChangesAsync();

            return pedido;
        }

        public async Task<Pedido> AtualizarPedido(Pedido pedido)
        {
            var pedidoDb = await _dbContext.Pedidos.Where(p => p.Codigo == pedido.Codigo).FirstOrDefaultAsync();

            if (pedidoDb is null)
                return null;

            await _dbContext.SaveChangesAsync();

            return pedidoDb;
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
    }
}
