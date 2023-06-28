using Clima.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clima.Infrastructure.Configuracion
{
    public class UsuarioConfiguracion : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("USUARIO");
            builder.HasKey(t => t.Id);

            builder.Property(b => b.Id).HasColumnName("id").IsRequired();

            builder.Property(b => b.Nombre).HasColumnName("nombre");

            builder.Property(b => b.Password).HasColumnName("password");

            builder.Property(b => b.Mail).HasColumnName("mail");
        }
    }
}
