using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OceanNex.Models;

namespace OceanNex.Persistencia.Mapeamento
{
    public class PredicaoMapeamento : IEntityTypeConfiguration<Predicao>
    {
        public void Configure(EntityTypeBuilder<Predicao> builder)
        {
            builder.ToTable("T_ONX_PREDICAO");

            builder.HasKey(b => b.PredicaoId);

            builder.Property(b => b.PredicaoId)
            .HasColumnName("id_predicao");


            builder.Property(b => b.TaxaPredicao)
            .IsRequired()
            .HasColumnName("ds_taxa_predicao")
            .HasAnnotation("TaxaPredicao", "O campo Taxa Predicao é obrigatorio");

            builder.Property(b => b.DescricaoPredicao)
            .IsRequired()
            .HasColumnName("ds_resultado_predicao")
            .HasAnnotation("DescricaoPredicao", "O campo Descricao Predicao é obrigatorio");
        }
    }
}
