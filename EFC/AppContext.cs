using Microsoft.EntityFrameworkCore;
using EFC.Entities;

namespace EFC;

public class AppContext: DbContext
{
    public DbSet<Drink> Drinks { get; set; }
    public DbSet<DrinksMenu> DrinksMenus { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source = App.db");
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Primary keys are inferred by [Key], no explicit HasKey needed
        // Additional model configurations (if any) go here
        /* This need only if not have a [key]
        modelBuilder.Entity<Drink>().HasKey(Drinks => Drinks.DrinkId  );
        modelBuilder.Entity<DrinksMenu>().HasKey( DrinksMenus => DrinksMenus.DrinksMenuId );*/
    }
}