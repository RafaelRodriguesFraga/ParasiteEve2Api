using Pe2.Infra.DbSettings;
using Pe2.Infra.Repositories.Base;
using Pe2Api.Domain.Entities;
using Pe2Api.Domain.Repositories;

namespace Pe2.Infra.Repositories
{
    public class CharacterReadRepository : BaseReadRepository<Character>, ICharacterReadRepository
    {
        public CharacterReadRepository(IMongoSettings settings) : base(settings)
        {
        }
    }
}
