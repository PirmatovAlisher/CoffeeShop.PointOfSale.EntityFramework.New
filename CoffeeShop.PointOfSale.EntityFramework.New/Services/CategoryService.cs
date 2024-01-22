using CoffeeShop.PointOfSale.EntityFramework.New.Controllers;
using CoffeeShop.PointOfSale.EntityFramework.New.Models;
using Spectre.Console;

namespace CoffeeShop.PointOfSale.EntityFramework.New.Services;

internal class CategoryService
{
	internal static void InsertCategory()
	{
		var category = new Category
		{
			CategoryName = AnsiConsole.Ask<string>("Category's name:")
		};

		CategoryController.AddCategory(category);
	}

	internal static void GetCategories()
	{
		var table = new Table();

		table.AddColumn("CategoryId");
		table.AddColumn("CategoryName");

		foreach (var category in CategoryController.GetCategories())
		{
			table.AddRow(category.CategoryId.ToString(), category.CategoryName.ToString());
		}

		AnsiConsole.Write(table);

		Console.WriteLine("Enter any key to continue");
		Console.ReadLine();
		Console.Clear();
	}
}
