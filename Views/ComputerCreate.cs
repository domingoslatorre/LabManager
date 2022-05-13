using LabManager.Models;

namespace LabManager.Views;

class ComputerCreate
{
    public string Render(Computer computer)
    {
        return $"Computer with id {computer.Id} created!";
    }
}