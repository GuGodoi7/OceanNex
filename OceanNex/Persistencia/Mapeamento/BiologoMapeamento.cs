using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OceanNex.Models;

namespace OceanNex.Persistencia.Mapeamento
{
    public class BiologoMapeamento : IEntityTypeConfiguration<Biologo>
    {
        public void Configure(EntityTypeBuilder<Biologo> builder)
        {
            builder.ToTable("T_ONX_BIOLOGO");

            builder.Property(b => b.NumeroRegistro)
               .IsRequired()
               .HasColumnName("nr_Registro")
               .HasAnnotation("Senha", "O campo Número Registro deve ser preenchido");

            builder.Property(b => b.CPF)
            .HasMaxLength(11)
            .HasColumnName("nr_cpf")
            .HasAnnotation("CPF", "O CPF deve conter no máximo 11 caracteres.");

            builder.Property(b => b.CRBio)
            .HasMaxLength(11)
            .HasAnnotation("CRBio", "O CRBio deve conter no máximo 11 caracteres.");
        }
    }
}
