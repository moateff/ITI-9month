namespace OrderSystem;

public interface IOrderValidator
{
    bool IsValid(Order order);
}