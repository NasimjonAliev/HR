using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class PositionFluentApi : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(c => c.Name)
                .HasMaxLength(50)
                .IsRequired();

            //TODO округлить значение до двух чисел после запятой
            builder.Property(c => c.Amount)
                .HasPrecision(6,2)
                .IsRequired();  
        }
    }
}
