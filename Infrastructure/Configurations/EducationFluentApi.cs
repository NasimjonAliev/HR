using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class EducationFluentApi : IEntityTypeConfiguration<Education>
    {
        public void Configure(EntityTypeBuilder<Education> builder)
        {
            builder.Property(c => c.EducationLevel)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(x => x.UniversityName)
                    .IsRequired()
                    .HasMaxLength(70);
            
            builder.Property(x => x.StartedAt)
                .IsRequired();

            builder.Property(x => x.FinishedAt)
                .IsRequired();
            
            builder.HasMany(x => x.Staffs)
                .WithOne(f => f.Education)
                .HasForeignKey(f => f.EducationId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
