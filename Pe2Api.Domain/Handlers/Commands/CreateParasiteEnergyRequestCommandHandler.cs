using MediatR;
using Pe2Api.Domain.Commands.Request;
using Pe2Api.Domain.Entities;
using Pe2Api.Domain.Notifications;
using Pe2Api.Domain.Repositories;

namespace Pe2Api.Domain.Handlers.Commands
{
    public class CreateParasiteEnergyRequestCommandHandler : IRequestHandler<CreateParasiteEnergyRequestCommand, ParasiteEnergy>
    {
        private readonly NotificationContext _notificationContext;
        private readonly IParasiteEnergyWriteRepository _parasiteEnergyWriteRepository;

        public CreateParasiteEnergyRequestCommandHandler(NotificationContext notificationContext, IParasiteEnergyWriteRepository parasiteEnergyWriteRepository)
        {
            _notificationContext = notificationContext;
            _parasiteEnergyWriteRepository = parasiteEnergyWriteRepository;
        }

        public async Task<ParasiteEnergy> Handle(CreateParasiteEnergyRequestCommand request, CancellationToken cancellationToken)
        {
            request.Validate();
            
            var parasiteEnergyNotFound = request.Invalid;
            if(parasiteEnergyNotFound)
            {
                _notificationContext.AddNotifications(request.Notifications);
                return default;
            }

            var result = await _parasiteEnergyWriteRepository.InsertOneAsync(request);

            return result;

        }
    }
}
