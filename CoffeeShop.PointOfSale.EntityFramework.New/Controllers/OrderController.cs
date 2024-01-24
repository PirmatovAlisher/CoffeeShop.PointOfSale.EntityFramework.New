using CoffeeShop.PointOfSale.EntityFramework.New.Models;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.PointOfSale.EntityFramework.New.Controllers;

internal class OrderController
{
	internal static void AddOrder(List<OrderProduct> orderProducts)
	{
		using var db = new ProductsContext();

		db.OrderProducts.AddRange(orderProducts);
		db.SaveChanges();
	}

	internal static List<Order> GetOrders()
	{
		using var db = new ProductsContext();

		var ordersList = db.Orders.Include(x => x.OrderProducts)
								  .ThenInclude(x => x.Product)
								  .ThenInclude(x => x.Category)
								  .ToList();

		return ordersList;
	}
}
