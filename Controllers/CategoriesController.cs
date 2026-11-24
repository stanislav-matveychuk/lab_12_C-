using Lab12.Data;
using Lab12.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Lab12.Controllers;
[ApiController, Route("api/[controller]")]
public class CategoriesController(ApplicationDbContext db) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Category>>> GetCategories() =>
        await db.Categories.AsNoTracking().Include(c => c.Products).ToListAsync();
}
