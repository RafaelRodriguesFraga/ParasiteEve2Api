using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Pe2Api.Extensions
{
    public static class MediatorExtensions
    {
        public static IServiceCollection AddMediator(this IServiceCollection services)
        {
            var assembly = AppDomain.CurrentDomain.Load("Pe2Api.Domain");
            services.AddMediatR(assembly);

            return services;
        }
    }
}
