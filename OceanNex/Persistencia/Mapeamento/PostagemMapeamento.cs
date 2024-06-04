using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OceanNex.Models;

namespace OceanNex.Persistencia.Mapeamento
{
    public class PostagemMapeamento : IEntityTypeConfiguration<Postagem>
    {
        public void Configure(EntityTypeBuilder<Postagem> builder)
        {
            builder.ToTable("T_ONX_POSTAGEM");

            builder.HasKey(b => b.PostagemId);

            builder.Property(b => b.PostagemId)
            .HasColumnName("id_postagem");

            builder.Property(b => b.Titulo)
            .IsRequired()
            .HasColumnName("nm_titulo")
            .HasAnnotation("Titulo", "O campo Titulo é obrigatorio");

            builder.Property(b => b.Bibliografia)
            .IsRequired()
            .HasColumnName("ds_bibliografia")
            .HasAnnotation("Titulo", "O campo Titulo é obrigatorio");

            builder.Property(b => b.Conteudo)
            .IsRequired()
            .HasColumnName("ds_conteudo")
            .HasAnnotation("Conteudo", "O campo Conteudo é obrigatorio");
        }
    }
}
