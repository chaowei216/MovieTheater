using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Infrastructure.Configurations
{

    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.Property(t => t.Id)
                .HasColumnName("Id")
                .HasColumnType("char(36)").UseCollation("utf8mb4_general_ci")
                .HasDefaultValueSql("UUID()");

            builder.Property(t => t.UserId)
                .IsRequired();

            builder.Property(t => t.TicketId)
                .IsRequired();

            builder.Property(t => t.TotalAmount)
                .IsRequired();

            builder.Property(t => t.TransactionDate)
                .IsRequired();

            builder.Property(t => t.Status)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(t => t.PaymentMethod)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(t => t.CreatedAt)
                .IsRequired();

            builder.Property(t => t.UpdatedAt)
                .IsRequired(false);

            builder.HasOne(t => t.User)
                .WithMany(u => u.Transactions)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.Ticket)
                .WithOne(ti => ti.Transaction)
                .HasForeignKey<Transaction>(t => t.TicketId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(t => t.TicketId)
          .HasColumnType("char(36)")
          .HasDefaultValueSql("UUID()")
          .UseCollation("utf8mb4_general_ci");
            builder.Property(t => t.UserId)
          .HasColumnType("char(36)")
          .HasDefaultValueSql("UUID()")
          .UseCollation("utf8mb4_general_ci");
        }
    }
}