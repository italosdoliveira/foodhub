using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;

namespace Infra.Data.Context
{
    public class ApplicationMongoDbContext : DbContext
    {
        public DbSet<Pedido> Pedidos { get; init; }

        public ApplicationMongoDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Pedido>().ToCollection("pedidos");
        }
    }
}
