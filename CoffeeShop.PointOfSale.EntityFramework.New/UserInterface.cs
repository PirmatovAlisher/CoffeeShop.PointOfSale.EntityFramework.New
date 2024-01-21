using Spectre.Console;

namespace CoffeeShop.PointOfSale.EntityFramework.New;

internal class UserInterface
{
	static internal void ShowProductTable(List<Product> products)
	{
		var table = new Table();
		table.AddColumn("Id");
		table.AddColumn("Name");

		foreach (var product in products)
		{
			table.AddRow(product.ProductId.ToString(), product.ProductName);
		}

		AnsiConsole.Write(table);
		Console.WriteLine("Enter any key to continue");
		Console.ReadLine();
		Console.Clear();

	}

	static internal void ShowProduct(Product product)
	{
		var panel = new Panel($@"Id: {product.ProductId}
Name: {product.ProductName}");

		panel.Header = new PanelHeader("Product Info");
		panel.Padding = new Padding(2, 2, 2, 2);

		AnsiConsole.Write(panel);
		Console.WriteLine("Enter any key to continue");
		Console.ReadLine();
		Console.Clear();
	}

}
