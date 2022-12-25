using MediatR;
using Pe2Api.Domain.Commands.Request;
using Pe2Api.Domain.Entities;
using Pe2Api.Domain.Notifications;
using Pe2Api.Domain.Repositories;

namespace Pe2Api.Domain.Handlers.Commands
{
    public class CreateArmorRequestCommandHandler : IRequestHandler<CreateArmorRequestCommand, Armor>
    {
        private readonly NotificationContext _notificationContext;
        private readonly IArmorWriteRepository _armorWriteRepository;

        public CreateArmorRequestCommandHandler(NotificationContext notificationContext, IArmorWriteRepository armorWriteRepository)
        {
            _notificationContext = notificationContext;
            _armorWriteRepository = armorWriteRepository;
        }

        public async Task<Armor> Handle(CreateArmorRequestCommand request, CancellationToken cancellationToken)
        {
            request.Validate();
            var invalidRequest = request.Invalid;
            if(invalidRequest)
            {
                _notificationContext.AddNotifications(request.Notifications);
                return default;
            }

            var armor = await _armorWriteRepository.InsertOneAsync(request);

            return armor;
        }
    }
}
