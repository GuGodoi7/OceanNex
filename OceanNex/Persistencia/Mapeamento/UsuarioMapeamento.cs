using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OceanNex.Models;

namespace OceanNex.Persistencia.Mapeamento
{
    public class UsuarioMapeamento : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("T_ONX_USUARIO");

            builder.Property(u => u.Telefone)
            .IsRequired()
            .HasColumnName("nr_telefone")
            .HasAnnotation("Telefone", "O campo Telefone é obrigatorio");
        }
    }
}
