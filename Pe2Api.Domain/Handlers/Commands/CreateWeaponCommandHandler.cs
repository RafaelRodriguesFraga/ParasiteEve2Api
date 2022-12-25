using MediatR;
using Pe2Api.Domain.Entities;
using Pe2Api.Domain.Repositories;

namespace Pe2Api.Domain.Handlers.Commands
{
    public class CreateWeaponCommandHandler : IRequestHandler<CreateWeaponRequestCommand, Weapon>
    {
        private readonly IWeaponWriteRepository _weaponWriteRepository;
        public CreateWeaponCommandHandler(IWeaponWriteRepository weaponWriteRepository)
        {
            _weaponWriteRepository = weaponWriteRepository;
        }

        public async Task<Weapon> Handle(CreateWeaponRequestCommand request, CancellationToken cancellationToken)
        {
            var weapon = await _weaponWriteRepository.InsertOneAsync(request);

            return weapon;
        }
    }
}
