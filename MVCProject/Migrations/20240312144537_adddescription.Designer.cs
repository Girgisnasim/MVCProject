﻿// <auto-generated />
using System;
using MVCProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MVCProject.Migrations
{
    [DbContext(typeof(BookContext))]
    [Migration("20240312144537_adddescription")]
    partial class adddescription
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MVCProject.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("customers");
                });

            modelBuilder.Entity("MVCProject.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("employees");
                });

            modelBuilder.Entity("MVCProject.Models.Plan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pickup_Point")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TripId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("TripId")
                        .IsUnique()
                        .HasFilter("[TripId] IS NOT NULL");

                    b.ToTable("plan");
                });

            modelBuilder.Entity("MVCProject.Models.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("Quentity")
                        .HasColumnType("int");

                    b.Property<int?>("TripId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("TripId");

                    b.ToTable("tickets");
                });

            modelBuilder.Entity("MVCProject.Models.Trip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<TimeOnly>("Arrival_Time")
                        .HasColumnType("time");

                    b.Property<int>("Available_Seats")
                        .HasColumnType("int");

                    b.Property<DateOnly>("Departure_Date")
                        .HasColumnType("date");

                    b.Property<TimeOnly>("Departure_Time")
                        .HasColumnType("time");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Seats_Num")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Total_Seats")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("trips");
                });

            modelBuilder.Entity("MVCProject.Models.Plan", b =>
                {
                    b.HasOne("MVCProject.Models.Employee", "Employee")
                        .WithMany("Plans")
                        .HasForeignKey("EmployeeId");

                    b.HasOne("MVCProject.Models.Trip", "Trip")
                        .WithOne("Plan")
                        .HasForeignKey("MVCProject.Models.Plan", "TripId");

                    b.Navigation("Employee");

                    b.Navigation("Trip");
                });

            modelBuilder.Entity("MVCProject.Models.Ticket", b =>
                {
                    b.HasOne("MVCProject.Models.Customer", "Customer")
                        .WithMany("Ticket")
                        .HasForeignKey("CustomerId");

                    b.HasOne("MVCProject.Models.Trip", "Trip")
                        .WithMany("Ticket")
                        .HasForeignKey("TripId");

                    b.Navigation("Customer");

                    b.Navigation("Trip");
                });

            modelBuilder.Entity("MVCProject.Models.Trip", b =>
                {
                    b.HasOne("MVCProject.Models.Employee", "Employee")
                        .WithMany("Trips")
                        .HasForeignKey("EmployeeId");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("MVCProject.Models.Customer", b =>
                {
                    b.Navigation("Ticket");
                });

            modelBuilder.Entity("MVCProject.Models.Employee", b =>
                {
                    b.Navigation("Plans");

                    b.Navigation("Trips");
                });

            modelBuilder.Entity("MVCProject.Models.Trip", b =>
                {
                    b.Navigation("Plan");

                    b.Navigation("Ticket");
                });
#pragma warning restore 612, 618
        }
    }
}