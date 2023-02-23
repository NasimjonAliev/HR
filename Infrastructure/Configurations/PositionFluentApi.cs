using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class PositionFluentApi : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.Property(c => c.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(c => c.Amount)
                .HasColumnType("decimal(15,2)")
                .IsRequired();

            builder.HasMany(c => c.Staffs)
                .WithOne(c => c.Position)
                .HasForeignKey(c => c.PositionId)
                .IsRequired();
        }
    }
}
