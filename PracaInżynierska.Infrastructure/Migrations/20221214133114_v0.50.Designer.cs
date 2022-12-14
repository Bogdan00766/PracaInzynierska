﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PracaInzynierska.Infrastructure;

#nullable disable

namespace PracaInzynierska.Infrastructure.Migrations
{
    [DbContext(typeof(PIDbContext))]
    [Migration("20221214133114_v0.50")]
    partial class v050
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PracaInzynierska.Domain.Models.AssetType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AssetType");
                });

            modelBuilder.Entity("PracaInzynierska.Domain.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("PracaInzynierska.Domain.Models.FinancialChange", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AssetTypeId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.Property<int?>("ReductionId")
                        .HasColumnType("int");

                    b.Property<string>("SentFrom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SentTo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TransferId")
                        .HasColumnType("int");

                    b.Property<float>("Value")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("AssetTypeId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("OwnerId");

                    b.HasIndex("ReductionId");

                    b.HasIndex("TransferId");

                    b.ToTable("FinancialChange");
                });

            modelBuilder.Entity("PracaInzynierska.Domain.Models.Transfer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AccountNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SentFrom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SentTo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Transfer");
                });

            modelBuilder.Entity("PracaInzynierska.Domain.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AutoLoginGUID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("AutoLoginGUIDExpires")
                        .HasColumnType("datetime2");

                    b.Property<string>("EMail")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Password")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.HasIndex("EMail")
                        .IsUnique();

                    b.ToTable("User");
                });

            modelBuilder.Entity("PracaInzynierska.Domain.Models.FinancialChange", b =>
                {
                    b.HasOne("PracaInzynierska.Domain.Models.AssetType", "AssetType")
                        .WithMany()
                        .HasForeignKey("AssetTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PracaInzynierska.Domain.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PracaInzynierska.Domain.Models.User", "Owner")
                        .WithMany("FinancialChanges")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PracaInzynierska.Domain.Models.FinancialChange", "Reduction")
                        .WithMany()
                        .HasForeignKey("ReductionId");

                    b.HasOne("PracaInzynierska.Domain.Models.Transfer", "Transfer")
                        .WithMany()
                        .HasForeignKey("TransferId");

                    b.Navigation("AssetType");

                    b.Navigation("Category");

                    b.Navigation("Owner");

                    b.Navigation("Reduction");

                    b.Navigation("Transfer");
                });

            modelBuilder.Entity("PracaInzynierska.Domain.Models.Transfer", b =>
                {
                    b.HasOne("PracaInzynierska.Domain.Models.User", null)
                        .WithMany("Transfers")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("PracaInzynierska.Domain.Models.User", b =>
                {
                    b.Navigation("FinancialChanges");

                    b.Navigation("Transfers");
                });
#pragma warning restore 612, 618
        }
    }
}
