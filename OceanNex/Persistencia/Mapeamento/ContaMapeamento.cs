using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OceanNex.Models;

namespace OceanNex.Persistencia.Mapeamento
{
    public class ContaMapeamento : IEntityTypeConfiguration<Conta>
    {
        public void Configure(EntityTypeBuilder<Conta> builder)
        {
            builder.ToTable("T_ONX_CONTA");

            builder.HasKey(b => b.ContaId);

            builder.Property(b => b.ContaId)
            .HasColumnName("id_conta");

            builder.Property(b => b.NomeConta)
            .IsRequired()
            .HasColumnName("nm_conta")
            .HasAnnotation("NomeConta", "O campo Email é obrigatorio");

            builder.Property(b => b.Email)
            .IsRequired()
            .HasColumnName("ds_email")
            .HasAnnotation("Email", "O campo Email é obrigatorio");

            builder.Property(b => b.Senha)
            .IsRequired()
            .HasColumnName("ds_senha")
            .HasAnnotation("Senha", "O campo Senha é obrigatorio");
        }
    }
}
