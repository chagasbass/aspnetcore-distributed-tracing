using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinimalApiDois.Domain.Entities;

namespace MinimalApiDois.Data.Mappings
{
    public class CategoriaMapping : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("TB_CATEGORIA");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                   .IsRequired();
        }
    }
}
