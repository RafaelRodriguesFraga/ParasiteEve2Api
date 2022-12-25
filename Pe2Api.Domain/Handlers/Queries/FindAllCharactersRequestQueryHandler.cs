using MediatR;
using Pe2Api.Domain.Entities;
using Pe2Api.Domain.Queries.Request;
using Pe2Api.Domain.Repositories;

namespace Pe2Api.Domain.Handlers.Queries
{
    public class FindAllCharactersRequestQueryHandler : IRequestHandler<FindAllCharactersRequestQuery, IEnumerable<Character>>
    {
        private readonly ICharacterReadRepository _characterReadRepository;

        public FindAllCharactersRequestQueryHandler(ICharacterReadRepository characterReadRepository)
        {
            _characterReadRepository = characterReadRepository;
        }

        public async Task<IEnumerable<Character>> Handle(FindAllCharactersRequestQuery request, CancellationToken cancellationToken)
        {
            var characters = await _characterReadRepository.FindAllAsync();

            return characters;
        }
    }
}
