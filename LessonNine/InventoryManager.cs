using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class Product
{
    public string Name { get; }
    public int Quantity { get; }
    public decimal Price { get; }

    public Product(string name, int quantity, decimal price)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new DateInvalidException("Product name cannot be empty.");
        if (quantity <= 0)
            throw new DateInvalidException("Quantity must be a positive integer.");
        if (price <= 0)
            throw new DateInvalidException("Price must be a positive number.");

        Name = name;
        Quantity = quantity;
        Price = price;
    }

    public decimal TotalValue => Quantity * Price;
}

public class DateInvalidException : Exception
{
    public DateInvalidException(string message) : base(message) { }
}

public class ProductNotExistingException : Exception
{
    public ProductNotExistingException(string message) : base(message) { }
}

public class Inventory
{
    private readonly List<Product> products = new();

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public Product SearchProduct(string name)
    {
        var product = products.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (product == null) throw new ProductNotExistingException($"Product '{name}' not found.");
        return product;
    }

    public decimal GetTotalInventoryValue()
    {
        return products.Sum(p => p.TotalValue);
    }
}

class InventoryManagement
{
    public static void Execute()
    {
        Inventory inventory = new();

        int productCount;
        while (true)
        {
            Console.Write("Enter the number of products: ");
            if (int.TryParse(Console.ReadLine(), out productCount) && productCount > 0)
                break;

            Console.WriteLine("Invalid input. Please enter a **positive integer**.");
        }

        for (int i = 0; i < productCount; i++)
        {
            try
            {
                Console.Write($"Enter name for product {i + 1}: ");
                string name = Console.ReadLine() ?? string.Empty;
                if (string.IsNullOrWhiteSpace(name))
                    throw new DateInvalidException("Product name cannot be empty.");

                int quantity;
                while (true)
                {
                    Console.Write($"Enter quantity for product {i + 1}: ");
                    if (int.TryParse(Console.ReadLine(), out quantity) && quantity > 0)
                        break;

                    Console.WriteLine("Invalid input. Quantity must be a **positive integer**.");
                }

                decimal price;
                while (true)
                {
                    Console.Write($"Enter price per unit for product {i + 1}: ");
                    if (decimal.TryParse(Console.ReadLine(), out price) && price > 0)
                        break;

                    Console.WriteLine("Invalid input. Price must be a **positive number**.");
                }

                inventory.AddProduct(new Product(name, quantity, price));
            }
            catch (DateInvalidException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                i--; 
            }
        }

        Console.WriteLine($"Total inventory value: {inventory.GetTotalInventoryValue()}");

        Console.Write("Enter a product name to search: ");
        string searchName = Console.ReadLine() ?? string.Empty;
        try
        {
            var product = inventory.SearchProduct(searchName);
            Console.WriteLine($"Product found: {product.Name}, Quantity: {product.Quantity}, Price per unit: {product.Price}");
        }
        catch (ProductNotExistingException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}