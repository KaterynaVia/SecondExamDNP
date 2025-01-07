// See https://aka.ms/new-console-template for more information

//Console.WriteLine("Hello, World!");
using EFC;
using EFC.DataAccess;
using EFC.Entities;

public class Program
{
    public static async Task Main(string[] args)
    {
        var context = new EFC.AppContext();
        var dataAccess = new DataAccess(context);

        // Create and add sample menus asynchronously
        await CreateSampleMenusAsync(dataAccess);


        Console.WriteLine("Three menus have been created and added to the database!");
    }

    private static async Task CreateSampleMenusAsync(DataAccess dataAccess)
    {
        var menu1 = new DrinksMenu
        {
            Name = "Drink 1",
            AvailableFrom = DateTime.Now,
            ContainsAlcohol = true,
            Drinks = new List<Drink>
            {
                new Drink
                {
                    Name = "Vine", AlcoholPercentage = 10.0m, Price = 10.0m,  IncludesUmbrella = true
                },
                new Drink
                {
                    Name = "Mojito", AlcoholPercentage = 10.0m, Price = 10.0m,  IncludesUmbrella = true
                }
            }
        };
        var menu2 = new DrinksMenu
        {
            Name = "Mocktails",
            ContainsAlcohol = false,
            AvailableFrom = DateTime.Now,
            Drinks = new List<Drink>
            {
                new Drink
                {
                    Name = "Virgin Mojito",
                    AlcoholPercentage = 0.1m, Price = 5.0m,  IncludesUmbrella = false
                },
                new Drink
                {
                    Name = "Mojito",
                    AlcoholPercentage = 5.0m, Price = 5.0m,  IncludesUmbrella = false
                }
            }
        };
        await dataAccess.CreateDrinksMenuAsync(menu1);
        await dataAccess.CreateDrinksMenuAsync(menu2);
    }

    private static async Task AddDrinksToMenusAsync(DataAccess dataAccess)
    {
        // Example: Adding drinks to menu 1
        await dataAccess.AddDrinkToDrinksMenuAsync(1, new Drink
        {
            Name = "Pina Colada",
            AlcoholPercentage = 8.5m,
            Price = 12.99m,
            
            IncludesUmbrella = true

        });

        await dataAccess.AddDrinkToDrinksMenuAsync(1, new Drink
        {
            Name = "Colada",
            AlcoholPercentage = 0.5m,
            Price = 12.99m,
            
            IncludesUmbrella = true
        });

        // Example: Adding drinks to menu 2
        await dataAccess.AddDrinkToDrinksMenuAsync(2, new Drink
        {
            Name = "Pina ",
            AlcoholPercentage = 8.5m,
            Price = 12.99m,
            
            IncludesUmbrella = true
        });

        await dataAccess.AddDrinkToDrinksMenuAsync(2, new Drink
        {
            Name = "Pina Colada",
            AlcoholPercentage = 8.5m,
            Price = 12.99m,
            
            IncludesUmbrella = true


        });

        //Filter Task3.7
        var drinksWithUmbrella = await dataAccess.GetDrinks(minimumAlcoholPercentage: 5.0m,
            includesUmbrella: true);
        Console.WriteLine("Drinks with Alcohol > 5% and include an umbrella:");
        foreach (var drink in drinksWithUmbrella)
        {
            Console.WriteLine($"- {drink.Name} ({drink.AlcoholPercentage}%)");
        }


        // Fetch and display menus ordered by total price
        var orderedMenus = await dataAccess.GetDrinksMenusOrderedByTotalPriceAsync();
        Console.WriteLine("DrinksMenus ordered by total price:");
        foreach (var menu in orderedMenus)
        {
            var totalPrice = menu.Drinks.Sum(d => d.Price);
            Console.WriteLine($"- {menu.Name} (Total Price: {totalPrice:C})");
        }
    }
}
