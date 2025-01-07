using System.ComponentModel.DataAnnotations;

namespace EFC.Entities;

public class DrinksMenu
{
    [Key]
    public int DrinksMenuId { get; set; }
    [Required]
    public string Name { get; set; }= string.Empty;
    public bool ContainsAlcohol { get; set; }
    
    [DataType(DataType.Time)]
    public DateTime AvailableFrom { get; set; }
    public ICollection<Drink> Drinks { get; set; }= new List<Drink>();
    public DrinksMenu() { }

    public DrinksMenu(int drinksMenuId, string name, bool containsAlcohol, DateTime availableFrom)
    {
        DrinksMenuId = drinksMenuId;
        Name = name;
        ContainsAlcohol = containsAlcohol;
        AvailableFrom= availableFrom;
        Drinks = new List<Drink>();
    }
}