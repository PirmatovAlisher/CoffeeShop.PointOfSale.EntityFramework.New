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

	internal static void GetCategory()
	{
		var category = GetCategoryOptionInput();

		UserInterface.ShowCategory(category);
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

	internal static Category GetCategoryOptionInput()
	{
		var categories = CategoryController.GetCategories();

		var categoriesArray = categories.Select(x => x.CategoryName).ToArray();

		var option = AnsiConsole.Prompt(new SelectionPrompt<string>()
								.Title("Choose Category")
								.AddChoices(categoriesArray));

		var category = categories.Single(x => x.CategoryName == option);

		return category;
	}

	internal static void DeleteCategoty()
	{
		var category = GetCategoryOptionInput();

		CategoryController.DeleteCategory(category);

	}

	internal static void UpdateCategory()
	{
		var category = GetCategoryOptionInput();

		category.CategoryName = AnsiConsole.Confirm("Update CategoryName?")
							  ? AnsiConsole.Ask<string>("Category's new Name:")
							  : category.CategoryName;

		CategoryController.UpdateCategory(category);
	}
}
