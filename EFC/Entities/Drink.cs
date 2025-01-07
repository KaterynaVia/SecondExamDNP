using System.ComponentModel.DataAnnotations;

namespace EFC.Entities;

public class Drink
{
    [Key]
    public int DrinkId { get; set; } // This will auto-increment
    [Required]
    public string Name { get; set; }= string.Empty;
    [Range(0.0, double.MaxValue)]
    public decimal Price { get; set; }
    [Range(0.0, 100.0)] //between 0.0 and less or =100.0
    public decimal AlcoholPercentage { get; set; }
    public bool IncludesUmbrella { get; set; }
    public Drink() { }

    public Drink(int drinkId, string name, decimal price, decimal alcoholPercentage, bool includesUmbrella)
    
    {
        DrinkId = drinkId;
        Name = name;
        Price = price;
        AlcoholPercentage = alcoholPercentage;
        IncludesUmbrella = includesUmbrella;
    }
    

}