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
            builder.Property(t => t.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(t => t.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(t => t.FatherName)
                .IsRequired(false)
                .HasMaxLength(50);

            builder.Property(t => t.Age)
                .IsRequired()
                .HasDefaultValue(18)
                .HasComment("Возраст должен быть больше 18");

            builder.Property(t => t.PhoneNumber)
                .IsRequired()
                .HasMaxLength(15);

            builder.Property(t => t.PassportNumber)
                .IsRequired()
                .HasMaxLength(15);

            builder.HasMany(t => t.Staffs)
                .WithOne(t => t.User)
                .HasForeignKey(t => t.UserId)
                .IsRequired();

            builder.HasIndex(t => new {t.PassportNumber, t.PhoneNumber})
                .IsUnique();
        }
    }
}
