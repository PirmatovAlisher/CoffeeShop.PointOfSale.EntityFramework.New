using System.ComponentModel.DataAnnotations;

namespace CoffeeShop.PointOfSale.EntityFramework.New.Models;

internal class Category
{
	[Key]
	public int CategoryId { get; set; }

	[Required]
	public string CategoryName { get; set; }

	public List<Product> Products { get; set; }
}
