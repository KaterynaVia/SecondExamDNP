using Blazor.Entity;

namespace Blazor.Service;

public interface IKennelService
{
    List<Dog> GetAllDogs();
    Dog GetDogById(int id);
    void AddDog(Dog dog);
    
}