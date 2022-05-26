using Microsoft.Data.Sqlite;
using LabManager.Database;
using LabManager.Repositories;
using LabManager.Models;
using RazorLight;
using System.Reflection;

var databaseConfig = new DatabaseConfig();

var databaseSetup = new DatabaseSetup(databaseConfig);

var computerRepository = new ComputerRepository(databaseConfig);

var viewEngine = new RazorLightEngineBuilder()
    .UseFileSystemProject(Directory.GetCurrentDirectory())
    .UseMemoryCachingProvider()
    .Build();

// Routing
var modelName = args[0];
var modelAction = args[1];

if(modelName == "Computer")
{
    if(modelAction == "List")
    {
        var computers = computerRepository.GetAll();
        string result = await viewEngine.CompileRenderAsync("Views/Computer/List.cshtml", computers);
        Console.WriteLine(result);
    }

    if(modelAction == "New")
    {
        var id = Convert.ToInt32(args[2]);
        var ram = args[3];
        var processor = args[4];

        var computer = new Computer(id, ram, processor);
        computerRepository.Save(computer);
        string result = await viewEngine.CompileRenderAsync("Views/Computer/Show.cshtml", computer);
        Console.WriteLine(result);
    }
}