using CoffeeShop.PointOfSale.EntityFramework.New.Controllers;
using CoffeeShop.PointOfSale.EntityFramework.New.Models;
using CoffeeShop.PointOfSale.EntityFramework.New.Models.DTOs;
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

	private static Order GetOrderOptionInput()
	{
		var orders = OrderController.GetOrders();

		var orderArray = orders.Select(x => $"{x.OrderId}.{x.CreatedDate} - {x.TotalPrice}").ToArray();

		var option = AnsiConsole.Prompt(new SelectionPrompt<string>().Title("Choose Order").AddChoices(orderArray));	

		var idArray = option.Split('.');

		var order = orders.Single(x => x.OrderId == Int32.Parse(idArray[0]));

		return order;	

	}

	internal static void GetOrder()
	{
		var order = GetOrderOptionInput();

		var products = order.OrderProducts
							.Select(x => new ProductForOrderViewDTO {
								ProductId = x.ProductId,
								ProductName = x.Product.ProductName,
								CategoryName = x.Product.Category.CategoryName,
								Quantity = x.Quantity,
								Price = x.Product.ProductPrice,
								TotalPrice = x.Product.ProductPrice * x.Quantity,

							})
							.ToList();

		UserInterface.ShowOrder(order);
		UserInterface.ShowProductForOrderTable(products);
	}


	internal static void GetOrders()
	{
		var orders = OrderController.GetOrders();

		UserInterface.ShowOrderTable(orders);
	}
}
