using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeShop.PointOfSale.EntityFramework.New.Models
{
	[Index(nameof(ProductName), IsUnique = true)]
	internal class Product
	{
		[Key]
		public int ProductId { get; set; }

		[Required]
		public string ProductName { get; set; }

		[Required]
		public decimal ProductPrice { get; set; }

		public int CategoryId { get; set; }

		[ForeignKey(nameof(CategoryId))]
		public Category Category { get; set; }
	}
}