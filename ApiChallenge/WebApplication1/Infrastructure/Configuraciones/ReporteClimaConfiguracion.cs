using Clima.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clima.Infrastructure.Configuracion
{
    public class ReporteClimaConfiguracion : IEntityTypeConfiguration<ReporteClima>
    {
        public void Configure(EntityTypeBuilder<ReporteClima> builder)
        {
            builder.ToTable("REPORTE_CLIMA");
            builder.HasKey(t => t.Id);

            builder.Property(b => b.Id).HasColumnName("id").IsRequired();

            builder.Property(b => b.DiaSemana).HasColumnName("dia_semana");

            builder.Property(b => b.Humedad).HasColumnName("humedad");

            builder.Property(b => b.VelocidadViento).HasColumnName("velocidad_viento");

            builder.Property(b => b.ProbPrecipitaciones).HasColumnName("prob_precipitaciones");

            builder.Property(b => b.Grados).HasColumnName("grados");

            builder.Property(b => b.Estado).HasColumnName("estado");

            builder.Property(b => b.Ciudad).HasColumnName("ciudad_id");

            builder.Property(b => b.Pais).HasColumnName("pais_id");

        }
    }
}
