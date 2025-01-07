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
}