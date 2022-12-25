using Pe2Api.Domain.Commands.Response;
using Pe2Api.Domain.Entities.Base;
using Pe2Api.Domain.Queries.Response;

namespace Pe2Api.Domain.Entities
{
    public class Character : BaseEntity
    {
        public Character(string name, int age, string imageUrl, string hairColor, string eyeColor, string occupation)
        {
            Name = name;
            Age = age;
            ImageUrl = imageUrl;
            HairColor = hairColor;
            EyeColor = eyeColor;
            Occupation = occupation;
        }

        public string Name { get; private set; }
        public int Age { get; private set; }
        public string ImageUrl { get; private set; }
        public string HairColor { get; private set; }
        public string EyeColor { get; private set; }
        public string Occupation { get; private set; }

        public override void Validate()
        {
            
        }

        public static implicit operator CreateCharacterResponseCommand(Character character)
        {
            return new CreateCharacterResponseCommand()
            {
                Id = character.Id,
                Name = character.Name,
                Age = character.Age,
                ImageUrl = character.ImageUrl,
                HairColor = character.HairColor,
                EyeColor = character.EyeColor,
                Occupation = character.Occupation

            };

        }
        
        public static implicit operator FindCharacterByIdResponseQuery(Character character)
        {
            return new FindCharacterByIdResponseQuery()
            {
                Id = character.Id,
                Name = character.Name,
                Age = character.Age,
                ImageUrl = character.ImageUrl,
                HairColor = character.HairColor,
                EyeColor = character.EyeColor,
                Occupation = character.Occupation

            };

        }
    }

   
}
