﻿// <auto-generated />
using DepositManager.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;

#nullable disable

namespace DepositManager.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.12");

            modelBuilder.Entity("DepositManager.Data.Bank", b =>
                {
                    b.Property<Guid>("BankId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("BankName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("BankId");

                    b.ToTable("Banks");

                    b.HasData(
                        new
                        {
                            BankId = new Guid("ca7d0348-051c-4c7d-8ad0-8e24d7e8b185"),
                            BankName = "FNB"
                        },
                        new
                        {
                            BankId = new Guid("8fbe2ff0-510a-432e-8d65-003287ab1062"),
                            BankName = "ERIE"
                        },
                        new
                        {
                            BankId = new Guid("5f33f20c-70d5-4f97-9345-317990a8ac49"),
                            BankName = "Unassigned"
                        });
                });

            modelBuilder.Entity("DepositManager.Data.Check", b =>
                {
                    b.Property<Guid>("CheckId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Amount")
                        .HasColumnType("TEXT");

                    b.Property<string>("CustomerName")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("DepositId")
                        .HasColumnType("TEXT");

                    b.Property<double>("ReferenceNum")
                        .HasColumnType("REAL");

                    b.HasKey("CheckId");

                    b.HasIndex("DepositId");

                    b.ToTable("Check");

                    b.HasData(
                        new
                        {
                            CheckId = new Guid("0b9d3461-5a98-4f05-a1ae-faefaaff5b31"),
                            Amount = 15.25m,
                            CustomerName = "Free To Choose",
                            ReferenceNum = 1562.0
                        },
                        new
                        {
                            CheckId = new Guid("4e381693-780a-4ff7-87c6-35841e79391c"),
                            Amount = 2560.3m,
                            CustomerName = "Humes",
                            ReferenceNum = 125.0
                        });
                });

            modelBuilder.Entity("DepositManager.Data.Deposit", b =>
                {
                    b.Property<Guid>("DepositId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("BankId")
                        .HasColumnType("TEXT");

                    b.Property<decimal?>("Cash")
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("TEXT");

                    b.Property<bool>("DepositStatus")
                        .HasColumnType("INTEGER");

                    b.HasKey("DepositId");

                    b.HasIndex("BankId");

                    b.ToTable("Deposit");
                });

            modelBuilder.Entity("DepositManager.Data.Check", b =>
                {
                    b.HasOne("DepositManager.Data.Deposit", "Deposit")
                        .WithMany()
                        .HasForeignKey("DepositId");

                    b.Navigation("Deposit");
                });

            modelBuilder.Entity("DepositManager.Data.Deposit", b =>
                {
                    b.HasOne("DepositManager.Data.Bank", "Bank")
                        .WithMany()
                        .HasForeignKey("BankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bank");
                });
#pragma warning restore 612, 618
        }
    }
}
