namespace CoffeeShop.PointOfSale.EntityFramework.New.Models;

internal class OrderProduct
{
	public int OrderProductId { get; set; }

	public Order Order { get; set; }

	public int ProductId { get; set; }

	public Product Product { get; set; }

	public int Quantity { get; set; }	
}
