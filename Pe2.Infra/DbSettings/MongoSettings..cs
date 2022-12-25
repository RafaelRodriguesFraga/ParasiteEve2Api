namespace Pe2.Infra.DbSettings
{
    public class MongoSettings : IMongoSettings
    {
        public string DatabaseName { get; set; }
        public string ConnectionString { get; set; }
    }
}