using CoffeeShop.PointOfSale.EntityFramework.New.Controllers;
using CoffeeShop.PointOfSale.EntityFramework.New.Models;
using Spectre.Console;

namespace CoffeeShop.PointOfSale.EntityFramework.New.Services;

internal class ProductService
{

    internal static void InsertProduct()
    {
        var product = new Product
        {
            ProductName = AnsiConsole.Ask<string>("Product's name:"),
            ProductPrice = AnsiConsole.Ask<decimal>("Product's price:")
        };
        ProductController.AddProduct(product);
    }

    static private Product GetProductOptionInput()
    {
        var products = ProductController.GetProducts();

        var productsArray = products.Select(x => x.ProductName).ToArray();

        var option = AnsiConsole.Prompt(new SelectionPrompt<string>().Title("Choose Product").AddChoices(productsArray));

        var id = products.Single(x => x.ProductName == option).ProductId;

        var product = ProductController.GetProductById(id);

        return product;
    }

    static internal void DeleteProduct()
    {
        var product = GetProductOptionInput();
        ProductController.DeleteProduct(product);
    }

    internal static void GetProduct()
    {
        var product = GetProductOptionInput();
        UserInterface.ShowProduct(product);
    }

    internal static void GetProducts()
    {
        UserInterface.ShowProductTable(ProductController.GetProducts());
    }

    internal static void UpdateProduct()
    {
        var product = GetProductOptionInput();

        product.ProductName = AnsiConsole.Confirm("Update name?")
                            ? AnsiConsole.Ask<string>("Product's new name")
                            : product.ProductName;

        product.ProductPrice = AnsiConsole.Confirm("Update price?")
                            ? AnsiConsole.Ask<decimal>("Product's new price")
                            : product.ProductPrice;

        ProductController.UpdateProduct(product);
    }
}
