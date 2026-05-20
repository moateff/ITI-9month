namespace OrderSystem;

public interface IOrderWriter
{
    public void Save(Order order);
}