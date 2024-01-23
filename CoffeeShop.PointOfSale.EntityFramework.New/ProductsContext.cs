using CoffeeShop.PointOfSale.EntityFramework.New.Models;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.PointOfSale.EntityFramework.New
{
	internal class ProductsContext : DbContext
	{
		public DbSet<Product> Products { get; set; }

		public DbSet<Category> Categories { get; set; }

		public DbSet<Order> Orders { get; set; }

		public DbSet<OrderProduct> OrderProducts { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
								optionsBuilder.UseSqlite($"Data Source = product.db");

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<OrderProduct>()
						.HasKey(op => new { op.OrderProductId, op.ProductId });

			modelBuilder.Entity<OrderProduct>()
						.HasOne(op => op.Order)
						.WithMany(o => o.OrderProducts)
						.HasForeignKey(o => o.OrderProductId);

			modelBuilder.Entity<OrderProduct>()
						.HasOne(op => op.Product)
						.WithMany(o => o.OrderProducts)
						.HasForeignKey(o => o.ProductId);

			modelBuilder.Entity<Product>()
						.HasOne(p => p.Category)
						.WithMany(o => o.Products)
						.HasForeignKey(p => p.CategoryId);

			modelBuilder.Entity<Category>()
						.HasData(new List<Category>
						{

							new() {
							CategoryId = 1,
							CategoryName = "Coffee"
							},

							new()
							{
								CategoryId = 2,
								CategoryName = "Juice"
							}
						});

			modelBuilder.Entity<Product>()
						.HasData(new List<Product>
						{
							new() {
								ProductId = 1,
								CategoryId = 1,
								ProductName = "Late",
								ProductPrice = 5.99m
							},
							
							new() {
								ProductId = 2,
								CategoryId = 1,
								ProductName = "Espresso",
								ProductPrice = 3.99m
							},
							
							new() {
								ProductId = 3,
								CategoryId = 2,
								ProductName = "Apple Juice",
								ProductPrice = 1.99m
							},
							
							new() {
								ProductId = 4,
								CategoryId = 2,
								ProductName = "Orange Juice",
								ProductPrice = 8.99m
							}
						});
		}
	}
}
