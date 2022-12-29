using Pe2.Infra.DbSettings;
using Pe2.Infra.Repositories.Base;
using Pe2Api.Domain.Entities;
using Pe2Api.Domain.Repositories;

namespace Pe2.Infra.Repositories
{
    public class ArmorReadRepository : BaseReadRepository<Armor>, IArmorReadRepository
    {
        public ArmorReadRepository(IMongoSettings settings) : base(settings)
        {
        }
    }
}
