using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class EducationFluentApi : IEntityTypeConfiguration<Education>
    {
        public void Configure(EntityTypeBuilder<Education> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.EducationLevel)
                .IsRequired();

            builder.Property(x => x.UniversityName)
                    .IsRequired()
                    .HasMaxLength(70);                
        }
    }
}
