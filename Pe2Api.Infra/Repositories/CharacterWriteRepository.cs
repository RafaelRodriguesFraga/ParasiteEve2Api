using Pe2Api.Domain.Entities;
using Pe2Api.Domain.Repositories;
using Pe2.Infra.DbSettings;
using Pe2.Infra.Repositories.Base;

namespace Pe2.Infra.Repositories
{
    public class CharacterWriteRepository : BaseWriteRepository<Character>, ICharacterWriteRepository
    {
        public CharacterWriteRepository(IMongoSettings settings) : base(settings)
        {
        }
    }
}
