using Microsoft.Extensions.DependencyInjection;
using Pe2Api.Infra.Repositories;
using Pe2Api.Domain.Repositories;
using Pe2Api.Domain.Repositories.Base;
using Pe2Api.Infra.Repositories.Base;

namespace Pe2Api.Extensions
{
    public static class RepositoryExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseWriteRepository<>), typeof(BaseWriteRepository<>));
            services.AddScoped(typeof(IBaseReadRepository<>), typeof(BaseReadRepository<>));

            services.AddScoped<ICharacterWriteRepository, CharacterWriteRepository>();
            services.AddScoped<ICharacterReadRepository, CharacterReadRepository>();

            services.AddScoped<IArmorWriteRepository, ArmorWriteRepository>();
            services.AddScoped<IArmorReadRepository, ArmorReadRepository>();
            
            services.AddScoped<IParasiteEnergyWriteRepository, ParasiteEnergyWriteRepository>();
            services.AddScoped<IParasiteEnergyReadRepository, ParasiteEnergyReadRepository>();

            services.AddScoped<IWeaponWriteRepository, WeaponWriteRepository>();
            services.AddScoped<IWeaponReadRepository, WeaponReadRepository>();

            return services;
        }
    }
}
