using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using simple_todo_list.Models;

namespace simple_todo_list.Infra.Mapeamento
{
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.HasKey(c => c.CategoriaId);
            builder.Property(c => c.Descricao).HasMaxLength(40).IsRequired();
            builder.Property(c => c.Ativo).HasDefaultValue(true);
            builder.ToTable("dbtodolist_categorias");
        }
    }
}