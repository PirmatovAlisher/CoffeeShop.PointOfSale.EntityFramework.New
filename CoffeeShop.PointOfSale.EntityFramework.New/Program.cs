namespace CoffeeShop.PointOfSale.EntityFramework.New
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var context = new ProductsContext();
			context.Database.EnsureDeleted();
			context.Database.EnsureCreated();


			UserInterface.MainMenu();
		}


	}
}
