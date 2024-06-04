using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OceanNex.Models;

namespace OceanNex.Persistencia.Mapeamento
{
    public class FeedBackPredicaoMapeamento : IEntityTypeConfiguration<FeedBackPredicao>
    {
        public void Configure(EntityTypeBuilder<FeedBackPredicao> builder)
        {
            builder.ToTable("T_ONX_FEEDBACK_PREDICAO");

            builder.HasKey(b => b.FeedBackPredicaoId);

            builder.Property(b => b.FeedBackPredicaoId)
            .HasColumnName("id_feedback_postagem");

            builder.Property(b => b.StatusFeedBackPredicao)
            .IsRequired()
            .HasColumnName("st_feedback_postagem")
            .HasAnnotation("DescricaoFeedBackPredicao", "O campo Titulo é obrigatorio");

            builder.Property(b => b.DescricaoFeedBackPredicao)
            .IsRequired()
            .HasColumnName("ds_feedback_postagem")
            .HasAnnotation("DescricaoFeedBackPredicao", "O campo Titulo é obrigatorio");
        }
    }
}
