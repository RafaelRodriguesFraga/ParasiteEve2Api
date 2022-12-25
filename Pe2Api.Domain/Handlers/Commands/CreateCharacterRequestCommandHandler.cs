using MediatR;
using Pe2Api.Domain.Commands.Request;
using Pe2Api.Domain.Commands.Response;
using Pe2Api.Domain.Repositories;
using Pe2Api.Domain.Notifications;
using Pe2Api.Domain.Entities;

namespace Pe2Api.Domain.Handlers.Commands
{
    public class CreateCharacterRequestCommandHandler : IRequestHandler<CreateCharacterRequestCommand, Character>
    {
        private readonly ICharacterWriteRepository _characterWriteRepository;
        private readonly NotificationContext _notificationContext;

        public CreateCharacterRequestCommandHandler(NotificationContext notificationContext, ICharacterWriteRepository characterWriteRepository)
        {
            _notificationContext = notificationContext;
            _characterWriteRepository = characterWriteRepository;
        }

        public async Task<Character> Handle(CreateCharacterRequestCommand request, CancellationToken cancellationToken)
        {
            request.Validate();
            if (request.Invalid)
            {
                _notificationContext.AddNotifications(request.Notifications);
                return default;
            }

            var response = await _characterWriteRepository.InsertOneAsync(request);

            return response;
        }
    }
}
