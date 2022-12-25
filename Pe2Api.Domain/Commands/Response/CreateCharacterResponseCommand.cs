using Pe2Api.Domain.Commands.Base;
namespace Pe2Api.Domain.Commands.Response
{
    public class CreateCharacterResponseCommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string ImageUrl { get; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        public string Occupation { get; set; }       
    }
}
