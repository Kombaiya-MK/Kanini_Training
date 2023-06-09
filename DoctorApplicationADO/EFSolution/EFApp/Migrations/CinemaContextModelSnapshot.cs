﻿// <auto-generated />
using System;
using EFSampleApp;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EFApp.Migrations
{
    [DbContext(typeof(CinemaContext))]
    partial class CinemaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EFApp.Booking", b =>
                {
                    b.Property<int>("BookingNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookingNumber"), 1L, 1);

                    b.Property<DateTime>("BookingDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.HasKey("BookingNumber");

                    b.HasIndex("CustomerId");

                    b.HasIndex("MovieId");

                    b.ToTable("Bookings");

                    b.HasData(
                        new
                        {
                            BookingNumber = 1001,
                            BookingDate = new DateTime(2023, 4, 17, 12, 11, 28, 161, DateTimeKind.Local).AddTicks(8067),
                            CustomerId = 101,
                            MovieId = 101
                        });
                });

            modelBuilder.Entity("EFApp.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 101,
                            Age = 22,
                            Name = "Eren",
                            Phone = "9876543210"
                        });
                });

            modelBuilder.Entity("EFApp.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Rating")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = 101,
                            Name = "Abc",
                            Rating = 4.5f
                        },
                        new
                        {
                            Id = 102,
                            Name = "XYZ",
                            Rating = 4.8f
                        });
                });

            modelBuilder.Entity("EFApp.Booking", b =>
                {
                    b.HasOne("EFApp.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFApp.Movie", "Movie")
                        .WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Movie");
                });
#pragma warning restore 612, 618
        }
    }
}
