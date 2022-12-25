using Pe2.Infra.DbSettings;
using Pe2.Infra.Repositories.Base;
using Pe2Api.Domain.Entities;
using Pe2Api.Domain.Repositories;

namespace Pe2.Infra.Repositories
{
    public class ParasiteEnergyWriteRepository : BaseWriteRepository<ParasiteEnergy>, IParasiteEnergyWriteRepository
    {
        public ParasiteEnergyWriteRepository(IMongoSettings settings) : base(settings)
        {
        }
    }
}
