namespace task2.Models;
public class ProductList
{
    public static List<Product> Products = new List<Product>()
    {
        new Product() { Id = 1, Name = "Product1", Category = "Category1", Status = "active" },
        new Product() { Id = 2, Name = "Product2", Category = "Category2", Status = "pending" },
        new Product() { Id = 3, Name = "Product3", Category = "Category3", Status = "inactive" },
        new Product() { Id = 4, Name = "Product4", Category = "Category4", Status = "blocked" },
        new Product() { Id = 5, Name = "Product5", Category = "Category5", Status = "rejected" }
    };
}