namespace CoffeeShop.PointOfSale.EntityFramework.New;

internal class ProductController
{
	internal static void AddProduct(string name)
	{
		using var db = new ProductsContext();

		db.Add(new Product { ProductName = name });
		db.SaveChanges();

	}

	internal static void DeleteProduct(Product product)
	{
		using var db = new ProductsContext();
		db.Remove(product);
		db.SaveChanges();
	}

	internal static Product GetProductById(int id)
	{
		using var db = new ProductsContext();

		var product = db.Products.SingleOrDefault(x => x.ProductId == id);

		return product;
	}

	internal static List<Product> GetProducts()
	{
		using var db = new ProductsContext();

		var products = db.Products.ToList();
		return products;
	}

	internal static void Quit()
	{
		throw new NotImplementedException();
	}

	internal static void UpdateProduct()
	{
		throw new NotImplementedException();
	}
}
