using FluentValidation;
using Hr.Application.Models.UserModels;
using Hr.Application.Services;
using Hr.Application.Validators;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using static Hr.Application.Services.UserService;

namespace Hr.Application
{
    public static class ServiceCollection
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IStaffService, StaffService>();
            services.AddScoped<IPositionService, PositionService>();
            services.AddScoped<IEducationService, EducationService>();

            //services.AddScoped<IValidator<UserCreateModel>, UserCreateValidator>();

            return services;
        }
    }
}
