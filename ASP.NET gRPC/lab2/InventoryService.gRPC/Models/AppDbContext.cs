namespace InventoryService.gRPC.Models;

public class AppDbContext
{
    public List<Item> Items = new List<Item>
    {
        new Item { Id = 1, Quantity = 5 },
        new Item { Id = 2, Quantity = 10 },
        new Item { Id = 3, Quantity = 20 }
    };
}