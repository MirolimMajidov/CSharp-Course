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
                            Id = new Guid("644585a2-bb09-4b82-850e-073cf5a621da"),
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
                            Id = new Guid("f8aeba6f-bc3f-4882-905b-bdb3757d0aef"),
                            Address = "Station",
                            BankId = new Guid("644585a2-bb09-4b82-850e-073cf5a621da")
                        },
                        new
                        {
                            Id = new Guid("93dca8f8-cbe7-4746-b1c7-92dc1a8ead31"),
                            Address = "Guliston, Glavnoy",
                            BankId = new Guid("644585a2-bb09-4b82-850e-073cf5a621da")
                        });
                });

            modelBuilder.Entity("BankManagementSystem.Models.Card", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Balance")
                        .HasColumnType("float");

                    b.Property<Guid>("HolderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IssuerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Cards");
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

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Username")
                        .IsUnique()
                        .HasFilter("[Username] IS NOT NULL");

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
                            Id = new Guid("88cc7d6f-5507-4483-a60a-f3257fa36389"),
                            Birthday = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            BranchId = new Guid("f8aeba6f-bc3f-4882-905b-bdb3757d0aef"),
                            FirstName = "Nabijon",
                            LastName = "Azamov",
                            Password = "123",
                            Role = "admin",
                            Username = "Nabijon",
                            State = 0
                        },
                        new
                        {
                            Id = new Guid("130bb2d9-a0bf-4f42-b78c-627b2c10af4c"),
                            Birthday = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            BranchId = new Guid("93dca8f8-cbe7-4746-b1c7-92dc1a8ead31"),
                            FirstName = "Rahmatillo",
                            LastName = "Azamov",
                            Password = "123",
                            Role = "editor",
                            Username = "Tillo",
                            State = 0
                        });
                });

            modelBuilder.Entity("BankManagementSystem.Models.Worker", b =>
                {
                    b.HasBaseType("BankManagementSystem.Models.Person");

                    b.Property<string>("Responsibility")
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("BranchId");

                    b.HasDiscriminator().HasValue("Worker");

                    b.HasData(
                        new
                        {
                            Id = new Guid("58d357c2-d396-4cec-b9ef-5dfa9d0da564"),
                            Birthday = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            BranchId = new Guid("f8aeba6f-bc3f-4882-905b-bdb3757d0aef"),
                            FirstName = "Yoqubjon",
                            LastName = "Ahmedov"
                        },
                        new
                        {
                            Id = new Guid("4a9d760a-4f5b-4e17-b2c6-267924b5b685"),
                            Birthday = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            BranchId = new Guid("93dca8f8-cbe7-4746-b1c7-92dc1a8ead31"),
                            FirstName = "Abdurasul",
                            LastName = "Abdurahmonov"
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
