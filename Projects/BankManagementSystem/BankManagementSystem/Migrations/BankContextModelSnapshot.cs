﻿// <auto-generated />
using System;
using BankManagementSystem.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BankManagementSystem.Migrations
{
    [DbContext(typeof(BankContext))]
    partial class BankContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BankManagementSystem.Models.Bank", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Banks");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d1a42d40-2ea8-49bc-baa6-0ff92bbb4c3b"),
                            Address = "Guliston",
                            Name = "Eskhata"
                        });
                });

            modelBuilder.Entity("BankManagementSystem.Models.Branch", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("BankId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("BankId");

                    b.ToTable("Branchs");

                    b.HasData(
                        new
                        {
                            Id = new Guid("3c92694e-a4d1-4a26-8f73-2ce52298e129"),
                            Address = "Station",
                            BankId = new Guid("d1a42d40-2ea8-49bc-baa6-0ff92bbb4c3b")
                        },
                        new
                        {
                            Id = new Guid("a4aa9f5a-7763-4f4f-b117-e881df9fe828"),
                            Address = "Guliston, Glavnoy",
                            BankId = new Guid("d1a42d40-2ea8-49bc-baa6-0ff92bbb4c3b")
                        });
                });

            modelBuilder.Entity("BankManagementSystem.Models.Department", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BankId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BankId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("BankManagementSystem.Models.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("Birthday")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("BranchId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasDefaultValue("Nabijon");

                    b.Property<string>("FullName2")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("nvarchar(max)")
                        .HasComputedColumnSql("CONCAT(FirstName, ' ', LastName)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Persons");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Person");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("BankManagementSystem.Models.Client", b =>
                {
                    b.HasBaseType("BankManagementSystem.Models.Person");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasIndex("BranchId");

                    b.HasDiscriminator().HasValue("Client");

                    b.HasData(
                        new
                        {
                            Id = new Guid("0c0b0f17-f960-4195-8578-1a4e1c3de833"),
                            Birthday = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            BranchId = new Guid("3c92694e-a4d1-4a26-8f73-2ce52298e129"),
                            FirstName = "Nabijon",
                            Name = "Azamov",
                            State = 0
                        },
                        new
                        {
                            Id = new Guid("0bf276fc-d3dc-4aee-a86d-b68da5cd659b"),
                            Birthday = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            BranchId = new Guid("a4aa9f5a-7763-4f4f-b117-e881df9fe828"),
                            FirstName = "Rahmatillo",
                            Name = "Azamov",
                            State = 0
                        });
                });

            modelBuilder.Entity("BankManagementSystem.Models.Worker", b =>
                {
                    b.HasBaseType("BankManagementSystem.Models.Person");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("BranchId");

                    b.HasDiscriminator().HasValue("Worker");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f5e1467e-6e58-4df2-8a41-4bcd6b888c72"),
                            Birthday = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            BranchId = new Guid("3c92694e-a4d1-4a26-8f73-2ce52298e129"),
                            FirstName = "Yoqubjon",
                            Name = "Ahmedov"
                        },
                        new
                        {
                            Id = new Guid("6f8fcd85-9f54-4308-b337-3df159256be3"),
                            Birthday = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            BranchId = new Guid("a4aa9f5a-7763-4f4f-b117-e881df9fe828"),
                            FirstName = "Abdurasul",
                            Name = "Abdurahmonov"
                        });
                });

            modelBuilder.Entity("BankManagementSystem.Models.Branch", b =>
                {
                    b.HasOne("BankManagementSystem.Models.Bank", "Bank")
                        .WithMany("Branchs")
                        .HasForeignKey("BankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bank");
                });

            modelBuilder.Entity("BankManagementSystem.Models.Department", b =>
                {
                    b.HasOne("BankManagementSystem.Models.Bank", "Bank")
                        .WithMany("Departments")
                        .HasForeignKey("BankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bank");
                });

            modelBuilder.Entity("BankManagementSystem.Models.Client", b =>
                {
                    b.HasOne("BankManagementSystem.Models.Branch", "Branch")
                        .WithMany("Clients")
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Branch");
                });

            modelBuilder.Entity("BankManagementSystem.Models.Worker", b =>
                {
                    b.HasOne("BankManagementSystem.Models.Branch", "Branch")
                        .WithMany("Workers")
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Branch");
                });

            modelBuilder.Entity("BankManagementSystem.Models.Bank", b =>
                {
                    b.Navigation("Branchs");

                    b.Navigation("Departments");
                });

            modelBuilder.Entity("BankManagementSystem.Models.Branch", b =>
                {
                    b.Navigation("Clients");

                    b.Navigation("Workers");
                });
#pragma warning restore 612, 618
        }
    }
}