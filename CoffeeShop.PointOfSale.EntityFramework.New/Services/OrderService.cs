using CoffeeShop.PointOfSale.EntityFramework.New.Controllers;
using CoffeeShop.PointOfSale.EntityFramework.New.Models;
using Spectre.Console;

namespace CoffeeShop.PointOfSale.EntityFramework.New.Services;

internal class OrderService
{
	internal static void InsertOrder()
	{

		var orderProducts = GetProductsForOrder();

		OrderController.AddOrder(orderProducts);
	}

	private static List<OrderProduct> GetProductsForOrder()
	{
		var products = new List<OrderProduct>();

		var order = new Order()
		{
			CreatedDate = DateTime.Now
		};

		var isOrderFinished = false;

		while (!isOrderFinished)
		{
			var product = ProductService.GetProductOptionInput();

			var quantity = AnsiConsole.Ask<int>("How many?");

			order.TotalPrice = order.TotalPrice + (quantity * product.ProductPrice);

			products.Add(new OrderProduct()
			{
				Order = order,
				ProductId = product.ProductId,
				Quantity = quantity
			});

			isOrderFinished = !AnsiConsole.Confirm("Would you like to add more products?");
		}

		return products;

	}
}
