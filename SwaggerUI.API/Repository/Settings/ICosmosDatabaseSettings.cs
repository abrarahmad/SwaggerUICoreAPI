namespace Persistance.Settings
{
    public interface ICosmosDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
