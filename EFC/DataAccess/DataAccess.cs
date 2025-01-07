using EFC.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFC.DataAccess;

public class DataAccess
{
    private readonly AppContext _context;

    public DataAccess(AppContext context)
    {
        _context = context;
    }

    public async Task CreateDrinksMenuAsync(DrinksMenu menu)
    {
        if (menu == null) throw new ArgumentNullException(nameof(menu));
        await _context.DrinksMenus.AddAsync(menu);
        await _context.SaveChangesAsync();
    }

    public async Task AddDrinkToDrinksMenuAsync(int menuId, Drink drink)
    {
        if (drink == null) throw new ArgumentNullException(nameof(drink));
        var menu = await _context.DrinksMenus.Include(m=>m.Drinks)
            .FirstOrDefaultAsync(m=>m.DrinksMenuId == menuId);
        if (menu == null)
        {
            throw new ArgumentException($"Menu with id {menuId} not found");
        }
        menu.Drinks.Add(drink);
        await _context.SaveChangesAsync();
    }
    public async Task<List<Drink>> GetDrinks(
        decimal? minimumAlcoholPercentage = null,
        decimal? maximumAlcoholPercentage = null,
        bool? includesUmbrella = null)
    {
        var query = _context.Drinks.AsQueryable();

        // Apply filters dynamically
        if (minimumAlcoholPercentage.HasValue)
        {
            query = query.Where(d => d.AlcoholPercentage > minimumAlcoholPercentage.Value);
        }

        if (maximumAlcoholPercentage.HasValue)
        {
            query = query.Where(d => d.AlcoholPercentage < maximumAlcoholPercentage.Value);
        }

        if (includesUmbrella.HasValue)
        {
            query = query.Where(d => d.IncludesUmbrella == includesUmbrella.Value);
        }

        // Execute the query and return the results
        return await query.ToListAsync();
    }
    //3.8 total price
    public async Task<List<DrinksMenu>> GetDrinksMenusOrderedByTotalPriceAsync()
    {
        // Load menus and calculate total price
        return await _context.DrinksMenus
            .Include(m => m.Drinks) // Include drinks for price calculation
            .OrderByDescending(m => m.Drinks.Sum(d => d.Price)) // Order by total price
            .ToListAsync();
    }
}