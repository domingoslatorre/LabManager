using LabManager.Models;
using System.Text;

namespace LabManager.Views;

class ComputerIndex
{
    public string Render(IEnumerable<Computer> computers)
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Computer List");
        foreach (var computer in computers)
        {
            sb.AppendLine($"{computer.Id}, {computer.Ram}, {computer.Processor}");
        }

        return sb.ToString();
    }
}