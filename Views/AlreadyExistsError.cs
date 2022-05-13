namespace LabManager.Views;

class AlreadyExistsError
{
    public string Render(string modelName, int id)
    {
        return $"Error: {modelName} with id {id} already exists.";
    }
}