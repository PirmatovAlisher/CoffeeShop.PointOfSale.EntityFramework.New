namespace CoffeeShop.PointOfSale.EntityFramework.New.Models.DTOs;

internal class ProductForOrderViewDTO
{
	public int ProductId { get; set; }

	public string ProductName { get; set; }

	public string CategoryName { get; set; }

	public int Quantity { get; set; }

	public decimal Price { get; set; }

	public decimal TotalPrice { get; set; }
}
