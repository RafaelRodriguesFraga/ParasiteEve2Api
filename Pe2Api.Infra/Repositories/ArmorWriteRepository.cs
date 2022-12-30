using Pe2Api.Infra.DbSettings;
using Pe2Api.Infra.Repositories.Base;
using Pe2Api.Domain.Entities;
using Pe2Api.Domain.Repositories;

namespace Pe2Api.Infra.Repositories
{
    public class ArmorWriteRepository : BaseWriteRepository<Armor>, IArmorWriteRepository
    {
        public ArmorWriteRepository(IMongoSettings settings) : base(settings)
        {
        }
    }
}
