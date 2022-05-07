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
        public virtual DbSet<Account> Accounts { get; set; }
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
            //    entity.HasKey(e => e.UserId)
            //        .HasName("user_pkey");

            //    entity.ToTable("accounts");

            //    entity.Property(e => e.UserId)
            //        .HasColumnType("character varying")
            //        .HasColumnName("uid");

            //    entity.Property(e => e.Created_Date)
            //        .HasColumnType("timestamp without time zone")
            //        .HasColumnName("created_date");

            //    entity.Property(e => e.Info)
            //        .HasColumnType("json")
            //        .HasColumnName("info");

            //    entity.Property(e => e.Name)
            //        .HasColumnType("character varying")
            //        .HasColumnName("name");

            //    entity.Property(e => e.Passhash)
            //        .HasColumnType("character varying")
            //        .HasColumnName("passhash");

            //    entity.Property(e => e.Password)
            //        .IsRequired()
            //        .HasColumnType("character varying")
            //        .HasColumnName("pwd");

            //    entity.Property(e => e.Updated_Date)
            //        .HasColumnType("timestamp without time zone")
            //        .HasColumnName("updated_date");

            //    entity.Property(e => e.Username)
            //        .IsRequired()
            //        .HasColumnType("character varying")
            //        .HasColumnName("user_name");
            //});

            modelBuilder.ApplyConfiguration(new AccountConfiguration());

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
