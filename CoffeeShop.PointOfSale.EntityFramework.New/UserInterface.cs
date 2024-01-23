using CoffeeShop.PointOfSale.EntityFramework.New.Models;
using CoffeeShop.PointOfSale.EntityFramework.New.Services;
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
			Console.Clear();
			var option = AnsiConsole.Prompt(new SelectionPrompt<MainMenuOptions>()
									.Title("What would you like to do?")
									.AddChoices(
										 MainMenuOptions.ManageCategories,
										 MainMenuOptions.ManageProducts,
										 MainMenuOptions.ManageOrders,
										 MainMenuOptions.Quit
										 ));

			switch (option)
			{
				case MainMenuOptions.ManageCategories:
					CategoriesMenu();
					break;
				case MainMenuOptions.ManageProducts:
					ProductsMenu();
					break;
				case MainMenuOptions.ManageOrders:
					OrdersMenu();
					break;
				case MainMenuOptions.Quit:
					Console.WriteLine("Goodbye");
					appActive = false;
					break;
			}
		}
	}

	private static void OrdersMenu()
	{
		var isOrdersMenuRunning = true;

		while (isOrdersMenuRunning)
		{
			Console.Clear();
			var option = AnsiConsole.Prompt(new SelectionPrompt<OrderMenu>()
									.Title("Orders Menu")
									.AddChoices(
									OrderMenu.AddOrder,
									OrderMenu.GoBack
									));

			switch (option)
			{
				case OrderMenu.AddOrder:
					OrderService.InsertOrder();
					break;
				case OrderMenu.GoBack:
					isOrdersMenuRunning = false;
					break;
			}

		}
	}

	private static void CategoriesMenu()
	{
		var isCategoriesMenuRunning = true;

		while (isCategoriesMenuRunning)
		{
			Console.Clear();
			var option = AnsiConsole.Prompt(new SelectionPrompt<CategoryMenu>()
									.Title("Categories Menu")
									.AddChoices(
									CategoryMenu.AddCategory,
									CategoryMenu.DeleteCategory,
									CategoryMenu.UpdateCategory,
									CategoryMenu.ViewCategory,
									CategoryMenu.ViewAllCategories,
									CategoryMenu.GoBack
									));

			switch (option)
			{
				case CategoryMenu.AddCategory:
					CategoryService.InsertCategory();
					break;
				case CategoryMenu.DeleteCategory:
					CategoryService.DeleteCategoty();
					break;
				case CategoryMenu.UpdateCategory:
					CategoryService.UpdateCategory();
					break;
				case CategoryMenu.ViewCategory:
					CategoryService.GetCategory();
					break;
				case CategoryMenu.ViewAllCategories:
					CategoryService.GetCategories();
					break;
				case CategoryMenu.GoBack:
					isCategoriesMenuRunning = false;
					break;
			}

		}
	}

	private static void ProductsMenu()
	{
		Console.Clear();
		var isProductsMenuRunning = true;

		while (isProductsMenuRunning)
		{
			var option = AnsiConsole.Prompt(new SelectionPrompt<ProductMenu>()
									.Title("Products Menu")
									.AddChoices(
									ProductMenu.AddProduct,
									ProductMenu.DeleteProduct,
									ProductMenu.UpdateProduct,
									ProductMenu.ViewProduct,
									ProductMenu.ViewAllProducts,
									ProductMenu.GoBack
									));

			switch (option)
			{
				case ProductMenu.AddProduct:
					ProductService.InsertProduct();
					break;
				case ProductMenu.DeleteProduct:
					ProductService.DeleteProduct();
					break;
				case ProductMenu.UpdateProduct:
					ProductService.UpdateProduct();
					break;
				case ProductMenu.ViewProduct:
					ProductService.GetProduct();
					break;
				case ProductMenu.ViewAllProducts:
					ProductService.GetProducts();
					break;
				case ProductMenu.GoBack:
					isProductsMenuRunning = false;
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
		table.AddColumn("Category");

		foreach (var product in products)
		{
			table.AddRow(product.ProductId.ToString(), product.ProductName, product.ProductPrice.ToString(), product.Category.CategoryName);
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
Price: {product.ProductPrice}
Category: {product.Category.CategoryName}");

		panel.Header = new PanelHeader("Product Info");
		panel.Padding = new Padding(2, 2, 2, 2);

		AnsiConsole.Write(panel);
		Console.WriteLine("Enter any key to continue");
		Console.ReadLine();
		Console.Clear();
	}

	internal static void ShowCategory(Category category)
	{
		var panel = new Panel($@"Id: {category.CategoryId}
Name: {category.CategoryName}
Product Count: {category.Products.Count}");

		panel.Header = new PanelHeader($"{category.CategoryName}");
		panel.Padding = new Padding(2, 2, 2, 2);

		AnsiConsole.Write(panel);
		ShowProductTable(category.Products);
		Console.WriteLine("Enter any key to continue");
		Console.ReadLine();
		Console.Clear();
	}
}
