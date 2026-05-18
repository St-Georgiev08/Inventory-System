using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Inventory_System.Entities;
using Microsoft.Extensions.Configuration;

namespace Inventory_System
{
    public class SalesManagementSystemContext:DbContext
    {
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Suppliers> Suppliers { get; set; }
        public DbSet<ProductSuppliers> ProductSuppliers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appSettings.json");
            var config = builder.Build();
            var connectionString = config.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the many-to-many relationship between Products and Suppliers
            modelBuilder.Entity<ProductSuppliers>()
                .HasOne(ps => ps.Product)
                .WithMany(p => p.ProductSuppliers)
                .HasForeignKey(ps => ps.ProductId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<ProductSuppliers>()
                .HasOne(ps => ps.Supplier)
                .WithMany(s => s.ProductSuppliers)
                .HasForeignKey(ps => ps.SupplierId).OnDelete(DeleteBehavior.Cascade);
            // Configure the one-to-many relationship between Categories and Products
            modelBuilder.Entity<Products>()
                .HasOne(x=>x.Category)
                .WithMany(x=>x.Products)
                .HasForeignKey(x=>x.CategoryId).OnDelete(DeleteBehavior.Restrict);
            // Configure the one-to-many relationship between Orders and Customers
            modelBuilder.Entity<Orders>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerId).OnDelete(DeleteBehavior.Restrict);

            // Configure the many-to-many relationship between Products and Orders
             modelBuilder.Entity<OrderItems>()
                .HasOne(x=>x.Order)
                .WithMany(x=>x.OrderItems)
                .HasForeignKey(x=>x.OrderId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<OrderItems>()
                .HasOne(x=>x.Product)
                .WithMany(x=>x.OrderItems)
                .HasForeignKey(x=>x.ProductId).OnDelete(DeleteBehavior.Restrict);

            // Configure the one-to-many relationship between Users and Orders

            modelBuilder.Entity<Orders>()
                .HasOne(o=>o.User)
                .WithMany(x=>x.Orders)
                .HasForeignKey(o=>o.UserId).OnDelete(DeleteBehavior.Restrict);
            // Configure the one-to-many relationship between Users and AuditLogs
            modelBuilder.Entity<AuditLogs>()
                .HasOne(x=>x.User)
                .WithMany(x=>x.AuditLogs)
                .HasForeignKey(x=>x.UserId).OnDelete(DeleteBehavior.Cascade);

            //Configure the one-to-many relationship between Users and Products
            modelBuilder.Entity<Products>()
                .HasOne(x => x.CreatedByUser)
                .WithMany(x => x.CreatedProducts)
                .HasForeignKey(x => x.CreatedBy).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Products>()
                .HasOne(x => x.UpdatedByUser)
                .WithMany(x => x.UpdatedProducts)
                .HasForeignKey(x => x.UpdatedBy).OnDelete(DeleteBehavior.Restrict);



        }
    }
}
