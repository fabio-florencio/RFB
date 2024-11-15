﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RFB.Data;

#nullable disable

namespace RFB.Migrations
{
    [DbContext(typeof(RFBContext))]
    [Migration("20241015230550_Add_Tabela_Qualificacao_Socio")]
    partial class Add_Tabela_Qualificacao_Socio
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RFB.Models.Cnae", b =>
                {
                    b.Property<string>("Codigo")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.HasKey("Codigo");

                    b.ToTable("Cnae");
                });

            modelBuilder.Entity("RFB.Models.NaturezaJuridica", b =>
                {
                    b.Property<string>("Codigo")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.HasKey("Codigo");

                    b.ToTable("NaturezasJuridicas");
                });

            modelBuilder.Entity("RFB.Models.QualificacaoSocio", b =>
                {
                    b.Property<string>("Codigo")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.HasKey("Codigo");

                    b.ToTable("QualificacoesSocios");
                });
#pragma warning restore 612, 618
        }
    }
}
