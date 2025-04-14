using Application.Repositories;
using Application.Services;
using Application.Services.Interfaces;
using Domain.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddTransient<IGenericRepository<Category>, GenericRepository<Category>>();
            services.AddTransient<IGet<Category>, CategoryService>();

            #region Register IGet<T>
            Assembly.GetExecutingAssembly()
                 .GetTypes()
                 .Where(item => item.GetInterfaces()
                 .Where(i => i.IsGenericType).Any(i => i.GetGenericTypeDefinition() == typeof(IGet<>)) && !item.IsAbstract && !item.IsInterface)
                 .ToList()
                 .ForEach(assignedTypes =>
                 {
                     var serviceType = assignedTypes.GetInterfaces().First(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IGet<>));
                     services.AddScoped(serviceType, assignedTypes);
                 });
            #endregion

            return services;
        }
    }
}
