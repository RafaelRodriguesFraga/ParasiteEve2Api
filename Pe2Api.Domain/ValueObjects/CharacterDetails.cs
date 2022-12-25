namespace Pe2Api.Domain.ValueObjects
{
    public class CharacterDetails
    {
        public CharacterDetails(string name, int age, string hairColor, string eyeColor, string occupation)
        {
            Name = name;
            Age = age;
            HairColor = hairColor;
            EyeColor = eyeColor;
            Occupation = occupation;
        }

        public string Name { get; private set; }
        public int Age { get; private set; }
        public string HairColor { get; private set; }
        public string EyeColor { get; private set; }
        public string Occupation { get; private set; }
    }
}
