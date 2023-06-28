using Clima.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clima.Infrastructure.Configuracion
{
    public class CiudadConfiguracion : IEntityTypeConfiguration<Ciudad>
    {
        public void Configure(EntityTypeBuilder<Ciudad> builder)
        {
            builder.ToTable("CIUDAD");
            builder.HasKey(t => t.Id);

            builder.Property(b => b.Id).HasColumnName("id").IsRequired();

            builder.Property(b => b.Nombre).HasColumnName("nombre");

            builder.Property(b => b.IdPais).HasColumnName("pais_id");
        }
    }
}
