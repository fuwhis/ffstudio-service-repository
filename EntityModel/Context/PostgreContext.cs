using System;
using EntityModel.Configuration;
using EntityModel.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityModel.Context
{
    public partial class PostgreContext: DbContext
    {
        public PostgreContext() { }
        
        public PostgreContext(DbContextOptions<PostgreContext> options) : base(options)
        {
        }

        public virtual DbSet<Account>? Accounts { get; set; }
        public virtual DbSet<Bill> Bills { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Discount> Discounts { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if(!optionsBuilder.IsConfigured)
            //{
            //    optionsBuilder.UseNpgsql("");
            //}
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Account>(entity =>
            //{
            //    entity.ToTable("Account");
            //    entity.HasKey(e => e.UserId);
            //    entity.Property(e => e.UserId).IsRequired();
            //    entity.Property(e => e.Username).IsRequired();
            //    entity.Property(e => e.Password).IsRequired();
            //    entity.Property(e => e.Name);
            //    entity.Property(e => e.Info);
            //});

            modelBuilder.ApplyConfiguration(new AccountConfiguration());

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
