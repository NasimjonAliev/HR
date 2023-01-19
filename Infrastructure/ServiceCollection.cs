using Infrastructure.Contexts;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public static class ServiceCollection
    {
        public static IServiceCollection AddApplicationContextLayer(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(opt =>
                   opt.UseNpgsql("Host=localhost;Port=5432;Database=HrDb;Username=postgres;Password=root"));

            return services;
        }
    }
}
