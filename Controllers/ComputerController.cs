using LabManager.Models;
using LabManager.Repositories;
using LabManager.Views;

namespace LabManager.Controllers;

class ComputerController
{
    private ComputerRepository repository;

    public ComputerController(ComputerRepository repository) => this.repository = repository;

    public string Index()
    {
        var computers = repository.GetAll();
        return new ComputerIndex().Render(computers);
    }

    public string Create(Computer computer)
    {
        if(repository.Exists(computer.Id))
        {
            return new AlreadyExistsError().Render("Computer", computer.Id);
        }
        
        var newComputer = repository.Save(computer);
        return new ComputerCreate().Render(newComputer);
    }
    
}