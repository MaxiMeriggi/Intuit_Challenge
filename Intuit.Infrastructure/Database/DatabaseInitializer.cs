using MySqlConnector;

namespace Intuit.Infrastructure.Database
{
    public class DatabaseInitializer
    {
        private readonly string _connectionString;
        private readonly string _sqlFolder;

        public DatabaseInitializer(string connectionString, string sqlFolder)
        {
            _connectionString = connectionString;
            _sqlFolder = sqlFolder;
        }

        public void InitializeDatabase()
        {
            var builder = new MySqlConnectionStringBuilder(_connectionString);
            string databaseName = builder.Database;

            CreateDatabaseIfMissing(builder, databaseName);

            RunScripts();
        }

        private void CreateDatabaseIfMissing(MySqlConnectionStringBuilder builder, string dbName)
        {
            builder.Database = "";

            using var connection = new MySqlConnection(builder.ConnectionString);
            connection.Open();

            string sql = $"CREATE DATABASE IF NOT EXISTS `{dbName}`;";
            using var command = new MySqlCommand(sql, connection);
            command.ExecuteNonQuery();
        }

        private void RunScripts()
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            var files = Directory.GetFiles(_sqlFolder, "*.sql");
            Array.Sort(files);

            foreach (var file in files)
            {
                string sql = File.ReadAllText(file);

                using var cmd = new MySqlCommand(sql, connection);
                cmd.ExecuteNonQuery();
            }
        }

    }
}
