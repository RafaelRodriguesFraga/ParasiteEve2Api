using Pe2Api.Domain.Entities.Base;
using Pe2Api.Domain.Handlers.Commands;

namespace Pe2Api.Domain.Entities
{
    public class Weapon : BaseEntity
    {
        public Weapon()
        {

        }

        public string Name { get; private set; }
        public string AlternativeName { get; private set; }
        public string Type { get; private set; }
        public string ImageUrl { get; private set; }
        public string Caliber { get; private set; }
        public string Capacity { get; private set; }
        public int Weight { get; private set; }
        public string Range { get; private set; }
        public string Rate { get; private set; }
        public string CriticalRate { get; private set; }
        public string AmmoType { get; private set; }
        public string Description { get; private set; }
        public string AlternativeDescription { get; private set; }
        public string Location { get; private set; }

        public override void Validate()
        {
        }

        public static implicit operator Weapon(CreateWeaponRequestCommand ccommand)
        {
            return new Weapon()
            {
                Name = ccommand.Name,
                AlternativeName = ccommand.AlternativeName,
                Type = ccommand.Type,
                ImageUrl = ccommand.ImageUrl,
                Caliber = ccommand.Caliber,
                Capacity = ccommand.Capacity,
                Weight = ccommand.Weight,
                Range = ccommand.Range,
                Rate = ccommand.Rate,
                CriticalRate = ccommand.CriticalRate,
                AmmoType = ccommand.AmmoType,
                Description = ccommand.Description,
                AlternativeDescription = ccommand.AlternativeDescription,
                Location = ccommand.Location,

            };
        }
    }
}