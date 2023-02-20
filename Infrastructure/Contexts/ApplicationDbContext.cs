using Domain.Entities;
using Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {            
        }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Position> Positions { get; set; } 
        public DbSet<Staff> Staff { get; set; } 
        public DbSet<User> Users { get; set; } 
        public DbSet<UserAdmin> UserAdmins { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
