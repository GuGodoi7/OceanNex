using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OceanNex.Models;

namespace OceanNex.Persistencia.Mapeamento
{
    public class FeedBackPostagemMapeamento : IEntityTypeConfiguration<FeedBackPostagem>
    {
        public void Configure(EntityTypeBuilder<FeedBackPostagem> builder)
        {
            builder.ToTable("T_ONX_FEEDBACK_POSTAGEM");

            builder.HasKey(b => b.FeedBackPostagemId);

            builder.Property(b => b.FeedBackPostagemId)
            .HasColumnName("id_feedback_postagem");

            builder.Property(b => b.StatusFeedBackPostagem)
            .IsRequired()
            .HasColumnName("st_feedback_postagem")
            .HasAnnotation("FeedBackStatus", "O campo Titulo é obrigatorio");

            builder.Property(b => b.DescricaoFeedBackPostagem)
            .IsRequired()
            .HasColumnName("ds_feedback_postagem")
            .HasAnnotation("DescricaoFeedBack", "O campo Titulo é obrigatorio");
        }
    }
}
