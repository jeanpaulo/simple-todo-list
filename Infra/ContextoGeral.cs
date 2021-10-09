using Microsoft.EntityFrameworkCore;
using simple_todo_list.Infra.Mapeamento;
using simple_todo_list.Models;

namespace simple_todo_list.Infra
{
    public class ContextoGeral : DbContext
    {
        public ContextoGeral(DbContextOptions<ContextoGeral> options) : base(options)
        {
        }

        public DbSet<Categoria> Categorias { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new CategoriaMap());
        }
    }
}