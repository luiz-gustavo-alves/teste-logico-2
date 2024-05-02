﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using testeLogicoBTI.Data;

#nullable disable

namespace testeLogico2.Migrations
{
    [DbContext(typeof(AppDBContext))]
    partial class AppDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("testeLogicoBTI.Models.Condutor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("now()");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("now()");

                    b.HasKey("Id");

                    b.ToTable("Condutor");
                });

            modelBuilder.Entity("testeLogicoBTI.Models.Passagem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("AnoAtual")
                        .HasColumnType("integer");

                    b.Property<Guid>("CondutorId")
                        .HasColumnType("uuid");

                    b.Property<int>("Contador")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("now()");

                    b.Property<int>("MesAtual")
                        .HasColumnType("integer");

                    b.Property<Guid>("PedagioId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("now()");

                    b.HasKey("Id");

                    b.HasIndex("CondutorId");

                    b.HasIndex("PedagioId");

                    b.ToTable("Passagem");
                });

            modelBuilder.Entity("testeLogicoBTI.Models.Pedagio", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("now()");

                    b.Property<int>("Preco")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("now()");

                    b.HasKey("Id");

                    b.ToTable("Pedagio");
                });

            modelBuilder.Entity("testeLogicoBTI.Models.Passagem", b =>
                {
                    b.HasOne("testeLogicoBTI.Models.Condutor", "Condutor")
                        .WithMany("Passagem")
                        .HasForeignKey("CondutorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("testeLogicoBTI.Models.Pedagio", "Pedagio")
                        .WithMany("Passagem")
                        .HasForeignKey("PedagioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Condutor");

                    b.Navigation("Pedagio");
                });

            modelBuilder.Entity("testeLogicoBTI.Models.Condutor", b =>
                {
                    b.Navigation("Passagem");
                });

            modelBuilder.Entity("testeLogicoBTI.Models.Pedagio", b =>
                {
                    b.Navigation("Passagem");
                });
#pragma warning restore 612, 618
        }
    }
}
