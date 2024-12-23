﻿// <auto-generated />
using System;
using LabProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LabProject.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241119212509_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("LabProject.Models.ContactEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateOnly>("BirthDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("Category")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<int>("OrganizationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(101);

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("phone");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.ToTable("Contacts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BirthDate = new DateOnly(1980, 1, 1),
                            Category = 0,
                            Created = new DateTime(2024, 11, 19, 22, 25, 9, 627, DateTimeKind.Local).AddTicks(9883),
                            Email = "johndoe@gmail.com",
                            FirstName = "John",
                            LastName = "Doe",
                            OrganizationId = 101,
                            PhoneNumber = "123456789"
                        },
                        new
                        {
                            Id = 2,
                            BirthDate = new DateOnly(1980, 1, 1),
                            Category = 0,
                            Created = new DateTime(2024, 11, 19, 22, 25, 9, 627, DateTimeKind.Local).AddTicks(9924),
                            Email = "paulfoe@gmail.com",
                            FirstName = "Paul",
                            LastName = "Foe",
                            OrganizationId = 101,
                            PhoneNumber = "123456789"
                        });
                });

            modelBuilder.Entity("LabProject.Models.OrganizationEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("NIP")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("REGON")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Organizations", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 101,
                            NIP = "123456",
                            Name = "Wsei",
                            REGON = "929382382"
                        },
                        new
                        {
                            Id = 102,
                            NIP = "654321",
                            Name = "Halo",
                            REGON = "929382382"
                        });
                });

            modelBuilder.Entity("LabProject.Models.ContactEntity", b =>
                {
                    b.HasOne("LabProject.Models.OrganizationEntity", "Organization")
                        .WithMany("Contacts")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("LabProject.Models.OrganizationEntity", b =>
                {
                    b.OwnsOne("LabProject.Models.Adress", "Adress", b1 =>
                        {
                            b1.Property<int>("OrganizationEntityId")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.HasKey("OrganizationEntityId");

                            b1.ToTable("Organizations");

                            b1.WithOwner()
                                .HasForeignKey("OrganizationEntityId");

                            b1.HasData(
                                new
                                {
                                    OrganizationEntityId = 101,
                                    City = "Krakow",
                                    Street = "sw. Filipa 17"
                                },
                                new
                                {
                                    OrganizationEntityId = 102,
                                    City = "Lodz",
                                    Street = "Dworcowa"
                                });
                        });

                    b.Navigation("Adress")
                        .IsRequired();
                });

            modelBuilder.Entity("LabProject.Models.OrganizationEntity", b =>
                {
                    b.Navigation("Contacts");
                });
#pragma warning restore 612, 618
        }
    }
}
