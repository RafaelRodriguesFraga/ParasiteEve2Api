namespace Pe2.Infra.DbSettings
{
    public interface IMongoSettings
    {
        public string DatabaseName { get; set; }
       public string ConnectionString { get; set; }
    }
}