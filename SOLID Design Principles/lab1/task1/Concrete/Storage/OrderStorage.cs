namespace OrderSystem;

public class OrderStorage : IOrderStorage
{
    private readonly IOrderWriter _writer;

    public OrderStorage(IOrderWriter writer)
    {
        _writer = writer;
    }

    public void Save(Order order)
    {
        _writer.Save(order);
    }
}