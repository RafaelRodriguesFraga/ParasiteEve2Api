using MediatR;
using Pe2Api.Domain.Entities;

namespace Pe2Api.Domain.Handlers.Commands
{
    public class CreateWeaponRequestCommand : IRequest<Weapon>
    {
        public CreateWeaponRequestCommand()
        {

        }


        public string Name { get; set; }
        public string AlternativeName { get; set; }
        public string Type { get; set; }
        public string ImageUrl { get; set; }
        public string Caliber { get; set; }
        public string Capacity { get; set; }
        public int Weight { get; set; }
        public string Range { get; set; }
        public string Rate { get; set; }
        public string CriticalRate { get; set; }
        public string AmmoType { get; set; }
        public string Description { get; set; }
        public string AlternativeDescription { get; set; }
        public string Location { get; set; }
    }
}
