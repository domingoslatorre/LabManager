using System.Text;
using LabManager.Models;
using LabManager.Repositories;

namespace LabManager.Controllers;

class ComputerController
{
    private ComputerRepository repository;

    public ComputerController(ComputerRepository repository) => this.repository = repository;

    public string Index()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Computer List");
        foreach (var computer in repository.GetAll())
        {
            sb.AppendLine($"{computer.Id}, {computer.Ram}, {computer.Processor}");
        }

        return sb.ToString();
    }

    public string Create(Computer computer)
    {
        repository.Save(computer);
        return "Computer New";
    }
    
}