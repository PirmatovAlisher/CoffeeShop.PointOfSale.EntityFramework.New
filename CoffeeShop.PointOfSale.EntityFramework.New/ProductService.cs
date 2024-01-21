using Spectre.Console;

namespace CoffeeShop.PointOfSale.EntityFramework.New;

internal class ProductService
{
	static private Product GetProductOptionInput()
	{
		var products = ProductController.GetProducts();

		var productsArray = products.Select(x => x.ProductName).ToArray();

		var option = AnsiConsole.Prompt(new SelectionPrompt<string>().Title("Choose Product").AddChoices(productsArray));

		var id = products.Single(x => x.ProductName == option).ProductId;

		var product = ProductController.GetProductById(id);

		return product;
	}

	internal static void InsertProduct()
	{
		var name = AnsiConsole.Ask<string>("Product's name:");
		ProductController.AddProduct(name);
	}

	static internal void DeleteProduct()
	{
		var product = GetProductOptionInput();
		ProductController.DeleteProduct(product);
	}

	internal static void GetProduct()
	{
		var product = GetProductOptionInput();
		UserInterface.ShowProduct(product);
	}

	internal static void GetProducts()
	{
		UserInterface.ShowProductTable(ProductController.GetProducts());
	}
}
