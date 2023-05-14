using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace DAL.Models
{
    public partial class Dogs_burber_shopContext : DbContext
    {
        public Dogs_burber_shopContext()
        {
        }

        public Dogs_burber_shopContext(DbContextOptions<Dogs_burber_shopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Queue> Queues { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=LAPTOP-D5NC5APO;Database=Dogs_burber_shop;trusted_connection=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Hebrew_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Queue>(entity =>
            {
                entity.Property(e => e.QueueId).HasColumnName("queueID");

                entity.Property(e => e.CustomerId).HasColumnName("customerID");

                entity.Property(e => e.QueueTime)
                    .HasColumnType("datetime")
                    .HasColumnName("queueTime");

                entity.Property(e => e.RegistrationTime)
                    .HasColumnType("datetime")
                    .HasColumnName("registrationTime");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Queues)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Queues_Customers");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
