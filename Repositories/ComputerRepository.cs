using LabManager.Database;
using LabManager.Models;
using Microsoft.Data.Sqlite;

namespace LabManager.Repositories;

class ComputerRepository : IComputerRepository
{
    private DatabaseConfig databaseConfig;

    public ComputerRepository(DatabaseConfig databaseConfig)
    {
        this.databaseConfig = databaseConfig;
    }

    public bool Exists(int id)
    {
        using var connection = GetConnection();
        connection.Open();

        var command = new SqliteCommand("SELECT count(*) FROM Computers WHERE id = $id", connection);
        command.Parameters.AddWithValue("$id", id);
        int numberOfComputers = Convert.ToInt32(command.ExecuteScalar());
        
        return numberOfComputers > 0;
    }

    public IEnumerable<Computer> GetAll()
    {
        using var connection = GetConnection();
        connection.Open();

        var command = new SqliteCommand("SELECT * FROM Computers", connection);
        var reader = command.ExecuteReader();
        
        List<Computer> computers = new List<Computer>();
        while(reader.Read())
        {
            computers.Add(new Computer(reader.GetInt32(0), reader.GetString(1), reader.GetString(2)));
        }
        
        return computers;
    }

    public Computer Save(Computer computer)
    {
        using var connection = GetConnection();
        connection.Open();

        var command = new SqliteCommand("INSERT INTO Computers VALUES ($id, $ram, $processor)", connection);
        command.Parameters.AddWithValue("$id", computer.Id);
        command.Parameters.AddWithValue("$ram", computer.Ram);
        command.Parameters.AddWithValue("$processor", computer.Processor);
        command.ExecuteNonQuery();
        
        return computer;
    }

    private SqliteConnection GetConnection() => new SqliteConnection(databaseConfig.ConnectionString);
}