namespace Pe2Api.Domain.Queries.Response
{
    public class FindAllCharactersResponseQuery
    {
        public FindAllCharactersResponseQuery()
        {

        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string ImageUrl { get; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        public string Occupation { get; set; }
    }
}
