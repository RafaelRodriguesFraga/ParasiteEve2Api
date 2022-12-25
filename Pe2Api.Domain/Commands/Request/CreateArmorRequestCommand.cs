using MediatR;
using Pe2Api.Domain.Commands.Base;
using Pe2Api.Domain.Entities;
using Pe2Api.Domain.Validations;

namespace Pe2Api.Domain.Commands.Request
{
    public class CreateArmorRequestCommand : BaseRequestCommand, IRequest<Armor>
    {
        public CreateArmorRequestCommand()
        {

        }

        public CreateArmorRequestCommand(string name, string hp, string mp, string imageUrl, int attachments, List<string> specialFeatures, double price, double endgamePrice, 
            string description, string? alternativeDescription, List<string> locations, bool scavengerNightmareMode)
        {
            Name = name;
            Hp = hp;
            Mp = mp;
            ImageUrl = imageUrl;
            Attachments = attachments;
            SpecialFeatures = specialFeatures;
            Price = price;
            EndgamePrice = endgamePrice;
            Description = description;
            AlternativeDescription = alternativeDescription;
            Locations = locations;
            ScavengerNightmareMode = scavengerNightmareMode;
        }

        public string Name { get; set; }
        public string Hp { get; set; }
        public string Mp { get; set; }
        public string ImageUrl { get; set; }
        public int Attachments { get; set; }
        public List<string> SpecialFeatures { get; set; }
        public double Price { get; set; }
        public double EndgamePrice { get; set; }
        public string Description { get; set; }
        public string? AlternativeDescription { get; set; }
        public List<string> Locations { get; set; }
        public bool ScavengerNightmareMode { get; set; }

        public override void Validate()
        {
            var contract = new CreateArmorRequestCommandContract();

            var result = contract.Validate(this);

            AddNotifications(result);
        }

    }
}
