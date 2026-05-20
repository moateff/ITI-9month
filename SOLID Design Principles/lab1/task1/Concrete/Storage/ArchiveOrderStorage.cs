namespace OrderSystem;

public class ArchiveOrderStorage : IOrderReader
{
    public IEnumerable<Order> GetAll() 
    {
        return Enumerable.Empty<Order>();
    }
}