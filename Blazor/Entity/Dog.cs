namespace Blazor.Entity;

public class Dog
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Sex { get; set; }
    public string Breed { get; set; }
    public string ImageUrl { get; set; }
    public string Description { get; set; }
    public DateOnly ArrivalDate { get; set; }

    public Dog(int id, string name,string sex,string breed, DateOnly arrivalDate, string description, string imageUrl)
    {
        Id = id;
        Name = name;
        Sex = sex;
        Breed = breed;
        ImageUrl = imageUrl;
        Description = description;
        ArrivalDate = arrivalDate;
        
    }
}