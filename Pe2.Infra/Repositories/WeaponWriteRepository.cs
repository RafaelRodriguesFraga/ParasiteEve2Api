using Pe2.Infra.DbSettings;
using Pe2.Infra.Repositories.Base;
using Pe2Api.Domain.Entities;
using Pe2Api.Domain.Repositories;

namespace Pe2Api.Infra.Repositories
{
    public class WeaponWriteRepository : BaseWriteRepository<Weapon>, IWeaponWriteRepository
    {
        public WeaponWriteRepository(IMongoSettings settings) : base(settings)
        {
        }
    }
}
