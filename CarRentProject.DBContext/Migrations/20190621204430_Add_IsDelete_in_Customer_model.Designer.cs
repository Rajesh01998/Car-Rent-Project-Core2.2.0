﻿// <auto-generated />
using System;
using CarRentProject.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CarRentProject.DBContext.Migrations
{
    [DbContext(typeof(CarRentDBContext))]
    [Migration("20190621204430_Add_IsDelete_in_Customer_model")]
    partial class Add_IsDelete_in_Customer_model
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CarRentCoreProject.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<string>("Contract")
                        .IsRequired();

                    b.Property<string>("EmailAddress")
                        .IsRequired();

                    b.Property<bool>("IsDelete");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("CarRentCoreProject.Models.RentRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AirCondition")
                        .IsRequired();

                    b.Property<int>("CustomerId");

                    b.Property<string>("Description");

                    b.Property<DateTime>("EndDateTime");

                    b.Property<string>("FromPlace")
                        .IsRequired();

                    b.Property<DateTime>("StartDateTime");

                    b.Property<string>("ToPlace")
                        .IsRequired();

                    b.Property<int>("VehiceTypeId");

                    b.Property<int>("VehicleQty");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("VehiceTypeId");

                    b.ToTable("RentRequests");
                });

            modelBuilder.Entity("CarRentCoreProject.Models.VehicleType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("VehicleTypes");
                });

            modelBuilder.Entity("CarRentCoreProject.Models.RentRequest", b =>
                {
                    b.HasOne("CarRentCoreProject.Models.Customer", "Customer")
                        .WithMany("RentRequests")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CarRentCoreProject.Models.VehicleType", "VehicleType")
                        .WithMany("RentRequests")
                        .HasForeignKey("VehiceTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
