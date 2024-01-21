using Spectre.Console;

namespace CoffeeShop.PointOfSale.EntityFramework.New
{
	internal class Program
	{
		static void Main(string[] args)
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
						ProductController.UpdateProduct();
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

		enum MenuOptions
		{
			AddProduct,
			DeleteProduct,
			UpdateProduct,
			ViewProduct,
			ViewAllProducts,
			Quit
		}
	}
}
