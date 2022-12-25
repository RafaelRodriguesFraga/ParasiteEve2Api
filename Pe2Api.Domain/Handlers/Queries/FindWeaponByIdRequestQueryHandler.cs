using MediatR;
using Pe2Api.Domain.Entities;
using Pe2Api.Domain.Notifications;
using Pe2Api.Domain.Queries.Request;
using Pe2Api.Domain.Repositories;

namespace Pe2Api.Domain.Handlers.Queries
{
    public class FindWeaponByIdRequestQueryHandler : IRequestHandler<FindWeaponByIdRequestQuery, Weapon>
    {
        private readonly IWeaponReadRepository _weaponReadRepository;
        private readonly NotificationContext _notificationContext;

        public FindWeaponByIdRequestQueryHandler(IWeaponReadRepository weaponReadRepository, NotificationContext notificationContext)
        {
            _weaponReadRepository = weaponReadRepository;
            _notificationContext = notificationContext;
        }

        public async Task<Weapon> Handle(FindWeaponByIdRequestQuery request, CancellationToken cancellationToken)
        {
            var weapon = await _weaponReadRepository.FindByIdAsync(request.Id);

            var weaponNotFound = weapon is null;
            if(weaponNotFound)
            {
                _notificationContext.AddNotification("Error", "Weapon not found");
                return default;
            }

            return weapon;

        }
    }
}
