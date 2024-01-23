using System.ComponentModel.DataAnnotations;

namespace CoffeeShop.PointOfSale.EntityFramework.New.Models;

internal class Category
{
	public int CategoryId { get; set; }

	public string CategoryName { get; set; }

	public List<Product> Products { get; set; }
}
