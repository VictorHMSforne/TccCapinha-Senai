﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SiteMagicCover.Context;

#nullable disable

namespace SiteMagicCover.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240601171920_addColumnNomeCap")]
    partial class addColumnNomeCap
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("NomeCelular")
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

            modelBuilder.Entity("SiteMagicCover.Models.Cliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)");

                    b.HasKey("ClienteId");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("SiteMagicCover.Models.ClienteEndereco", b =>
                {
                    b.Property<int>("ClienteEnderecoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Informacao")
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.HasKey("ClienteEnderecoId");

                    b.HasIndex("ClienteId");

                    b.ToTable("ClientesEndereco");
                });

            modelBuilder.Entity("SiteMagicCover.Models.ClientePedido", b =>
                {
                    b.Property<int>("ClientePedidoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CapinhaId")
                        .HasColumnType("int");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("PedidoEntregueEm")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("PedidoEnviado")
                        .HasColumnType("datetime(6)");

                    b.Property<double>("PedidoTotal")
                        .HasColumnType("double");

                    b.Property<double>("Preco")
                        .HasColumnType("double");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<int>("TotalItensPedido")
                        .HasColumnType("int");

                    b.HasKey("ClientePedidoId");

                    b.HasIndex("CapinhaId");

                    b.HasIndex("ClienteId");

                    b.ToTable("ClientePedido");
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

            modelBuilder.Entity("SiteMagicCover.Models.ClienteEndereco", b =>
                {
                    b.HasOne("SiteMagicCover.Models.Cliente", "Cliente")
                        .WithMany("ClienteEnderecos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("SiteMagicCover.Models.ClientePedido", b =>
                {
                    b.HasOne("SiteMagicCover.Models.Capinha", "Capinha")
                        .WithMany()
                        .HasForeignKey("CapinhaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SiteMagicCover.Models.Cliente", "Cliente")
                        .WithMany("ClientePedidos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Capinha");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("SiteMagicCover.Models.Categoria", b =>
                {
                    b.Navigation("Capinha");
                });

            modelBuilder.Entity("SiteMagicCover.Models.Cliente", b =>
                {
                    b.Navigation("ClienteEnderecos");

                    b.Navigation("ClientePedidos");
                });
#pragma warning restore 612, 618
        }
    }
}