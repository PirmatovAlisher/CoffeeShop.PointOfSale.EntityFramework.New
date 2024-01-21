using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.PointOfSale.EntityFramework.New
{
	internal class ProductsContext : DbContext
	{
		public DbSet<Product> Products { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => 
																	  optionsBuilder.UseSqlite($"Data Source = product.db");
	}
}
