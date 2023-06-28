using Clima.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clima.Infrastructure.Configuracion
{
    public class PaisConfiguracion : IEntityTypeConfiguration<Pais>
    {
        public void Configure(EntityTypeBuilder<Pais> builder)
        {
            builder.ToTable("PAIS");
            builder.HasKey(t => t.Id);

            builder.Property(b => b.Id).HasColumnName("id").IsRequired();

            builder.Property(b => b.Nombre).HasColumnName("nombre");
        }
    }
}
