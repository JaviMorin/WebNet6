using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebNet6.Models
{
    public partial class TitanContext : DbContext
    {
        public TitanContext()
        {
        }

        public TitanContext(DbContextOptions<TitanContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Trade> Trades { get; set; } = null!;
        public virtual DbSet<TradeType> TradeTypes { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trade>(entity =>
            {
                entity.ToTable("Trade");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.TradeType)
                    .WithMany(p => p.Trades)
                    .HasForeignKey(d => d.TradeTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Trade_TradeType");
            });

            modelBuilder.Entity<TradeType>(entity =>
            {
                entity.ToTable("TradeType");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
