using Pe2Api.Infra.DbSettings;
using Pe2Api.Infra.Repositories.Base;
using Pe2Api.Domain.Entities;
using Pe2Api.Domain.Repositories;

namespace Pe2Api.Infra.Repositories
{
    public class ParasiteEnergyWriteRepository : BaseWriteRepository<ParasiteEnergy>, IParasiteEnergyWriteRepository
    {
        public ParasiteEnergyWriteRepository(IMongoSettings settings) : base(settings)
        {
        }
    }
}
