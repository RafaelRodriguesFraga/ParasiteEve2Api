using MediatR;
using Pe2Api.Domain.Commands.Base;
using Pe2Api.Domain.Entities;
using Pe2Api.Domain.Validations;

namespace Pe2Api.Domain.Commands.Request
{
    public class CreateCharacterRequestCommand : BaseRequestCommand, IRequest<Character>
    {
        public CreateCharacterRequestCommand()
        {

        }
        public CreateCharacterRequestCommand(string name, int age, string imageUrl, string hairColor, string eyeColor, string occupation)
        {
            Name = name;
            Age = age;
            ImageUrl = imageUrl;
            HairColor = hairColor;
            EyeColor = eyeColor;
            Occupation = occupation;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string ImageUrl { get; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        public string Occupation { get; set; }

        public override void Validate()
        {
            var contract = new CreateCharacterRequestCommandContract();

            var result = contract.Validate(this);

            AddNotifications(result);
        }

        public static implicit operator Character(CreateCharacterRequestCommand character)
        {
            return new Character(character.Name, character.Age, character.ImageUrl, character.HairColor, character.EyeColor, character.Occupation);
            
        }
        
    }
}
