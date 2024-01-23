namespace CoffeeShop.PointOfSale.EntityFramework.New;

internal class Enums
{
	internal enum MenuOptions
	{
		AddCategory,
		ViewCategory,
		ViewAllCategories,
		UpdateCategory,
		DeleteCategory,
		AddProduct,
		DeleteProduct,
		UpdateProduct,
		ViewProduct,
		ViewAllProducts,
		Quit
	}

	internal enum MainMenuOptions
	{
		ManageCategories,
		ManageProducts,
		Quit
	}

	internal enum CategoryMenu
	{
		AddCategory,
		DeleteCategory,
		UpdateCategory,
		ViewAllCategories,
		ViewCategory,
		GoBack
	}

	internal enum ProductMenu
	{
		AddProduct,
		DeleteProduct,
		UpdateProduct,
		ViewProduct,
		ViewAllProducts,
		GoBack
	}
}
