namespace OrderSystem;

public class SqlOrderStorage : IOrderReader, IOrderWriter, IOrderStorage
{
    public void Save(Order order)
    {
        Console.WriteLine($"[SQL] Saved {order.Id}");
    }

    public IEnumerable<Order> GetAll()
    {
        return Enumerable.Empty<Order>();
    }
}