using MediatR;
using Pe2Api.Domain.Entities;
using Pe2Api.Domain.Notifications;
using Pe2Api.Domain.Queries.Request;
using Pe2Api.Domain.Repositories;

namespace Pe2Api.Domain.Handlers.Queries
{
    public class FindParasiteEnergyByIdRequestQueryHandler : IRequestHandler<FindParasiteEnergyByIdRequestQuery, ParasiteEnergy>
    {
        private readonly NotificationContext _notificationContext;
        private readonly IParasiteEnergyReadRepository _parasiteEnergyReadRepository;

        public FindParasiteEnergyByIdRequestQueryHandler(NotificationContext notificationContext, IParasiteEnergyReadRepository parasiteEnergyReadRepository)
        {
            _notificationContext = notificationContext;
            _parasiteEnergyReadRepository = parasiteEnergyReadRepository;
        }

        public async Task<ParasiteEnergy> Handle(FindParasiteEnergyByIdRequestQuery request, CancellationToken cancellationToken)
        {
            var parasiteEnergy = await _parasiteEnergyReadRepository.FindByIdAsync(request.Id);

            var parasiteEnergyNotFound = parasiteEnergy is null;
            if(parasiteEnergyNotFound)
            {
                _notificationContext.AddNotification("Error: ", "Parasite Energy not found");
                return default;
            }

            return parasiteEnergy; 
        }
    }
}
