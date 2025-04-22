using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations
{
    public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            builder.Property(r => r.Id)
           .HasColumnName("Id")
           .HasColumnType("char(36)").UseCollation("utf8mb4_general_ci")
           .HasDefaultValueSql("UUID()");


            builder.Property(rt => rt.Token)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnType("varchar(255)")
                .UseCollation("utf8mb4_general_ci");

            builder.Property(rt => rt.UserId)
                .IsRequired()
                .HasColumnType("char(36)")
                .UseCollation("utf8mb4_general_ci");

            builder.Property(rt => rt.ExpiresAt)
                .IsRequired();

            builder.Property(rt => rt.IsRevoked)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(rt => rt.CreatedAt)
                .IsRequired();

            builder.Property(rt => rt.UpdatedAt)
                .IsRequired(false);

            builder.HasOne(rt => rt.User)
                .WithMany(u => u.RefreshTokens)
                .HasForeignKey(rt => rt.UserId)
                .OnDelete(DeleteBehavior.Cascade); 
        }
    }
}
