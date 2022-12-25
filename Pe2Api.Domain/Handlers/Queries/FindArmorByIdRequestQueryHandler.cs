using MediatR;
using Pe2Api.Domain.Entities;
using Pe2Api.Domain.Notifications;
using Pe2Api.Domain.Queries.Request;
using Pe2Api.Domain.Repositories;

namespace Pe2Api.Domain.Handlers.Queries
{
    public class FindArmorByIdRequestQueryHandler : IRequestHandler<FindArmorByIdRequestQuery, Armor>
    {
        private readonly NotificationContext _notificationContext;
        private readonly IArmorReadRepository _armorReadRepository;

        public FindArmorByIdRequestQueryHandler(NotificationContext notificationContext, IArmorReadRepository armorReadRepository)
        {
            _notificationContext = notificationContext;
            _armorReadRepository = armorReadRepository;
        }

        public async Task<Armor> Handle(FindArmorByIdRequestQuery request, CancellationToken cancellationToken)
        {
            var armor = await _armorReadRepository.FindByIdAsync(request.Id);

            var armorNotFound = armor is null;
            if(armorNotFound)
            {
                _notificationContext.AddNotification("Error", "Armor not found");
                return default;
            }

            return armor;

        }
    }
}
