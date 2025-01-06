using Blazor.Entity;
namespace Blazor.Service;

public class KennelService : IKennelService
{
    private readonly List<Dog> _dogs;

    public KennelService()
    {
        _dogs = new List<Dog>
        {
            new Dog(1, "Nika", "female", "labrador", new DateOnly(2021,1,21), "a friendly dog",
                "https://plus.unsplash.com/premium_photo-1668114375111-e90b5e975df6?q=80&w=2069&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"),
            new Dog(2, "Nika", "male", "labrador", new DateOnly(2021, 1, 21), "a friendly dog",
                "https://plus.unsplash.com/premium_photo-1668114375111-e90b5e975df6?q=80&w=2069&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"),
            new Dog(3, "Nika", "female", "labrador", new DateOnly(2001, 1, 21), "a friendly dog",
                "https://plus.unsplash.com/premium_photo-1668114375111-e90b5e975df6?q=80&w=2069&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"),
            new Dog(4, "Nika", "female", "labrador", new DateOnly(2001, 1, 21), "a friendly dog",
                "https://plus.unsplash.com/premium_photo-1668114375111-e90b5e975df6?q=80&w=2069&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"),
            new Dog(5, "Nika", "male", "labrador", new DateOnly(2000, 1, 21), "a friendly dog",
                "https://img.freepik.com/free-photo/cute-golden-retriever-dog_1204-387.jpg?t=st=1736165588~exp=1736169188~hmac=fd4f30064b53c2b1799605f3df1c75317f44b023aa640010c18fb6e99d6862bb&w=740"),

        };

    }

    public List<Dog> GetAllDogs()
    {
        return _dogs;
    }

    public Dog GetDogById(int id)
    {
        return _dogs.FirstOrDefault(d => d.Id == id);
    }

    public void AddDog(Dog dog)
    {
        dog.Id = _dogs.Any() ? _dogs.Max(d => d.Id) + 1 : 1; // Increment ID or start at 1
        dog.ArrivalDate = DateOnly.FromDateTime(DateTime.Now); // Set the current date
        _dogs.Add(dog);
        Console.WriteLine($"Dog added: {dog.Name}, ID: {dog.Id}");
    }


}