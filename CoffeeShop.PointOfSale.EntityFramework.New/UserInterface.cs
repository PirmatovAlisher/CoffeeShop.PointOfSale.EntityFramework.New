using CoffeeShop.PointOfSale.EntityFramework.New.Models;
using Spectre.Console;
using static CoffeeShop.PointOfSale.EntityFramework.New.Enums;

namespace CoffeeShop.PointOfSale.EntityFramework.New;

internal class UserInterface
{
	static internal void MainMenu()
	{
		var appActive = true;

		while (appActive)
		{
			var option = AnsiConsole.Prompt(
								 new SelectionPrompt<MenuOptions>()
								 .Title("What would you like to do?")
								 .AddChoices(
									 MenuOptions.AddProduct,
									 MenuOptions.DeleteProduct,
									 MenuOptions.UpdateProduct,
									 MenuOptions.ViewProduct,
									 MenuOptions.ViewAllProducts,
									 MenuOptions.Quit
									 ));

			switch (option)
			{
				case MenuOptions.AddProduct:
					ProductService.InsertProduct();
					break;
				case MenuOptions.DeleteProduct:
					ProductService.DeleteProduct();
					break;
				case MenuOptions.UpdateProduct:
					ProductService.UpdateProduct();
					break;
				case MenuOptions.ViewProduct:
					ProductService.GetProduct();
					break;
				case MenuOptions.ViewAllProducts:
					ProductService.GetProducts();
					break;
				case MenuOptions.Quit:
					ProductController.Quit();
					break;

			}
		}
	}

	static internal void ShowProductTable(List<Product> products)
	{
		var table = new Table();
		table.AddColumn("Id");
		table.AddColumn("Name");
		table.AddColumn("Price");

		foreach (var product in products)
		{
			table.AddRow(product.ProductId.ToString(), product.ProductName, product.ProductPrice.ToString());
		}

		AnsiConsole.Write(table);
		Console.WriteLine("Enter any key to continue");
		Console.ReadLine();
		Console.Clear();

	}

	static internal void ShowProduct(Product product)
	{
		var panel = new Panel($@"Id: {product.ProductId}
Name: {product.ProductName}
Price: {product.ProductPrice}");

		panel.Header = new PanelHeader("Product Info");
		panel.Padding = new Padding(2, 2, 2, 2);

		AnsiConsole.Write(panel);
		Console.WriteLine("Enter any key to continue");
		Console.ReadLine();
		Console.Clear();
	}

}
