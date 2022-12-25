using MediatR;
using Pe2Api.Domain.Entities;
using Pe2Api.Domain.Queries.Request;
using Pe2Api.Domain.Repositories;

namespace Pe2Api.Domain.Handlers.Queries
{
    public class FindAllArmorsRequestQueryHandler : IRequestHandler<FindAllArmorsRequestQuery, IEnumerable<Armor>>
    {
        private readonly IArmorReadRepository _armorReadRepository;

        public FindAllArmorsRequestQueryHandler(IArmorReadRepository armorReadRepository)
        {
            _armorReadRepository = armorReadRepository;
        }

        public async Task<IEnumerable<Armor>> Handle(FindAllArmorsRequestQuery request, CancellationToken cancellationToken)
        {
            var armors = await _armorReadRepository.FindAllAsync();

            return armors;
        }
    }
}
