﻿using FluentValidation;
using Hr.Application.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

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
            
            return services;
        }
    }
}
