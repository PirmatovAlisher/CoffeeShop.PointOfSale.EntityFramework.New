namespace CoffeeShop.PointOfSale.EntityFramework.New.Models.DTOs;

internal class MonthlyReportDTO
{
	public string Month {  get; set; }	

	public decimal TotalPrice { get; set; }

	public decimal TotalQuantity { get; set; }
}
