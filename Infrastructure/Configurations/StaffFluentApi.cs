using Domain.Entities;
using Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class StaffFluentApi : IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            builder.Property(c => c.UserId)
                .IsRequired();

            builder.Property(c => c.PositionId)
                .IsRequired();

            builder.Property(c => c.EducationId)
                .IsRequired();

            builder.HasOne(c => c.User)
                .WithMany(c => c.Staffs)
                .HasForeignKey(x => x.UserId)
                .IsRequired();

            builder.HasOne(c => c.Education)
                .WithMany(c => c.Staffs)
                .HasForeignKey(x => x.EducationId)
                .IsRequired();

            builder.HasOne(c => c.Position)
                .WithMany(c => c.Staffs)
                .HasForeignKey(x => x.PositionId)
                .IsRequired();
        }
    }
}
