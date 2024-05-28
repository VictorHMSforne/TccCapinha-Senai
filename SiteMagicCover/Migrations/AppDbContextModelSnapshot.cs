﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SiteMagicCover.Context;

#nullable disable

namespace SiteMagicCover.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.30")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("SiteMagicCover.Models.Capinha", b =>
                {
                    b.Property<int>("CapinhaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<bool>("Disponibilidade")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("ImagemThumbUrl")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("ImagemUrl")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.Property<double>("Preco")
                        .HasColumnType("double");

                    b.HasKey("CapinhaId");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Capinhas");
                });

            modelBuilder.Entity("SiteMagicCover.Models.CarrinhoCompraItem", b =>
                {
                    b.Property<int>("CarinhoCompraItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("CapinhaId")
                        .HasColumnType("int");

                    b.Property<string>("CarrinhoCompraId")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("CarinhoCompraItemId");

                    b.HasIndex("CapinhaId");

                    b.ToTable("CarrinhoCompraItens");
                });

            modelBuilder.Entity("SiteMagicCover.Models.Categoria", b =>
                {
                    b.Property<int>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CategoriaNome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.HasKey("CategoriaId");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("SiteMagicCover.Models.Capinha", b =>
                {
                    b.HasOne("SiteMagicCover.Models.Categoria", "Categoria")
                        .WithMany("Capinha")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("SiteMagicCover.Models.CarrinhoCompraItem", b =>
                {
                    b.HasOne("SiteMagicCover.Models.Capinha", "Capinha")
                        .WithMany()
                        .HasForeignKey("CapinhaId");

                    b.Navigation("Capinha");
                });

            modelBuilder.Entity("SiteMagicCover.Models.Categoria", b =>
                {
                    b.Navigation("Capinha");
                });
#pragma warning restore 612, 618
        }
    }
}
