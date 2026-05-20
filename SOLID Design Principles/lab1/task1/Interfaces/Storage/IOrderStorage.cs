namespace OrderSystem;

public interface IOrderStorage
{
    void Save(Order order);
}