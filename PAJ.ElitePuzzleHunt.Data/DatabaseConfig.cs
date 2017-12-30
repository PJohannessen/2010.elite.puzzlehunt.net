using System.Configuration;

namespace PAJ.ElitePuzzleHunt.Data
{
    public static class DatabaseConfig
    {
        public static readonly string ConnectionString;
        private const string ConnectionStringName = "PuzzleHuntConnectionString";

        static DatabaseConfig()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings[ConnectionStringName].ConnectionString;
        }
    }
}
