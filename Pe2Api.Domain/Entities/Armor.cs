using Pe2Api.Domain.Commands.Request;
using Pe2Api.Domain.Entities.Base;

namespace Pe2Api.Domain.Entities
{
    public class Armor : BaseEntity
    {
        public Armor()
        {

        }


        public string Name { get; private set; }
        public string Hp { get; private set; }
        public string Mp { get; private set; }
        public string ImageUrl { get; private set; }
        public int Attachments { get; private set; }
        public List<string> SpecialFeatures { get; private set; }
        public double Price { get; private set; }
        public double EndgamePrice { get; private set; }
        public string Description { get; private set; }
        public string AlternativeDescription { get; private set; }
        public List<string> Locations { get; private set; }
        public bool ScavengerNightmareMode { get; private set; }

        public override void Validate()
        {

        }

        public static implicit operator Armor(CreateArmorRequestCommand command)
        {
            return new Armor()
            {
                Name = command.Name,
                Hp = command.Hp,
                Mp = command.Mp,
                ImageUrl = command.ImageUrl,
                Attachments = command.Attachments,
                SpecialFeatures = command.SpecialFeatures,
                Price = command.Price,
                EndgamePrice = command.EndgamePrice,
                Description = command.Description,
                AlternativeDescription = command.AlternativeDescription,
                Locations = command.Locations,
                ScavengerNightmareMode = command.ScavengerNightmareMode
            };
        }

    }
}


