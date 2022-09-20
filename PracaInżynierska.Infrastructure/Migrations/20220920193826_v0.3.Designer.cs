﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PracaInżynierska.Infrastructure;

#nullable disable

namespace PracaInżynierska.Infrastructure.Migrations
{
    [DbContext(typeof(PIDbContext))]
    [Migration("20220920193826_v0.3")]
    partial class v03
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.9");

            modelBuilder.Entity("PracaInżynierska.Domain.Models.AssetType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("AssetType");
                });

            modelBuilder.Entity("PracaInżynierska.Domain.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("PracaInżynierska.Domain.Models.FinancialChange", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AssetTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SentFrom")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SentTo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("TransferId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<float>("Value")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("AssetTypeId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("TransferId");

                    b.HasIndex("UserId");

                    b.ToTable("FinancialChange");
                });

            modelBuilder.Entity("PracaInżynierska.Domain.Models.Transfer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AccountNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SentFrom")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SentTo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Transfer");
                });

            modelBuilder.Entity("PracaInżynierska.Domain.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AutoLoginGUID")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("AutoLoginGUIDExpires")
                        .HasColumnType("TEXT");

                    b.Property<string>("EMail")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("Password")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.HasKey("Id");

                    b.HasIndex("EMail")
                        .IsUnique();

                    b.ToTable("User");
                });

            modelBuilder.Entity("PracaInżynierska.Domain.Models.FinancialChange", b =>
                {
                    b.HasOne("PracaInżynierska.Domain.Models.AssetType", "AssetType")
                        .WithMany()
                        .HasForeignKey("AssetTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PracaInżynierska.Domain.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PracaInżynierska.Domain.Models.Transfer", "Transfer")
                        .WithMany()
                        .HasForeignKey("TransferId");

                    b.HasOne("PracaInżynierska.Domain.Models.User", null)
                        .WithMany("FinancialChanges")
                        .HasForeignKey("UserId");

                    b.Navigation("AssetType");

                    b.Navigation("Category");

                    b.Navigation("Transfer");
                });

            modelBuilder.Entity("PracaInżynierska.Domain.Models.Transfer", b =>
                {
                    b.HasOne("PracaInżynierska.Domain.Models.User", null)
                        .WithMany("Transfers")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("PracaInżynierska.Domain.Models.User", b =>
                {
                    b.Navigation("FinancialChanges");

                    b.Navigation("Transfers");
                });
#pragma warning restore 612, 618
        }
    }
}
