namespace Persistance.Settings
{
    internal class CosmosDatabaseSettings : ICosmosDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
