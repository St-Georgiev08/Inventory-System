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
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Suppliers> Suppliers { get; set; }
        public DbSet<ProductSuppliers> ProductSuppliers { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<AuditLogs> AuditLogs { get; set; }
        public DbSet<ProductDetails> ProductDetails { get; set; }
        public SalesManagementSystemContext()
        {
        }
        public SalesManagementSystemContext(DbContextOptions<SalesManagementSystemContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder();
                builder.AddJsonFile("appSettings.json");
                var config = builder.Build();
                var connectionString = config.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
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
            //modelBuilder.Entity<Orders>()
            //    .HasOne(o => o.Customer)
            //    .WithMany(c => c.Orders)
            //    .HasForeignKey(o => o.CustomerId).OnDelete(DeleteBehavior.Restrict);

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

            //Configure the one-to-many relationship between Users and ProductDetails


            modelBuilder.Entity<ProductDetails>()
                .HasOne(x=>x.CreatedByUser).WithMany(x=>x.CreatedProducts).HasForeignKey(x=>x.CreatedBy).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<ProductDetails>()
                .HasOne(x => x.UpdatedByUser)
                .WithMany(x => x.UpdatedProducts)
                .HasForeignKey(x => x.UpdatedBy).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProductDetails>()
                .HasOne(x => x.Products)
                .WithOne(x => x.Status)
                .HasForeignKey<ProductDetails>(x => x.ProductId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>().HasIndex(u => u.Username)
                .IsUnique();
            modelBuilder.Entity<Suppliers>().HasIndex(s => s.Name)
                .IsUnique();
            modelBuilder.Entity<Categories>().HasIndex(c => c.Name)
                .IsUnique();
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "admin", PasswordHash = "240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9", PhoneNumber = "0895650627", Email = "stoichogeorgiev@gmail.com", Role = Enums.RoleType.Admin }
            ); // password for admin admin123
            modelBuilder.Entity<User>().Property(x => x.Role).HasConversion<string>();

        }
    }
}
