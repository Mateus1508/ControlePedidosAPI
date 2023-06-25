using Controle_de_pedidos.Models;
using Microsoft.EntityFrameworkCore;

namespace Controle_de_pedidos
{
    public class ControlePedidosDbContext : DbContext
    {
        public ControlePedidosDbContext(DbContextOptions<ControlePedidosDbContext> options) : base(options)
        { }

        public DbSet<PedidosModel> Pedidos { get; set; }
        public DbSet<ProdutosModel> Produtos { get; set; }
        public DbSet<ItensDePedidoModel> ItensDePedido { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
