using Domain.Entities;
using Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class UserFluentApi : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(t => t.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(t => t.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(t => t.FatherName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(t => t.Age)
                .IsRequired();

            builder.Property(t => t.PhoneNumber)
                .IsRequired()
                .HasMaxLength(15);

            builder.Property(t => t.PassportNumber)
                .IsRequired()
                .HasMaxLength(15);
        }
    }
}
