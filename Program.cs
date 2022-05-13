using LabManager.Controllers;
using LabManager.Database;
using LabManager.Models;
using LabManager.Repositories;

var databaseConfig = new DatabaseConfig();
new DatabaseSetup(databaseConfig);

var computerRepository = new ComputerRepository(databaseConfig);
var computerController = new ComputerController(computerRepository);

// Routing
var modelName = args[0];
var modelAction = args[1];

if(modelName == "Computer")
{
    if(modelAction == "List")
    {
        var response = computerController.Index();
        Console.WriteLine(response);
    }

    if(modelAction == "New")
    {
        var id = Convert.ToInt32(args[2]);
        var ram = args[3];
        var processor = args[4];
        var response = computerController.Create(new Computer(id, ram, processor));
        Console.WriteLine(response);
    }
}