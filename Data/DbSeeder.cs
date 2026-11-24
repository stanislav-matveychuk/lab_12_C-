using Lab12.Models;
using Microsoft.EntityFrameworkCore;
namespace Lab12.Data;
public static class DbSeeder
{
    public static async Task SeedDataAsync(ApplicationDbContext db)
    {
        if (await db.Products.AnyAsync()) return;
        db.Products.AddRange(
            new Product { Name = "Laptop", Price = 1000, CategoryId = 1 },
            new Product { Name = "Smartphone", Price = 500, CategoryId = 1 },
            new Product { Name = "ASP.NET Core Book", Price = 30, CategoryId = 2 });
        await db.SaveChangesAsync();
    }
}
