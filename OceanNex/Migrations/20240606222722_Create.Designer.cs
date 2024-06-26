﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OceanNex.Persistencia;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace OceanNex.Migrations
{
    [DbContext(typeof(OracleFIAPDbContext))]
    [Migration("20240606222722_Create")]
    partial class Create
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OceanNex.Models.Conta", b =>
                {
                    b.Property<int>("ContaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("id_conta");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContaId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("ds_email")
                        .HasAnnotation("Email", "O campo Email é obrigatorio");

                    b.Property<string>("NomeConta")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("nm_conta")
                        .HasAnnotation("NomeConta", "O campo Email é obrigatorio");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("ds_senha")
                        .HasAnnotation("Email", "O campo Email é obrigatorio");

                    b.HasKey("ContaId");

                    b.ToTable("T_ONX_CONTA", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("OceanNex.Models.FeedBackPostagem", b =>
                {
                    b.Property<int>("FeedBackPostagemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("id_feedback_postagem");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FeedBackPostagemId"));

                    b.Property<int>("ContaId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("DescricaoFeedBackPostagem")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("ds_feedback_postagem")
                        .HasAnnotation("DescricaoFeedBack", "O campo Titulo é obrigatorio");

                    b.Property<int>("PostagemId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("StatusFeedBackPostagem")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("st_feedback_postagem")
                        .HasAnnotation("FeedBackStatus", "O campo Titulo é obrigatorio");

                    b.HasKey("FeedBackPostagemId");

                    b.HasIndex("ContaId");

                    b.HasIndex("PostagemId");

                    b.ToTable("T_ONX_FEEDBACK_POSTAGEM", (string)null);
                });

            modelBuilder.Entity("OceanNex.Models.FeedBackPredicao", b =>
                {
                    b.Property<int>("FeedBackPredicaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("id_feedback_predicao");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FeedBackPredicaoId"));

                    b.Property<int>("ContaId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("DescricaoFeedBackPredicao")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("ds_feedback_predicao")
                        .HasAnnotation("DescricaoFeedBackPredicao", "O campo Titulo é obrigatorio");

                    b.Property<int?>("PredicaoId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("StatusFeedBackPredicao")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("st_feedback_predicao")
                        .HasAnnotation("DescricaoFeedBackPredicao", "O campo Titulo é obrigatorio");

                    b.HasKey("FeedBackPredicaoId");

                    b.HasIndex("ContaId");

                    b.HasIndex("PredicaoId");

                    b.ToTable("T_ONX_FEEDBACK_PREDICAO", (string)null);
                });

            modelBuilder.Entity("OceanNex.Models.Postagem", b =>
                {
                    b.Property<int>("PostagemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("id_postagem");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PostagemId"));

                    b.Property<string>("Bibliografia")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("ds_bibliografia")
                        .HasAnnotation("Titulo", "O campo Titulo é obrigatorio");

                    b.Property<int?>("BiologoContaId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("ContaId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Conteudo")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("ds_conteudo")
                        .HasAnnotation("Conteudo", "O campo Conteudo é obrigatorio");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("nm_titulo")
                        .HasAnnotation("Titulo", "O campo Titulo é obrigatorio");

                    b.HasKey("PostagemId");

                    b.HasIndex("BiologoContaId");

                    b.ToTable("T_ONX_POSTAGEM", (string)null);
                });

            modelBuilder.Entity("OceanNex.Models.Predicao", b =>
                {
                    b.Property<int>("PredicaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("id_predicao");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PredicaoId"));

                    b.Property<int>("ContaId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("DescricaoPredicao")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("ds_resultado_predicao")
                        .HasAnnotation("DescricaoPredicao", "O campo Descricao Predicao é obrigatorio");

                    b.Property<string>("TaxaPredicao")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("ds_taxa_predicao")
                        .HasAnnotation("TaxaPredicao", "O campo Taxa Predicao é obrigatorio");

                    b.HasKey("PredicaoId");

                    b.HasIndex("ContaId");

                    b.ToTable("T_ONX_PREDICAO", (string)null);
                });

            modelBuilder.Entity("OceanNex.Models.Biologo", b =>
                {
                    b.HasBaseType("OceanNex.Models.Conta");

                    b.Property<long>("CPF")
                        .HasMaxLength(11)
                        .HasColumnType("NUMBER(19)")
                        .HasColumnName("nr_cpf")
                        .HasAnnotation("CPF", "O CPF deve conter no máximo 11 caracteres.");

                    b.Property<string>("CRBio")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("NVARCHAR2(11)")
                        .HasAnnotation("CRBio", "O CRBio deve conter no máximo 11 caracteres.");

                    b.Property<long>("NumeroRegistro")
                        .HasColumnType("NUMBER(19)")
                        .HasColumnName("nr_Registro")
                        .HasAnnotation("Senha", "O campo Número Registro deve ser preenchido");

                    b.ToTable("T_ONX_BIOLOGO", (string)null);
                });

            modelBuilder.Entity("OceanNex.Models.Usuario", b =>
                {
                    b.HasBaseType("OceanNex.Models.Conta");

                    b.Property<long>("Telefone")
                        .HasColumnType("NUMBER(19)")
                        .HasColumnName("nr_telefone")
                        .HasAnnotation("Telefone", "O campo Telefone é obrigatorio");

                    b.ToTable("T_ONX_USUARIO", (string)null);
                });

            modelBuilder.Entity("OceanNex.Models.FeedBackPostagem", b =>
                {
                    b.HasOne("OceanNex.Models.Conta", "Conta")
                        .WithMany("FeedBackPostagem")
                        .HasForeignKey("ContaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OceanNex.Models.Postagem", "Postagem")
                        .WithMany("FeedBackPostagens")
                        .HasForeignKey("PostagemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Conta");

                    b.Navigation("Postagem");
                });

            modelBuilder.Entity("OceanNex.Models.FeedBackPredicao", b =>
                {
                    b.HasOne("OceanNex.Models.Conta", "Conta")
                        .WithMany("FeedBackPredicao")
                        .HasForeignKey("ContaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OceanNex.Models.Predicao", "Predicao")
                        .WithMany()
                        .HasForeignKey("PredicaoId");

                    b.Navigation("Conta");

                    b.Navigation("Predicao");
                });

            modelBuilder.Entity("OceanNex.Models.Postagem", b =>
                {
                    b.HasOne("OceanNex.Models.Biologo", "Biologo")
                        .WithMany("Postagens")
                        .HasForeignKey("BiologoContaId");

                    b.Navigation("Biologo");
                });

            modelBuilder.Entity("OceanNex.Models.Predicao", b =>
                {
                    b.HasOne("OceanNex.Models.Conta", "Conta")
                        .WithMany("Predicao")
                        .HasForeignKey("ContaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Conta");
                });

            modelBuilder.Entity("OceanNex.Models.Biologo", b =>
                {
                    b.HasOne("OceanNex.Models.Conta", null)
                        .WithOne()
                        .HasForeignKey("OceanNex.Models.Biologo", "ContaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OceanNex.Models.Usuario", b =>
                {
                    b.HasOne("OceanNex.Models.Conta", null)
                        .WithOne()
                        .HasForeignKey("OceanNex.Models.Usuario", "ContaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OceanNex.Models.Conta", b =>
                {
                    b.Navigation("FeedBackPostagem");

                    b.Navigation("FeedBackPredicao");

                    b.Navigation("Predicao");
                });

            modelBuilder.Entity("OceanNex.Models.Postagem", b =>
                {
                    b.Navigation("FeedBackPostagens");
                });

            modelBuilder.Entity("OceanNex.Models.Biologo", b =>
                {
                    b.Navigation("Postagens");
                });
#pragma warning restore 612, 618
        }
    }
}
