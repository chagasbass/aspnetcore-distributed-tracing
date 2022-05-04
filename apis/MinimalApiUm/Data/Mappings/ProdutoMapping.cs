using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinimalApiUm.Domain.Entities;

namespace MinimalApiUm.Data.Mappings
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("TB_PRODUTOS");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                   .IsRequired();

            builder.Property(x => x.Preco)
                  .IsRequired();

            builder.Property(x => x.CategoriaId)
                  .IsRequired();

            builder.Property(x => x.NomeCategoria)
                 .IsRequired();
        }
    }
}
