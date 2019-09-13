using System;
using System.Collections.Generic;
using System.Text;
using CarRentCoreProject.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRentProject.DBContext
{
    public class CarRentDBContext:DbContext
    {
        public CarRentDBContext()
        {

        }
        public CarRentDBContext(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<RentRequest> RentRequests { get; set; }
        public DbSet<RentAssign> RentAssigns { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=CarRentProjectCoreDB;Integrated Security=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasKey(c => c.Id);
            modelBuilder.Entity<Customer>().Property(c => c.Name).IsRequired();
            modelBuilder.Entity<Customer>().Property(c => c.EmailAddress).IsRequired();
            modelBuilder.Entity<Customer>().Property(c => c.Contract).IsRequired();
            modelBuilder.Entity<Customer>().Property(c => c.Address).IsRequired();
            modelBuilder.Entity<RentRequest>().HasOne(c => c.Customer)
                                               .WithMany(s => s.RentRequests)
                                               .HasForeignKey(c => c.CustomerId)
                                               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<VehicleType>().HasKey(c => c.Id);
            modelBuilder.Entity<VehicleType>().Property(c => c.Name).IsRequired();

            modelBuilder.Entity<RentRequest>().HasOne(c => c.VehicleType)
                                          .WithMany(s => s.RentRequests)
                                          .HasForeignKey(c => c.VehiceTypeId)
                                          .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<RentRequest>().HasKey(c => c.Id);
            modelBuilder.Entity<RentRequest>().Property(c => c.Id).IsRequired();
            modelBuilder.Entity<RentRequest>().Property(c => c.AirCondition).IsRequired();
            modelBuilder.Entity<RentRequest>().Property(c => c.EndDateTime).IsRequired();
            modelBuilder.Entity<RentRequest>().Property(c => c.StartDateTime).IsRequired();
            modelBuilder.Entity<RentRequest>().Property(c => c.VehicleQty).IsRequired();
            modelBuilder.Entity<RentRequest>().Property(c => c.ToPlace).IsRequired();
            modelBuilder.Entity<RentRequest>().Property(c => c.FromPlace).IsRequired();

            modelBuilder.Entity<RentAssign>().HasKey(c => c.Id);
            modelBuilder.Entity<RentAssign>().Property(c => c.RentPrice).IsRequired();
            modelBuilder.Entity<RentAssign>().HasOne(c => c.RentRequest)
                                            .WithMany(c => c.RentAssigns)
                                            .HasForeignKey(c => c.RentRequestId)
                                            .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<RentAssign>().HasOne(c => c.VehicleType)
                                              .WithMany(c => c.RentAssigns)
                                              .HasForeignKey(r=>r.VehicleId)
                                              .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Notification>().HasKey(c => c.Id);
          
            modelBuilder.Entity<Notification>().HasOne(c => c.RentRequest)
                .WithMany(c => c.Notifications)
                .HasForeignKey(c => c.RentRequestId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Notification>().HasOne(c => c.Customer)
                .WithMany(c => c.Notifications)
                .HasForeignKey(c => c.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
