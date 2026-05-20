namespace OrderSystem;

public interface IOrderDiscount
{
    decimal CalculateDiscount(Order order);
}