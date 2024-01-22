﻿using CoffeeShop.PointOfSale.EntityFramework.New.Models;

namespace CoffeeShop.PointOfSale.EntityFramework.New.Controllers;

internal class CategoryController
{
	internal static void AddCategory(Category category)
	{
		using var db = new ProductsContext();

		db.Add(category);
		db.SaveChanges();
			

	}

	internal static List<Category> GetCategories()
	{
		using var db = new ProductsContext();

		var categories = db.Categories.ToList();

		return categories;


	}
}
