using Pe2Api.Domain.Entities;
using Pe2Api.Domain.Repositories;
using Pe2Api.Infra.DbSettings;
using Pe2Api.Infra.Repositories.Base;

namespace Pe2Api.Infra.Repositories
{
    public class CharacterWriteRepository : BaseWriteRepository<Character>, ICharacterWriteRepository
    {
        public CharacterWriteRepository(IMongoSettings settings) : base(settings)
        {
        }
    }
}
