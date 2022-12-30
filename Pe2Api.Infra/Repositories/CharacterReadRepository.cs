using Pe2Api.Infra.DbSettings;
using Pe2Api.Infra.Repositories.Base;
using Pe2Api.Domain.Entities;
using Pe2Api.Domain.Repositories;

namespace Pe2Api.Infra.Repositories
{
    public class CharacterReadRepository : BaseReadRepository<Character>, ICharacterReadRepository
    {
        public CharacterReadRepository(IMongoSettings settings) : base(settings)
        {
        }
    }
}
