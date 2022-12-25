using MediatR;
using Pe2Api.Domain.Entities;
using Pe2Api.Domain.Notifications;
using Pe2Api.Domain.Queries.Request;
using Pe2Api.Domain.Queries.Response;
using Pe2Api.Domain.Repositories;

namespace Pe2Api.Domain.Handlers.Queries
{
    public class FindCharacterByIdRequestQueryHandler : IRequestHandler<FindCharacterByIdRequestQuery, Character>
    {
        private readonly NotificationContext _notificationContext;
        private readonly ICharacterReadRepository _characterReadRepository;

        public FindCharacterByIdRequestQueryHandler(NotificationContext notificationContext, ICharacterReadRepository characterReadRepository)
        {
            _notificationContext = notificationContext;
            _characterReadRepository = characterReadRepository;
        }

        public async Task<Character> Handle(FindCharacterByIdRequestQuery request, CancellationToken cancellationToken)
        {
            var character = await _characterReadRepository.FindByIdAsync(request.Id);

            var characterNotFound = character is null;
            if (characterNotFound)
            {
                _notificationContext.AddNotification("Error: ", "Character Not Found");
                return default;
            }

            return character;
        }
    }
}
