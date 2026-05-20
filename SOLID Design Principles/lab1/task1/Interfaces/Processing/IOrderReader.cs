namespace OrderSystem;

public interface IOrderReader
{
    IEnumerable<Order> GetAll();
}