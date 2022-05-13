using LabManager.Models;

namespace LabManager.Repositories;

interface IComputerRepository
{
    IEnumerable<Computer> GetAll();
    Computer Save(Computer computer);
    bool Exists(int id);
}