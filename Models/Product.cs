using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace Lab12.Models;
public class Product
{
    public int Id { get; set; }
    [Required, StringLength(200)] public string Name { get; set; } = "";
    [Range(typeof(decimal), "0.01", "999999999.99", ParseLimitsInInvariantCulture = true)] public decimal Price { get; set; }
    [Range(1, int.MaxValue)] public int CategoryId { get; set; }
    [JsonIgnore] public Category? Category { get; set; }
}
