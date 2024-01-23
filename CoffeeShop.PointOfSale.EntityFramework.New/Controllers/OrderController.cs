using CoffeeShop.PointOfSale.EntityFramework.New.Models;

namespace CoffeeShop.PointOfSale.EntityFramework.New.Controllers;

internal class OrderController
{
	internal static void AddOrder(List<OrderProduct> orderProducts)
	{
		using var db = new ProductsContext();

		db.OrderProducts.AddRange(orderProducts);
		db.SaveChanges();
	}
}
