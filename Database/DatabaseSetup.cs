using Microsoft.Data.Sqlite;

namespace LabManager.Database;

class DatabaseSetup
{
    public DatabaseConfig DatabaseConfig { get; }


    public DatabaseSetup(DatabaseConfig databaseConfig)
    {
        DatabaseConfig = databaseConfig;
        CreateComputersTable();
    }

    private void CreateComputersTable()
    {
        using var connection = new SqliteConnection(DatabaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = @"
            CREATE TABLE IF NOT EXISTS Computers(
                id int not null primary key,
                ram varchar(100) not null,
                processor varchar(100) not null
            );
        ";

        command.ExecuteNonQuery();
    }
}