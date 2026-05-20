namespace OrderSystem;

public interface IDiscountStrategy
{
    decimal GetDiscount(Order order);
}