using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeShop.PointOfSale.EntityFramework.New.Models
{
	internal class Product
	{
		public int ProductId { get; set; }

		public string ProductName { get; set; }

		public decimal ProductPrice { get; set; }

		public int CategoryId { get; set; }

		public Category Category { get; set; }

		public ICollection<OrderProduct> OrderProducts { get; set; }
	}
}